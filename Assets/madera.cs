using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class madera : MonoBehaviour
{

    public List<GameObject> trabajador;

    
    // Start is called before the first frame update
    public bool on;

    
    public void TrabajadorOn()
    {
        for (int i = 0; i < trabajador.Count; i++)
        { trabajador[i].SetActive(true); 
        }
    }

    public void TrabajadorOff()
    {
        for (int i = 0; i < trabajador.Count; i++)
        {
            trabajador[i].SetActive(false);
        }
    }
}
