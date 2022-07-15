using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    //public Transform cameraAnchor;
    private Touch touch1, touch2;
    public float speedModiferMin = 0.003f;
    public float speedModifer = 0.01f;
    public float speedModiferMax = 0.015f;
    public GameObject centro;
    public string playerid;
    public bool move = true;
    Camera cam;

    //Selec
    Vector3 selecBegan, selecEnd, lastpoint;
    public GameObject selectorPrefab;
    public GameObject selector;

    
    public Vector2 limiteZ, limiteX;
    public playerSystem player;
    string playerID;
    public LayerMask layerGround;
    public LayerMask layerBuild;
    public bool inv = false,nega=false;
    public GameObject targetPrefab;
    public cinemaControl camaraszoom;

    public Vector2 touchszoom1, touchszoom2;
    public float distancia,distancianew=0;
    public bool moveUnits;
    public UnitSpawner spawner;
    public Vector3 point;
   
    
    private void Start()
    {
        cam = Camera.main;

        playerID = player.playerID;
        
    }

    public void moveralcentro(Vector3 a)
    {
        transform.position=new Vector3( a.x,5, a.z);
    }
    private void Update()
    {
      //  Debug.Log("" + Input.touchCount);
        if (!move)
        {
            if (Input.touchCount == 2)
            {

                distancianew = (Mathf.Abs(Input.GetTouch(1).position.x) - Mathf.Abs(Input.GetTouch(0).position.x)) + (Mathf.Abs(Input.GetTouch(1).position.y) - Mathf.Abs(Input.GetTouch(0).position.y));
                if (nega)
                    distancianew = distancianew * -1;
                camaraszoom.cam.orthographicSize = camaraszoom.analizar(distancianew - distancia);
               //s Debug.Log(distancianew - distancia + "distancia");
            }
            else
            {
                    move = true;
                camaraszoom.guardar();
            }
        }
        if (move)
        {
            if (Input.touchCount > 0)
            {
                #region Touch1


                //Move
                if (Input.touchCount == 1)
                {
                    touch1 = Input.GetTouch(0);


                    if (touch1.phase == TouchPhase.Moved)
                    {

                        if (!moveUnits)
                        {
                            if (inv)
                            {
                                transform.Translate(touch1.deltaPosition.x * 0.08f, 0, touch1.deltaPosition.y * 0.08f);
                            }
                            else
                                transform.Translate(-touch1.deltaPosition.x * speedModifer, 0, -touch1.deltaPosition.y * speedModifer * 2);
                        }
                        else
                        {

                            spawner.TargetMove(point);


                        }


                    }

                    if (touch1.phase == TouchPhase.Began)
                    {

                        lastpoint = Input.touches[0].position;
                    }


                    if (touch1.phase == TouchPhase.Ended)
                    {
                        if (spawner != null)
                        {
                            spawner.TargetMove(point);
                            spawner = null;
                            moveUnits = false;
                        }
                    }

                }


                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider != null)
                    {


                        if (hit.transform.tag == "Build")
                        {

                            //minas
                            var mina = hit.transform.GetComponent<minaScript>();
                            if (mina != null)
                            {
                                mina.CollecAll();
                                //Debug.Log("");
                            }

                            //granja
                            var granja = hit.transform.GetComponent<granjaScript>();
                            if (granja != null)
                            {
                                granja.CollecAll();
                                // Debug.Log("hit");
                            }

                            //carpinteria
                            var carpinteria = hit.transform.GetComponent<carpinteriaScript>();
                            if (carpinteria != null)
                            {
                                carpinteria.CollecAll();
                                // Debug.Log("hit");
                            }

                            var army = hit.transform.GetComponent<ArmySystem>();
                            if (army != null)
                            {
                                army.DoUnits(army.unitsCanDo);
                                // Debug.Log("hit");
                            }
                        }

                        if (hit.transform.tag == "Unit")//esto mueve al soldado
                        {
                            int s = hit.transform.GetComponent<UnitsAi>().team;
                            if (s == 1)
                            {
                                if (touch1.phase == TouchPhase.Began)
                                {
                                    moveUnits = true;
                                    spawner = hit.transform.GetComponent<UnitsAi>().spawner;


                                }
                            }
                        }

                        if (hit.transform.tag == "Ground")
                        {
                            point = hit.point;

                        }

                    }
                }

                #endregion

                #region Touch2
                /*
                if (Input.touchCount == 2)
                {
                    touch2 = Input.GetTouch(1);

                    Ray r = cam.ScreenPointToRay(Input.touches[1].position);
                    RaycastHit j;

                    if (Physics.Raycast(r, out j, 100 , layerGround) )
                    {
                        if (j.collider != null)
                        {
                            if (j.collider.tag == "Ground")
                            {

                                if(units.Count > 0)
                                {
                                    var target = Instantiate(targetPrefab, j.point, Quaternion.Euler(0, 0, 0));

                                    target.GetComponent<targetList>().units = units; 

                                    foreach (var u in units)
                                    {
                                        u.ChangeTarget(target.transform);  

                                    }

                                    units.Clear();
                                }


                                if (touch2.phase == TouchPhase.Began)// punto de inicio
                                {

                                    selecBegan = j.point;
                                    selector = Instantiate(selectorPrefab, selecBegan, Quaternion.Euler(0,0, 0));
                                    selector.transform.localScale = new Vector3 (0.1f, 1, 0.1f);
                                    selector.GetComponent<SelectorScript>().cam = this;
                                    selector.GetComponent<SelectorScript>().playerID = playerID;


                                    

                                }


                                if (touch2.phase == TouchPhase.Moved )// punto de inicio
                                {
                                    selecEnd = j.point;

                                    Vector3 size = new Vector3( selecEnd.x - selecBegan.x, 1,  selecEnd.z - selecBegan.z);

                                    if (selector != null)
                                    {

                                        if (size.x < 0 && size.z >= 0)
                                        {
                                            selector.transform.position = new Vector3(selecBegan.x + size.x, 0, selecBegan.z);
                                            size.x = Mathf.Abs(size.x);
                                        }
                                        else if (size.z < 0 && size.x >= 0)
                                        {
                                            selector.transform.position = new Vector3(selecBegan.x, 0, selecBegan.z + size.z);
                                            size.z = Mathf.Abs(size.z);
                                        }
                                        else if (size.z < 0 && size.x < 0)
                                        {
                                            selector.transform.position = new Vector3(selecBegan.x + size.x, 0, selecBegan.z + size.z);
                                            size.z = Mathf.Abs(size.z);
                                            size.x = Mathf.Abs(size.x);
                                        }



                                        selector.transform.localScale = size;

                                    }                             

                                    
                                }

                                

                            }
                        }
                    }

                    if (touch2.phase == TouchPhase.Ended)// punto de inicio
                    {

                        Destroy(selector.gameObject);

                        units = selector.GetComponent<SelectorScript>().units;
                    }


                }

                */
                #endregion
            }
            
            
                if (Input.touchCount >= 2)
                {
                    if (Input.GetTouch(1).phase == TouchPhase.Began)
                    {
                        touchszoom1 = Input.GetTouch(0).position;
                        touchszoom2 = Input.GetTouch(1).position;
                    
                        distancia = (Mathf.Abs(touchszoom2.x) - Mathf.Abs(touchszoom1.x)) + (Mathf.Abs(touchszoom2.y) - Mathf.Abs(touchszoom1.y));
                    if (distancia < 0)
                    {
                        distancia = distancia * -1;
                        nega = true;
                    }
                    else
                        nega = false;
                        move = false;
                    }
                }
            

            
        }
        Vector3 aux = transform.position;
        if (transform.position.x > limiteX.y)
        {
            aux.x = limiteX.y;
        }
        if (transform.position.x < limiteX.x)
        {
            aux.x = limiteX.x;
        }
        if (transform.position.z > limiteZ.y)
        {
            aux.z = limiteX.y;
        }
        if (transform.position.z < limiteZ.x)
        {
            aux.z = limiteX.x;
        }
        transform.position = aux;
    }


    public void MoveOn()
    {
        //move = true;
    }
    public void MoveOff()
    {
        //move = false;
    }
}
