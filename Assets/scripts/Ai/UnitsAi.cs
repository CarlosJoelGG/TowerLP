using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitsAi : MonoBehaviour
{
    public int team;

    StateInf State;
    public bool Selected;
    public Transform target, lastTarget;
    public Vector3 lastTargetPoint;

    public Animator anim;
    public float visionRange, attackRange, endRange, delayOrderMax;
    public float delayOrder;

    public enum estado { parado, defender, follow, atacar, move }
    public estado aiState;

    public Vector3 lastPos;

    public enum typeAttack { meele, range, boom}
    public typeAttack tAttack;
    NavMeshAgent nav;

    public GameObject seleted;

    Rigidbody rb;

    public bool  enemygosCerca;
   
    public UnitSpawner spawner;
    public int intSpawner;
    
    [Header("ataque")]
    public float vidaMax;
    public float vida;
    public float str;
    public float escudo;
    public float armadura;
    public float attackTime;
    private float attackDelay;
    public LayerMask layerUnits;
    float deadTime = 0.3f;



    // Start is called before the first frame update
    void Awake()
    {
       
        aiState = estado.parado;
        
        nav = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();

   

        seleted.SetActive(false);

      

         if (delayOrderMax == 0)
        {
            delayOrderMax = 2;
        }

        lastPos = transform.position;
        lastTargetPoint = transform.position;

        if (str == 0) str = 3;
        if (attackTime == 0) attackTime = 1.5f;


    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;

      if (vida <= 0)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("dead"))
            {
                
                Destroy(gameObject, deadTime);
            }
            anim.SetTrigger("dead");
           
            
        }
        else
        {


            if (delayOrder > 0)
            {
                delayOrder -= Time.deltaTime;


                if (delayOrder < 0)
                {
                    delayOrder = 0;
                }
                enemygosCerca = false;
                nav.destination = lastTargetPoint;

            }
            else if (delayOrder <= 0)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, visionRange, layerUnits);//enemigos en area de vision


                if (colliders.Length >1)//si hay mas de una colision es porque hay otras unidades  en rango de vision
                {
                    Collider[] col = Physics.OverlapSphere(transform.position, attackRange, layerUnits);//unidades en area de ataque

                    if (col.Length > 1)//si hay unidades en rango de ataque
                    {
                        for (int i = 0; i < col.Length; i++)//buscar enemigos
                        {
                            if (col[i].GetComponent<UnitsAi>().team != team)//enemigo Target
                            {
                                target = col[i].transform;


                                nav.destination = target.position;
                                enemygosCerca = true;
                                break;
                            }

                            if (i >= col.Length - 1)//enemigo no encontrado
                            {
                                enemygosCerca = false;
                                nav.destination = lastTargetPoint;
                               
                            }
                        }

                    }

                    if (enemygosCerca == false)//si no hay enemigos en rango de ataque buscar en rango de vision
                    {
                        for (int i = 0; i < colliders.Length; i++)//buscar enemigos
                        {
                            if (colliders[i].GetComponent<UnitsAi>().team != team)//enemigo Target
                            {
                                target = colliders[i].transform;


                                nav.destination = target.position;
                                enemygosCerca = true;
                                break;
                            }

                            if (i >= colliders.Length - 1)//enemigo no encontrado
                            {
                                enemygosCerca = false;
                                nav.destination = lastTargetPoint;
                                
                            }
                        }
                    }
                    
                }
               
                if (colliders.Length == 1)//si solo hay una colision es porque es este objeto
                {
                    enemygosCerca = false;
                    nav.destination = lastTargetPoint;
                }

            }

            
            if (target == null && aiState != estado.atacar )//si no hay un target
            {
                ChangeTarget(spawner.group.transform.GetChild(intSpawner));
            }


            if (enemygosCerca)//si hay enemigos cerca
            {
                if (target != null)//si target existe
                {


                    if (Vector3.Distance(transform.position, target.position) < attackRange)//si el target esta en el rango de ataque
                    {
                        if (delayOrder <= 0)//si no hay una orden de movimiento
                        {
                            if (attackDelay > 0)//tiempo de espera entre ataques
                            {
                                attackDelay -= Time.deltaTime;

                                aiState = estado.parado;
                                anim.SetBool("move", false);
                                nav.destination = transform.position;
                                delayOrder = 0;
                                nav.isStopped = true;

                            }
                            else// Atacar
                            {
                                
                                if (target.TryGetComponent<UnitsAi>(out UnitsAi infEnemy))
                                {
                                    aiState = estado.atacar;
                                    anim.SetTrigger("attack");
                                    attackDelay = attackTime;
                                    infEnemy.vida -= str - infEnemy.armadura;
                                }
                                
                            }

                        }
                        else//si hay una orden de movimiento, moverse
                        {
                            nav.isStopped = false;
                            aiState = estado.move;
                            nav.destination = lastTargetPoint;
                        }


                    }
                    else if (Vector3.Distance(transform.position, target.position) >= attackRange)//si el target esta fuera del rango de ataque
                    {
                        if (target.TryGetComponent<UnitsAi>(out UnitsAi infEnemy))
                        {
                            if (delayOrder > 0)//si hay una orden de movimiento seguirla
                            {
                                nav.isStopped = false;
                                aiState = estado.move;
                                nav.destination = lastTargetPoint;
                            }
                            else//si no hay una orden de movimiento ir al enemigo
                            {
                                nav.isStopped = false;
                                nav.destination = target.position;
                                aiState = estado.move;
                            }
                        }
                        

                            

                    }

                    //estamos peleando fuera lejos de mi punto de reposo, y la animacion no de ataque, volver
                    else if (Vector3.Distance(transform.position, lastPos) > visionRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("ataque"))
                    {
                        ChangeTarget(spawner.group.transform.GetChild(intSpawner));
                    }
             

                }

                else //si no hay un target volver a la ultima posicion 
                {
                     ChangeTarget(spawner.group.transform.GetChild(intSpawner));
                }


            }

            if (!enemygosCerca)//si no hay enemigos cerca
            {

                if (Vector3.Distance(transform.position, lastTargetPoint) >= endRange)//volver a formacion
                {
                    if (target == null)
                    {
                        ChangeTarget(spawner.group.transform.GetChild(intSpawner));  
                    }
                }

               

                if (Vector3.Distance(transform.position, nav.destination) <= endRange)// si llegamos al destino 
                {
                    aiState = estado.parado;
                    lastPos = transform.position;

                }
                else if (Vector3.Distance(transform.position, nav.destination) > endRange)// si no hemos llegado al destino 
                {
                    

                    aiState = estado.move;
                    nav.destination = lastTargetPoint;
                }
            }


            //Animciones y movimiento 


            Vector3 dr = nav.velocity;

            if (dr.magnitude > 1f)//ejes de movimiento
            {
                anim.SetFloat("moveX", dr.x);
                anim.SetFloat("moveY", dr.z);
            }


            if (aiState == estado.atacar)//ataque
            {
                anim.SetBool("move", false);
                nav.isStopped = true;
                nav.destination = transform.position;

                //mirar al target 
                transform.LookAt(target, Vector3.up);
                
                anim.SetFloat("moveX", target.position.x - transform.position.x);
                anim.SetFloat("moveY", target.position.z - transform.position.z);
                
                if (!enemygosCerca)
                {
                    ChangeTarget(spawner.group.transform.GetChild(intSpawner));
                }
                

            }
            else//si no atacamos
            {


                if (aiState == estado.move && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))//moverse
                {
                    anim.SetBool("move", true);
                    nav.isStopped = false;


                }

                if (aiState == estado.parado)//parar
                {
                    aiState = estado.parado;
                    anim.SetBool("move", false);
                    //nav.destination = transform.position;
                    delayOrder = 0;
                    nav.isStopped = true;
                    rb.velocity = Vector2.zero;
                }



            }

            if (Selected)
            {
                seleted.SetActive(true);
            }
            else
            {
                seleted.SetActive(false);
            }

           
        }

    }

     void followEnemy()
    {

    }



    public void ChangeTarget(Transform a)
    {
        delayOrder = Vector3.Distance (transform.position, a.position)/nav.speed;


        if(lastTarget != null)
        {
            lastTarget = target;
           
        }


        Selected = true;
        target = a;
        lastTargetPoint = target.position;
        nav.destination = target.position;
        DeSelec();


        if (Vector3.Distance(transform.position, nav.destination) < endRange)//parar
        {
            aiState = estado.parado;
            anim.SetBool("move", false);
            nav.destination = transform.position;
            delayOrder = 0;
            nav.isStopped = true;
        }

    }

    public void DeSelec()
    {
        
        Selected = false;
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col != null)
        {
            
                if (col.tag == "Selector")
                {
                var  state = GetComponent<StateInf>();
                 
                       /// if (state.playerid == col.GetComponent<SelectorScript>().playerID)
                      //  {
                            
                       ////     Selected = true;
                         //   col.GetComponent<SelectorScript>().units.Add(this);
                      //  }

                }

        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col != null)
        {

            if (col.tag == "Selector")
            {
                var state = GetComponent<StateInf>();

              //  if (state.playerid == col.GetComponent<SelectorScript>().playerID)
              //  {

                //    Selected = false;
                //    col.GetComponent<SelectorScript>().units.Remove(this);
                    
               // }
            }

            Debug.Log("Des");
        }
    }



}
