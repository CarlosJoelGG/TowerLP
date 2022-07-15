using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuboposition : MonoBehaviour
{
    public Vector3 posicion,aux;
    public GameObject camara;
    public float variante = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        posicion = camara.transform.position;
        posicion.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        aux = camara.transform.position;
        transform.position = new Vector3(aux.x, aux.y, aux.z);
    }
    public float cerpuntocinco(float a)
    {
       return (a % variante);
    }
}
