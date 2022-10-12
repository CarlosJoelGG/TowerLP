using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listado : MonoBehaviour
{
    public List<GameObject> slots;
    public GameObject prefabItem;
    public List<GameObject> items = new List<GameObject>();
   
    public List<Item> datos = new List<Item>();
   
    // Start is called before the first frame update
    void Start()
    {
        
       /* for (int i=0;i<datos.Count;i++)
        {
            items.Add(Instantiate(prefabItem));
            items[i].gameObject.transform.parent = slots[i].transform;
            items[i].gameObject.transform.localScale = new Vector3(1, 1, 1);
            items[i].gameObject.transform.localPosition = new Vector3(0,0,0);
            items[i].gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            items[i].gameObject.GetComponent<inventarioSock>().objeto = datos[i];
        }*/
    }
    public void alerta()
    {
        transform.parent.gameObject.GetComponent<mensajes>().alerta();
    }
    public void refrescar()
    {
        transform.parent.gameObject.GetComponent<Cofre>().Iniciar();
    }
    public void Addpropiedades(GameObject a)
    {
        transform.parent.gameObject.GetComponent<Cofre>().PropiedadesAccion(a);
    }
    public void AddItem(Item a)
    {
        
        items.Add(Instantiate(prefabItem));
        items[items.Count-1].gameObject.transform.parent = slots[items.Count - 1].transform;
        items[items.Count - 1].gameObject.transform.localScale = new Vector3(1, 1, 1);
        items[items.Count - 1].gameObject.transform.localPosition = new Vector3(0, 0, 0);
        items[items.Count - 1].gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        datos.Add(a);
      //  items[items.Count - 1].gameObject.GetComponent<inventarioSock>().objeto = a;
        items[items.Count - 1].gameObject.GetComponent<inventarioSock>().LlenarObjeto(a);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
