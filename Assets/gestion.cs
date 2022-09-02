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
        Nombre.text = Data.GetComponent<StateInf>().titulo;
        nivel.text = ""+Data.GetComponent<StateInf>().intLevel;

        if (Data.GetComponent<StateInf>().id == 6 || Data.GetComponent<StateInf>().id == 7 || Data.GetComponent<StateInf>().id == 8)
        {
            produccion.text = "" + Data.GetComponent<carpinteriaScript>().recurso;
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
        if (Data.GetComponent<StateInf>().id == 6 || Data.GetComponent<StateInf>().id == 7 || Data.GetComponent<StateInf>().id == 8)
        {
            produccion.text = "" + Data.GetComponent<carpinteriaScript>().recurso;
        }

    }
}
