using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class accionPie : MonoBehaviour
{
    public Text pieTexto;
    public string textopie;
    public GameObject botonA, botonComplete;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void accion()
    {
        gameObject.transform.parent.gameObject.GetComponent<anadirdescricion>().examinar();
    }
    public void Completar()
    {
        gameObject.transform.parent.gameObject.GetComponent<anadirdescricion>().Completar();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent.gameObject.GetComponent<anadirdescricion>().datos.meta <= gameObject.transform.parent.gameObject.GetComponent<anadirdescricion>().datos.progreso)
        {
            pieTexto.text = "Mision Completada";

        }
        else
        {
            pieTexto.text = "Progreso de la mision: " + gameObject.transform.parent.gameObject.GetComponent<anadirdescricion>().datos.progreso + "/" + gameObject.transform.parent.gameObject.GetComponent<anadirdescricion>().datos.meta;
        }
    }
}
