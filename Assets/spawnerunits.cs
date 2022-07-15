using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnerunits : MonoBehaviour
{
    public List<GameObject> spwans;
    public GameObject Ganaste,perdiste;
    public BD bds;
    public int vidasenemigas=6,vidaUsuario=1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bds.SoldadosEscuadrones.Count; i++)
        {
            spwans[i].SetActive(true);
        }
        vidaUsuario = bds.SoldadosEscuadrones.Count;
    }
    public void backmundo()
    {
        SceneManager.LoadScene("Mundo");
    }
    public void vidamenos(bool a)
    {
        if (a)
        { vidasenemigas--; }
        else
        { vidaUsuario--; }
        if (vidasenemigas <= 0)
        {
            bds.AddRecursos(0, 800);
            bds.AddRecursos(1, 800);
            bds.AddRecursos(2, 800);
            bds.RefrescarUsuario();
            Ganaste.SetActive(true);
           
        }
        if (vidaUsuario <= 0)
        {
            perdiste.SetActive(true);
         
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
