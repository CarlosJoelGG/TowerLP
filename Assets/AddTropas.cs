using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTropas : MonoBehaviour
{
    public List<GameObject> tokens;
    public List<escuadron> tropas;
    public GameObject Data;
    public GameObject prefa;
    // Start is called before the first frame update
    void Start()
    {
        Iniciar();
    }
    public void Iniciar()
    {
        destruir();
        Data = GameObject.Find("BD");
        tropas = new List<escuadron>();
        List<escuadron> aux = new List<escuadron>();
        aux = Data.GetComponent<BD>().SoldadosEscuadrones;
        tokens = new List<GameObject>();
        GameObject aux2 = prefa;
        for (int i = 0; i < aux.Count; i++)
        {
            
                tropas.Add(aux[i]);
        
        }
        for (int i = 0; i < tropas.Count; i++)
        {
            aux2 = prefa;
          
            tokens.Add(Instantiate(aux2));
            tokens[i].GetComponent<GestionTropas>().Data = tropas[i];
            tokens[i].GetComponent<GestionTropas>().index = i;
            tokens[i].transform.parent = transform;
            tokens[i].transform.position = new Vector3(0, 0, 0);
            tokens[i].transform.localScale = new Vector3(1, 1, 1);
            tokens[i].transform.localEulerAngles = new Vector3(0, 0, 0);

        }
    }
    public void destruir()
    {
        for (int i = 0; i < tokens.Count; i++)
        {
            Destroy(tokens[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
