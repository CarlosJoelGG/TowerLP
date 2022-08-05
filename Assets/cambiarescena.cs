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
        int a = 0;
        if (BDa.SoldadosEscuadrones != null)
        {for (int i = 0; i < BDa.SoldadosEscuadrones.Count; i++)
            {
                a += BDa.SoldadosEscuadrones[i].cantidad;
            }
            if (a > 0)
                SceneManager.LoadScene(escena);
        }
    }
}
