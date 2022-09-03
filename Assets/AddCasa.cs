using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCasa : MonoBehaviour
{
    public List<GameObject> casas,tokens;
    public GameObject Data;
    public GameObject prefa;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void Iniciar()
    {
        destruir();
        Data = GameObject.Find("mundo");
        List<GameObject> aux = new List<GameObject>();
        aux = Data.GetComponent<ubicarmundo>().objetosdelmundo;
        tokens = new List<GameObject>();
        for (int i = 0; i < aux.Count; i++)
        {
            if (aux[i].GetComponent<StateInf>().id > 1)
            {
                casas.Add(aux[i]);
            }
        }
        for (int i = 0; i < casas.Count; i++)
        {
            prefa.GetComponent<gestion>().Data = casas[i];
            tokens.Add(Instantiate(prefa));
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
