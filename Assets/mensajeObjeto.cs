using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mensajeObjeto : MonoBehaviour
{
    public List<Text> textos;
    public Image casa;
    public GameObject aux;
    public bool recursosreal = false;
    public StateInf reso;
    public GameObject aux2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void info(StateInf a)
    {
        textos[0].text = a.titulo;
        textos[1].text = a.descripcion;
        textos[2].text = a.intLevel+"";
        casa.sprite = a.IAlerta;
        if (a.recursos)
        {
            recursosreal = true;
               reso = a;
               textos[3].text = a.gameObject.GetComponent<carpinteriaScript>().recurso + "";
            aux.SetActive(true);
        }
        else
        {
            recursosreal = false;
            aux.SetActive(false);
        }
        if (a.barraca)
        {
            aux2.SetActive(true);
        }
        else
        {
            aux2.SetActive(false);
        }
    }

    public void upgrade(string oro,string wood,string comida,string titulo,Sprite imagen,int lv)
    {
        recursosreal = false;
        textos[0].text = oro;
        textos[1].text = wood;
        textos[2].text = comida;
        textos[3].text = titulo;
        textos[4].text = lv + "";
        textos[5].text = (lv + 1) + "";
        casa.sprite = imagen;
    }
    // Update is called once per frame
    void Update()
    {
        if (recursosreal)
        {
            textos[3].text = reso.gameObject.GetComponent<carpinteriaScript>().recurso + "";
        }
    }
}
