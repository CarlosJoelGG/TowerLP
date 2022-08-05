using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    [Header("Variables de Funsion")]
    Vector3 posInicial;
    Vector3 dir;
    public float maxAngleY;
    public float maxZ;
    public GameObject pivotZ, pivotY, pivotX;
    UnitsAi unit;
    float distance;
    float angle;
    public Rigidbody rb;
    public float speed;
    bool stop;


    [Header ("Variables de creacion")]
    
    public float Str;
    public int Team;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        posInicial = transform.position;

        distance = Vector3.Distance(posInicial, target);

        dir = target - posInicial;

        transform.LookAt(target, Vector3.up);//Direcion 
    }

    // Update is called once per frame
    void Update()
    {
      
            if (Vector3.Distance(transform.position, posInicial) < distance)
            {
                rb.velocity = dir.normalized * speed * Time.deltaTime;
               // pivotX.transform.localRotation = Quaternion.Euler(maxAngleY / 3, 0, 0);
               /*
                if (pivotX.transform.localPosition.y > 0.1f)
                {
                    pivotX.transform.localPosition = new Vector3(0, pivotX.transform.localPosition.y - distance * 0.01f, 0);
                }
                */

            }
            else
            {
                rb.velocity = Vector3.zero;

                if (!stop)
                {
                    preDestroy();
                }
            }
        

        
        
     }

    void Elipse()
    {
        if (Vector3.Distance(transform.position, posInicial) < distance)
        {
            rb.velocity = dir.normalized * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, posInicial) < distance)
            {
                if (Vector3.Distance(transform.position, target) < distance * 0.2f)
                {

                    pivotX.transform.localRotation = Quaternion.Euler(maxAngleY, 0, 0);

                    if (pivotX.transform.localPosition.y > 0.1f)
                    {
                        pivotX.transform.localPosition = new Vector3(0, pivotX.transform.localPosition.y - distance * 0.04f, 0);
                    }

                }
                if (Vector3.Distance(transform.position, target) < distance * 0.4f && Vector3.Distance(transform.position, target) >= distance * 0.2f)
                {

                    pivotX.transform.localRotation = Quaternion.Euler(maxAngleY * 0.4f, 0, 0);
                    pivotX.transform.localPosition = new Vector3(0, pivotX.transform.localPosition.y - distance * 0.03f, 0);

                }
                if (Vector3.Distance(transform.position, target) < distance * 0.60f && Vector3.Distance(transform.position, target) >= distance * 0.4f)
                {

                    pivotX.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    pivotX.transform.localPosition = new Vector3(0, pivotX.transform.localPosition.y + distance * 0.02f, 0);

                }
                if (Vector3.Distance(transform.position, target) < distance * 0.80f && Vector3.Distance(transform.position, target) >= distance * 0.6f)
                {

                    pivotX.transform.localRotation = Quaternion.Euler(-maxAngleY * 0.4f, 0, 0);
                    pivotX.transform.localPosition = new Vector3(0, pivotX.transform.localPosition.y + distance * 0.04f, 0);

                }
                if (Vector3.Distance(transform.position, target) >= distance * 0.80f)
                {

                    pivotX.transform.localRotation = Quaternion.Euler(-maxAngleY, 0, 0);
                    pivotX.transform.localPosition = new Vector3(0, pivotX.transform.localPosition.y + distance * 0.05f, 0);

                }
            }
        }

        else
        {
            rb.velocity = Vector3.zero;
            if (!stop)
            {
                preDestroy();
            }
        }
    }

    void preDestroy()
    {
        Destroy(gameObject);

        
    }

    public void TakeDamage(UnitsAi enemy)
    {
        if(enemy.team != Team)
        {
            enemy.vida -= Str - enemy.escudo;
            Destroy(gameObject);
        }
    }
}
