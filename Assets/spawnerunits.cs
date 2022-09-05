using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnerunits : MonoBehaviour
{
    public List<GameObject> spwans,armada;
    public GameObject Ganaste,perdiste;
    public BD bds;
    public int vidasenemigas=6,vidaUsuario=1;
    public List<GameObject> posicionesSpawn;
    public List<int> posiciones;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void iniciar()
    {
        armada = new List<GameObject>();
        int a = 0;
        for (int i = 0; i < 5; i++)
        {
            //   for (int j = 0; j < bds.SoldadosEscuadrones[i].cantidad; j++)
            //  {
            if (posiciones[i] != -1)
            {
                a++;
                armada.Add(Instantiate(spwans[posiciones[i]]));
                armada[armada.Count - 1].transform.position = posicionesSpawn[armada.Count - 1].transform.position;
                armada[armada.Count - 1].transform.localScale = new Vector3(1, 1, 1);
                bds.restarsoldado(posiciones[i]);
            }
            }

       // }
        vidaUsuario = a;
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
