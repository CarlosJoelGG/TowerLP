using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarescena : MonoBehaviour
{
    public string escena;
    public BD BDa;
    public void Accion()
    {
        if(BDa.SoldadosEscuadrones!=null)
        if(BDa.SoldadosEscuadrones.Count>0)
        SceneManager.LoadScene(escena);
    }
}
