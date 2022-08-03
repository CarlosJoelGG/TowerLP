using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{
    public int trabajadores = 0;
    public Vector2Int gridSize = new Vector2Int(40, 40); 
    public BuildingSystem [,] grid;
    public CamaraMove camMove;
    public BuildingSystem buildFly;
    public List<BuildingSystem> casas;
    public Vector3 rotacionlocla=new Vector3(0,-0,0);
    private bool reMove = true;
    bool build,firstPoint=false;
    public bool available = true;
    public static GridBuildingSystem gridBuildingSystem;
    public Ray ray;

    private Camera cam;

    public Transform CamTransform;

    public int anadircasa(BuildingSystem a)
    {
        casas.Add(a);
        return (casas.Count  - 1);
    }
    private void Awake()
    {
        grid = new BuildingSystem[gridSize.x, gridSize.y];
        cam = Camera.main;
        if (gridBuildingSystem == null)
        {
            gridBuildingSystem = this;
        }
    }
    private void Start()
    {
        casas = new List<BuildingSystem>();
    }
    public void moverCasas(int a)
    {
        GameObject.Find("CanvasMain").GetComponent<Ui>().BuildingUi();
        GameObject.Find("camara container").GetComponent<CamaraMove>().MoveOff();
        CasaPropiedades(-1);
        buildFly = casas[a];
        buildFly.BSinicio();
        firstPoint = false;
        foot(true);
    }
    public void OnOffBotones(bool a)
    {
        for (int i = 0; i < casas.Count; i++)
        {       
                    casas[i].push.SetActive(a);        
        }
    }
    public void foot(bool a)
    {
        build = a;
        camMove.move = true;
        OnOffBotones(!a);
    }
    public void StartBuilding(BuildingSystem building)
    {

        if (trabajadores < 2)
        {
            if (building != null)
            {
                buildFly=null;
            }
            GameObject.Find("CanvasMain").GetComponent<Ui>().BuildingUi();
            GameObject.Find("camara container").GetComponent<CamaraMove>().MoveOff();
            CasaPropiedades(-1);
            buildFly = Instantiate(building);
            buildFly.BSinicio();
            foot(true);
            firstPoint = true;
           
        }
    }

    public void CasabotonesOnOff(bool a)
    {
       
            for (int i = 0; i < casas.Count; i++)
            {
                if (i != 1 && i!=0)
                {
                    {
                        casas[i].interaccion.SetActive(a);
                        casas[i].menudesplegado = a;
                    }
                   // camMove.moveralcentro(casas[i].gameObject.transform.position);
                }
                
            }  
       
    }
    public void CasaPropiedades(int a)
    {
        for (int i = 0; i < casas.Count; i++)
        {
            if (i == a && (a != 0 && a != 1))
            {
                if (!casas[i].menudesplegado)
                { casas[i].interaccion.SetActive(true);
                    casas[i].menudesplegado = true;
                }
                else
                { casas[i].interaccion.SetActive(false);
                    casas[i].menudesplegado = false;
                }
                camMove.moveralcentro(casas[i].gameObject.transform.position);
            }
            else
                casas[i].interaccion.SetActive(false); 
        }
    }
    public void FinishBuilding()
    {
        if (!buildFly.chocando)
        {
            buildFly.SetNormal();
            if(firstPoint)
            {
                buildFly.nextLevel();
                buildFly.gameObject.GetComponent<StateInf>().marca = GameObject.Find("BD").GetComponent<BD>().Comprar(buildFly.gameObject.GetComponent<StateInf>());
            }
            else
            {
                GameObject.Find("BD").GetComponent<BD>().MoverObjeto(buildFly.misdatos,buildFly.misdatos.Inc);
            }
           
        }
        else
        {
            if (firstPoint)
            {
                Debug.Log("--destrir por chocar ---");
                casas.RemoveAt(casas.Count-1);
                Destroy(buildFly.gameObject, 0.2f);
            }
            else
            {
                buildFly.regresar();
            }
         
            
        }
        firstPoint = false;
        foot(false);
        buildFly = null;
    }

    public void CancelBuilding()
    {
        if (firstPoint)
        {
            Debug.Log("--destrir por cancelar ---");
            casas.RemoveAt(casas.Count - 1);
            Destroy(buildFly.gameObject, 0.2f);
           
        }
        else
        {
            buildFly.regresar();
        }
        
        foot(false);
        firstPoint = false;
        buildFly = null;

    }
    private void Update()
    {
        if (build)
        {
            if (Input.touchCount > 0)
            {
                Vector3 woldPosition = buildFly.transform.position;
                RaycastHit[] choques = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
                for (int i = 0; i < choques.Length; i++)
                {
                    if (choques[i].transform.tag.Equals("Build"))
                    {
                        if (choques[i].transform.gameObject.GetComponent<BuildingSystem>())
                        {
                            choques[i].transform.gameObject.GetComponent<BuildingSystem>().apuntando();
                         camMove.move = !choques[i].transform.gameObject.GetComponent<BuildingSystem>().tocando;   
                        }
                    }
                    if (choques[i].transform.name.Equals("Plane"))
                    {
                        float aaa = woldPosition.y;
                        woldPosition = choques[i].point;
                    }
                }
                if (buildFly.tocando)
                {
                    woldPosition.x = Mathf.Round(woldPosition.x) + 0.5f;
                    woldPosition.z = Mathf.Round(woldPosition.z) + 0.5f;
                    buildFly.gameObject.transform.position = woldPosition;
                }
                else
                {
                    camMove.inv = false;
                }
            }
            else
            {

                if (buildFly.tocando)
                {
                    buildFly.tocando = false;
                    camMove.move = true;
                }
               
            }
            
        }
       
    }
    
}
