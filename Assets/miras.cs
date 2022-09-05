using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miras : MonoBehaviour
{
    public Image apuntar;
    public Sprite Vacio;
    public List<Sprite> lleno;
    public GameObject targ;
    public int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void vaciar()
    {
        index = -1;
        apuntar.sprite = Vacio;
    }
    public void iniciar()
    {
        if (index == -1)
        { 
        }
        else
        {
            GameObject.Find("mundo").GetComponent<unidadesEnElMundo>().quitar();
        }
    }
    public void Llenar(int a)
    {
        index = a;
        apuntar.sprite = lleno[a];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
