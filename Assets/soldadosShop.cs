using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldadosShop : MonoBehaviour
{
    public BD soldi;
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
        if (!aux.GetComponent<BD>().verificarbarracas())
        {
            for (int i = 0; i < soldados.Count; i++)
            {
                articulos.Add(Instantiate(soldados[i]));
                articulos[i].transform.parent = this.gameObject.transform;
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
