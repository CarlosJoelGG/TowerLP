using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionTropas : MonoBehaviour
{

    public Text Nombre, nivel, produccion;
    public Image foto;
    public List<GameObject> tropas;
    public List<Sprite> casasimagenes;
    public escuadron Data;
    public int index=0;
    // Start is called before the first frame update
    void Start()
    {
       
        Nombre.text = Data.Nombre;
        nivel.text = "" + Data.Level;


        produccion.text = "" + Data.cantidad;

        foto.sprite = casasimagenes[index];

    }

    // Update is called once per frame
    void Update()
    {
        produccion.text = "" + Data.cantidad;

    }
    public void ir()
    {
        GameObject.Find("CanvasMain").GetComponent<Ui>().GestorTropasIr();
    }
}

