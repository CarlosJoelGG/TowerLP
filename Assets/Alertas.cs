using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alertas : MonoBehaviour
{
    public Image casa;
    public BuildingSystem dataActual;
    public GameObject Aler,alertinfo;
    public void Aceptar()
    {
        dataActual.mejorar();
        Aler.SetActive(false);
    }
    public void Cancelar()
    {
        dataActual.AlertaOff();
        Aler.SetActive(false);
        alertinfo.SetActive(false);
    }
    public void mostrar(int a,BuildingSystem b)
    {
        switch (a)
        {
            case 1://informacion
                alertinfo.SetActive(true);
                alertinfo.GetComponent<mensajeObjeto>().info(b.misdatos);
                dataActual = b;
                break;
            case 3:
                Aler.SetActive(true);
                dataActual = b;
                string x, y, z, w="";
                x = dataActual.misdatos.MoneyPrice * dataActual.misdatos.intLevel + "";
                y= dataActual.misdatos.WoodPrice * dataActual.misdatos.intLevel + "";
                z= dataActual.misdatos.FoodPrice * dataActual.misdatos.intLevel + "";
                w = dataActual.misdatos.titulo;
                Sprite k = dataActual.misdatos.IAlerta;
                int Z=dataActual.misdatos.intLevel;
                Aler.GetComponent<mensajeObjeto>().upgrade(x,y,z,w,k,Z);
                break;
        }
    }


}
