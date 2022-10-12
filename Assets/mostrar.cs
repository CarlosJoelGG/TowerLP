using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrar : MonoBehaviour
{
    public Item propiedades;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void refrescar() 
    {
        transform.parent.gameObject.GetComponent<listado>().refrescar();
    }
    public void alerta()
    {
        transform.parent.gameObject.GetComponent<listado>().alerta();
    }
    public void AddPropiedades(GameObject a)
    {
       // propiedades = a;
        transform.parent.gameObject.GetComponent<listado>().Addpropiedades(a);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
