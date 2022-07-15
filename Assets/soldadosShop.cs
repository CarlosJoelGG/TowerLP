using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldadosShop : MonoBehaviour
{
    public BD soldi;
    public List<GameObject> soldados;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject aux = GameObject.Find("BD");
        if (!aux.GetComponent<BD>().verificarbarracas())
        {
            soldados[0].SetActive(false);
        }
        else
        {
            soldados[0].SetActive(true);
        }
    }
}
