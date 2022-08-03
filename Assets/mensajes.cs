using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mensajes : MonoBehaviour
{
    public GameObject Encender,Apagar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void alerta()
    {
        Encender.SetActive(true);
        Apagar.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
