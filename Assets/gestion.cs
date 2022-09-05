using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestion : MonoBehaviour
{
    public Text Nombre, nivel, produccion;
    public Image foto;
    public List<GameObject> casas;
    public List<Sprite> casasimagenes;
    public GameObject Data;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("BD").GetComponent<BD>().llenarM();
        Nombre.text = Data.GetComponent<StateInf>().titulo;
        nivel.text = ""+Data.GetComponent<StateInf>().intLevel;

        if (Data.GetComponent<StateInf>().Inc)
        {
            produccion.text = "" + Data.GetComponent<BuildingSystem>().timing();
        }
        else
        {
            produccion.text = "---";
        }
        foto.sprite = casasimagenes[Data.GetComponent<StateInf>().id];

    }

    // Update is called once per frame
    void Update()
    {
        if (Data.GetComponent<StateInf>().Inc)
        {
            produccion.text = "" + Data.GetComponent<BuildingSystem>().timing();
        }
        else
        {
            if (produccion.text.Equals("---"))
            { }
            else
            produccion.text = "---";
        }

    }
    public void ir()
    {
        GameObject.Find("CanvasMain").GetComponent<Ui>().GestorIr();
        Data.GetComponent<BuildingSystem>().Accion();
    }
}
