using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botonesbuilder : MonoBehaviour
{
    public GameObject upgrade, mover, cocechar, tienda, cancelar,info;
    public Text titulo;
    public List<Sprite> imagenescocecha;
    public cinemaControl control;
    //public float tamano=1;
    public int tipoMenu = 0;
    public Vector3 Base;
    public BuildingSystem data;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("camara container").GetComponent<cinemaControl>();
       
        upgrade = transform.GetChild(2).gameObject;
        mover = transform.GetChild(1).gameObject;
        cocechar = transform.GetChild(3).gameObject;
        //tienda = transform.GetChild(1).gameObject;
        cancelar = transform.GetChild(4).gameObject;
        data = transform.parent.gameObject.GetComponent<BuildingSystem>();
        titulo.text = data.misdatos.titulo;
        menus(tipoMenu);
       

    }
    public void Mover()
    {

        data.Mover();
        transform.gameObject.SetActive(false);
    }

    public void Upgrade()
    {
        data.Alert(3);
        transform.gameObject.SetActive(false);
    }
    public void Cocechar()
    {
        transform.parent.gameObject.GetComponent<carpinteriaScript>().Collec();
    }
    public void informacion()
    {
        data.Alert(1);
        transform.gameObject.SetActive(false);
    }
    public void menus(int a)
    {
        if (data.misdatos.intLevel < 11 && !data.misdatos.Inc)
        {
            upgrade.SetActive(true);
        }
        else
        {
            upgrade.SetActive(false);
        }
        switch (a)
        {
            case 0:
                cocechar.SetActive(false);
                mover.SetActive(true);
                cancelar.SetActive(true);
               
                break;
            case 1:
                cocechar.SetActive(false);
                mover.SetActive(false);
                cancelar.SetActive(true);
                upgrade.SetActive(false);
                break;
            case 2:
                cocechar.SetActive(true);
                cocechar.GetComponent<Image>().sprite = imagenescocecha[0];
                mover.SetActive(true);
                cancelar.SetActive(true);
             
                break;
            case 3:
                cocechar.SetActive(true);
                cocechar.GetComponent<Image>().sprite = imagenescocecha[1];
                mover.SetActive(true);
                cancelar.SetActive(true);
               
                break;
            case 4:
                cocechar.SetActive(true);
                cocechar.GetComponent<Image>().sprite = imagenescocecha[2];
                mover.SetActive(true);
                cancelar.SetActive(true);
            
                break;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (tipoMenu == 1)
        {
            
        }
    }
}
