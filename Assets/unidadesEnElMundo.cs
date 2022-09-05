using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unidadesEnElMundo : MonoBehaviour
{
    public spawnerunits claseSpawner;
    public List<miras> targets;
    public int index = 0;
    public GameObject UICanvas;
    public cinemaControl Zoom;
    public List<int> count;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.Find("BD").GetComponent<BD>().SoldadosEscuadrones.Count; i++)
        { count.Add(GameObject.Find("BD").GetComponent<BD>().SoldadosEscuadrones[i].cantidad);
        }
    }
    public void llenar(int a)
    {
        if (count[a] > 0)
        {
            targets[index].Llenar(a);
            index++;
            count[a]--;
        }
    }
    public void quitar(int a)
    {
        index--;
        if(index>=0)
        targets[index].vaciar();
        count[a]++;

    }
    public void iniciar()
    {
        bool aux = false;
        for (int i = 0; i < 5; i++)
            if (targets[i].index != -1)
                aux = true;

        if (!aux)
            return;

        for (int i = 0; i < 5; i++)
        {
            claseSpawner.posiciones[i] = targets[i].index;
         }
        claseSpawner.gameObject.GetComponent<spawnerunits>().enabled=true;
        UICanvas.SetActive(false);
        claseSpawner.iniciar();
        Zoom.iniciar();

    }
    public void cancelar()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
