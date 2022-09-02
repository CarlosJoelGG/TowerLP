using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldadosShop : MonoBehaviour
{
    public GameObject soldi;
    public List<GameObject> soldados,articulos;

    void Start()
    {
       
    }
    public void destruir()
    {
        for (int i = 0; i < articulos.Count; i++)
        {
            Destroy(articulos[i]);
        }
    }
    public void Iniciar()
    {
        destruir();
        articulos = new List<GameObject>();
           GameObject aux = GameObject.Find("BD");
       //  if (aux.GetComponent<BD>().verificarbarracas())
         {
        Debug.Log(aux.GetComponent<BD>().SoldadosEscuadrones.Count);
            for (int i = 0; i < aux.GetComponent<BD>().SoldadosEscuadrones.Count; i++)
            {
                articulos.Add(Instantiate(soldados[0]));
                articulos[i].transform.parent = this.gameObject.transform;
                articulos[i].GetComponent<escuadronesshop>().llenar(aux.GetComponent<BD>().SoldadosEscuadrones[i]);
                articulos[i].transform.localScale = new Vector3(1, 1, 1);
                articulos[i].transform.localPosition = new Vector3(0, 0, 0);
                articulos[i].transform.localEulerAngles = new Vector3(0, 0, 0);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
