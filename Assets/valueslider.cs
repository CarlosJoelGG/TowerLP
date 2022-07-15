using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valueslider : MonoBehaviour
{
    public Text score,sombra;
    public bool experiencia = false;
    public BD inf;
    public int puntos = 0;
    public int capacidad = 100;
    public int newpuntos = 0;
    public float porcentaje=1;
    public Slider lidr;
    public void refresh(int a)
    {
        if (experiencia)
        {
            capacidad = 3;
            puntos= GameObject.Find("BD").GetComponent<BD>().people.Exp;
            score.text = "" + puntos+ " xp";
            sombra.text = "" + puntos + " xp";
            porcentaje = (float)puntos * (1.0f / (float)capacidad);
            if (porcentaje < 0)
                porcentaje = 0;
            if (porcentaje > 1)
                porcentaje = 1;
            lidr.value = 0.985f * porcentaje;
        }
        else
        {

            newpuntos = a;
            puntos = a;

            score.text = "" + puntos;
            porcentaje = (float)puntos * (1.0f / (float)capacidad);
            if (porcentaje < 0)
                porcentaje = 0;
            if (porcentaje > 1)
                porcentaje = 1;
            lidr.value = 0.985f * porcentaje;
        }
    }
    public void newlimite(int a)
    {
        capacidad = a;
        refresh(puntos);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newpuntos != puntos)
        {
            refresh(newpuntos);
        }
        if (experiencia)
        {
            refresh(0);
        }
    }
}
