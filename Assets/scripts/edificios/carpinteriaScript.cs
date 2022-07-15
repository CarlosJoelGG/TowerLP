using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carpinteriaScript : MonoBehaviour
{
    public StateInf state;

    public int level, woodMax, recurso=0, timeMax,tipoderecurso=0,NC=0;
    public float plusPerSecond;

    public GameObject collec;
    public GameObject Circulo;

    public bool active=false;
    BuildingSystem build;


    // Start is called before the first frame update
    void Start()
    {


        build = GetComponent<BuildingSystem>();

        if (state == null) state = GetComponent<StateInf>();

        level = state.intLevel;

        refresh();
        
        
    }

    public void information()
    {
        
    }

    public void refresh()
    {
        switch (level)
        {
            case 0:
                level = 1;
                break;

            case 1:
                woodMax = 300;
                timeMax = 300;
                break;

            case 2:
                woodMax = 500;
                timeMax = 500;
                break;

            case 3:
                woodMax = 1000;
                timeMax = 1000;
                break;

            case 4:
                woodMax = 1700;
                timeMax = 1700;
                break;

            case 5:
                woodMax = 2800;
                timeMax = 2800;
                break;
        }

        collec.SetActive(false);
    }
    private void Update()
    {
       
            Circulo.SetActive(build.moving);
        
        if (active)
        {
            if(build.timeBuildRestante <= 0)
            {
                    plusPerSecond += ((Time.deltaTime/(10-level))+((Time.deltaTime / (10 - level)) * NC));
                if (!Circulo.GetComponent<CollicionRecurse>().test)
                { Circulo.GetComponent<CollicionRecurse>().test = true;
                    Circulo.transform.localScale = Vector3.zero;
                 
                }
 
                    ReCirculo();
                    if (Mathf.FloorToInt(plusPerSecond) >= 1)
                    {
                    if(recurso< woodMax)
                        recurso++;
                        plusPerSecond = 0;
                    }

                    
            }
            if (build.noRender)
            {
               
                    circulo();    
            }    
        }

        if (recurso > woodMax / 3)
        {
            collec.SetActive(true);
        }
        else 
        {
            collec.SetActive(false);
        }
        if (state.intLevel != level)
        {
            level = state.intLevel;
            refresh();
        }
    }

    public void CollecAll()
    {
       


    }

    public void circulo()
    {

        if(build.noRender)
        {
            if(build.timeBuildRestante<= 0)
            {
               
            }
            else
            {
                Circulo.transform.localScale = Vector3.zero;
               
            }
        }
        
    }

    void ReCirculo()
    {
        Circulo.transform.localScale = new Vector3(1,1,1);
       

        Invoke("circulo", 0.2f);
    }
    
    public void Collec()
    {
        recurso= GameObject.Find("BD").GetComponent<BD>().AddRecursos(tipoderecurso, recurso);
        GameObject.Find("BD").GetComponent<BD>().RefrescarUsuario();
       // recurso = 0;
        
    }
}
