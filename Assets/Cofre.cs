using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public List<GameObject> Objetos;
    public GameObject Prefab;
    public BD data;
    // Start is called before the first frame update
    void Start()
    {
        Iniciar();
    }
    public void destruir()
    {
        for (int i = 0; i < Objetos.Count; i++)
        {
            Destroy(Objetos[i]);
        }
        Objetos = new List<GameObject>();
    }
    public void Iniciar()
    {
        destruir();
        int aux = 0;
        for (int i = 0; i < data.Items.Count; i++)
        {
            if (data.Items[i].Cantidad > 0)
            {
                Objetos.Add(Instantiate(Prefab));
                Objetos[aux].transform.parent = transform;
                Objetos[aux].transform.localEulerAngles = new Vector3(0, 0, 0);
                Objetos[aux].transform.localScale = new Vector3(1,1,1);
                Objetos[aux].GetComponent<inventarioSock>().LlenarObjeto(data.Items[i]);
                aux++;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
