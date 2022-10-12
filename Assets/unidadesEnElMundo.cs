using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unidadesEnElMundo : MonoBehaviour
{
    public spawnerunits claseSpawner;
    public List<miras> targets;
    public int index = 0;
    public GameObject UICanvas;
    public cinemaControl Zoom;
    public List<int> count;
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.Find("BD").GetComponent<BD>().SoldadosEscuadrones.Count; i++)
        { count.Add(GameObject.Find("BD").GetComponent<BD>().SoldadosEscuadrones[i].cantidad);
        }
    }
    public void llenar(int a)
    {
        if (count[a] > 0 && index<5)
        {
            targets[index].Llenar(a);
            index++;
            count[a]--;
        }
    }
    public void quitar()
    {
        index--;
        if (index >= 0)
        {
            count[targets[index].index]++;
            targets[index].vaciar();
            
        }

    }
    public void iniciar()
    {
        bool aux = false;
        for (int i = 0; i < 5; i++)
        {
            targets[i].GetComponent<Image>().enabled = false;
            targets[i].GetComponent<Button>().enabled = false;
            targets[i].GetComponent<BoxCollider>().enabled = false;

            if (targets[i].index != -1)
                aux = true;
        }

        if (!aux)
            return;

        for (int i = 0; i < 5; i++)
        {
            claseSpawner.posiciones[i] = targets[i].index;
         }
        claseSpawner.gameObject.GetComponent<spawnerunits>().enabled=true;
        UICanvas.SetActive(false);
        claseSpawner.iniciar();
        Zoom.iniciar();

    }
    public void cancelar()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Vector3 woldPosition = new Vector3(0, 0, 0);
            RaycastHit[] choques = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (Input.touches[0].phase == TouchPhase.Began)
            {

                for (int i = 0; i < choques.Length; i++)
                {
                    if (choques[i].transform.tag.Equals("Target"))
                    {
                      //  Debug.Log("cho");
                       // toDrag = choques[i].transform.gameObject.transform;
                        dragging = true;
                    }

                }



            }
            if (dragging)
            {
                for (int i = 0; i < choques.Length; i++)
                {
                    if (choques[i].transform.name.Equals("Plane"))
                    {
                        woldPosition = choques[i].point;
                        // woldPosition.y= 5.433464f;
                        toDrag.position = choques[i].point;
                    }
                   


                }
            }
        }
        else
        {
            dragging = false;
        }
    }
}
