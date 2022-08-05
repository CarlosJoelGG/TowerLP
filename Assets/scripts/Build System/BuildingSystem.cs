using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuildingSystem : MonoBehaviour
{
    public GameObject interaccion;
    public Vector2Int size = Vector2Int.one;
    public GameObject cuadritos;
    public int TokenID=0;
    public Vector3 distancia;
    public SpriteRenderer renSprite;
    private GridBuildingSystem grid;
    private BoxCollider bx;
    public GameObject terminarobra;
    public int colisionando = 0;
    public bool chocando = false;
    private bool free;
    public bool moving;
    public Vector3 posicion, aux,lastposition;
    public int touchCoun = -1;
    public GameObject estructura;
    public GameObject trabajadores;
    public int indexbuild = -1;
    public bool tocando=false;
    public StateInf misdatos;
    public GameObject push;
    public const int nivelMax = 11;
    public float[] timeBuild = new float[nivelMax];
    public float timeBuildRestante,variante=0.5f;
    public int tipodemenu=0;
    public Slider timeBar;
    public Text timeText;
    public Vector2 precio;
    public bool menudesplegado = false;
    public bool noRender;
    public Vector3 rotacionlocla = new Vector3(0, 0, 0);
    public BD bD;

    public void apuntando()
    {
        if (moving)
            if (!tocando)
                tocando = true;
    }
    public void mejorar()
    {
        if (bD.people.Coin > misdatos.MoneyPrice * misdatos.intLevel)
        {
            if (bD.people.Madera > misdatos.WoodPrice * misdatos.intLevel)
            {
                if (bD.people.Mineral > misdatos.FoodPrice * misdatos.intLevel)
                {
                    nextLevel();
                    bD.people.Mineral -= (misdatos.FoodPrice * misdatos.intLevel);
                    bD.people.Coin -= (misdatos.MoneyPrice * misdatos.intLevel);
                    bD.people.Madera -= (misdatos.WoodPrice * misdatos.intLevel);
                    bD.RefrescarUsuario();
                    bD.MoverObjeto(misdatos,false);
                }
            }
        }
        AlertaOff();
    }
    public void AlertaOff()
    {
        GameObject.Find("Grid System").GetComponent<GridBuildingSystem>().OnOffBotones(true);
    }
    public void Alert(int a)
    {
        GameObject.Find("Grid System").GetComponent<GridBuildingSystem>().OnOffBotones(false);
        GameObject.Find("CanvasMain").GetComponent<Ui>().Alertas(a,gameObject.GetComponent<BuildingSystem>());
    }
    public void BSinicio()
    {
        transform.position = GameObject.Find("camara container").transform.position;
        transform.parent = GameObject.Find("mundo").transform;
        SetTransparent();
        push.SetActive(false);
        moving = true;
        if (misdatos.id == 6 || misdatos.id == 7 || misdatos.id == 8)
            gameObject.GetComponent<carpinteriaScript>().active = false;
    }
    private void Awake()
    {
        //selec.SetActive(false);
        timeBuildRestante = 0;
        if (estructura)
        bx = estructura.GetComponent<BoxCollider>();
        bx.isTrigger = false;
        free = true;
        if(timeBar != null)
        {
            timeBar.gameObject.SetActive(false);
        }
        misdatos= GetComponent<StateInf>();
        interaccion = transform.GetChild(0).gameObject;
        interaccion.SetActive(false);
        precio = new Vector2(misdatos.MoneyPrice, misdatos.WoodPrice);
        bD = GameObject.Find("BD").GetComponent<BD>();
    }
    public void regresar()
    {
        transform.gameObject.transform.position = lastposition;
        moving = false;
        if (misdatos.id == 6 || misdatos.id == 7 || misdatos.id == 8)
            gameObject.GetComponent<carpinteriaScript>().active = true;
    }
    public void Mover()
    {
        lastposition = transform.gameObject.transform.position;
        GameObject.Find("Grid System").GetComponent<GridBuildingSystem>().moverCasas(indexbuild);
    }
    public void Accion()
    {
        if (misdatos.id != 1 && misdatos.id != 0)
        {
            if (timeBar.value == timeBar.maxValue)
            {
                terminar();
                timeBar.value = 0;
                bD.AddExp();
            }
            else
            {
                if (timeBuildRestante <= 0)
                    GameObject.Find("Grid System").GetComponent<GridBuildingSystem>().CasaPropiedades(indexbuild);
            }
        }
    }
    public void Start()
    {
        //  push.enabled = false;
        if (variante == 0)
            variante = 0.5f;
     
        bx = estructura.GetComponent<BoxCollider>();
        bx.isTrigger = false;
        free = true;
        if (timeBar != null)
        {
            timeBar.gameObject.SetActive(false);
        }
        transform.eulerAngles = rotacionlocla;
        grid = GameObject.Find("Grid System").GetComponent<GridBuildingSystem>();
        indexbuild = grid.anadircasa(this);
        interaccion = transform.GetChild(0).gameObject;
        interaccion.SetActive(false);
        precio = new Vector2(misdatos.MoneyPrice, misdatos.WoodPrice);
        // if (misdatos.intLevel == 0)
        //{
        //    nextLevel();
        // }
        bD = GameObject.Find("BD").GetComponent<BD>();
    }
    public string timing()
    {
        string a = "";
        int sec = misdatos.sacarsegundos();
        int diferenciaSec = int.Parse(Mathf.Abs(timeBuild[misdatos.intLevel]) + "") - sec;

        Debug.Log(diferenciaSec+"--"+sec);
        if (diferenciaSec > 0)
        {
            if (diferenciaSec > 31536000)
            {
                a = Mathf.Abs((((diferenciaSec / 60) / 60) / 24) / 365) + "A";
            }
            else
            {
                if (diferenciaSec > 2592000)
                {
                    a = Mathf.Abs((((diferenciaSec / 60) / 60) / 24) / 30) + "M";
                }
                else
                {
                    if (diferenciaSec > (86400 * 7))
                    {
                        a = Mathf.Abs((((diferenciaSec / 60) / 60) / 24)/7) + "S";
                    }
                    else 
                    {
                        if (diferenciaSec > 86400)
                        {
                            a = Mathf.Abs(((diferenciaSec / 60) / 60)/24) + "D";
                        }
                        else
                        {
                            if (diferenciaSec > 3600)
                            {
                                a = Mathf.Abs((diferenciaSec / 60)/60) + "H";
                            }
                            else
                            {
                                if (diferenciaSec > 0)
                                    a = Mathf.Abs(diferenciaSec / 60) + "m:" + (diferenciaSec % 60) + "s";
                                else
                                {  a = "Terminar";
                                    sec = int.Parse(Mathf.Abs(timeBar.maxValue) +"");
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            a = "Terminar";
            sec = int.Parse(Mathf.Abs(timeBar.maxValue) + "");

        }
        timeBar.value = sec;
        return a;
    }
    public void terminar()
    {
        misdatos.Inc = false;
        timeBar.gameObject.SetActive(false);
        misdatos.intLevel++;
        timeBuildRestante = 1;
        bD.MoverObjeto(misdatos, true);

    }
    private void Update()
    {
        if (Input.touchCount== 0)
        {
            if(tocando)
            tocando = false;
        }
        if (misdatos.Inc)
        {
            if (timeBuildRestante != 1)
            {
                timeBuildRestante = 1;
                timeBar.maxValue = timeBuild[misdatos.intLevel];
                trabajadores.SetActive(true);
                timeBar.gameObject.SetActive(true);
                //terminarobra.SetActive(true);
            }

            timeText.text = timing();
        }
        else
        {
           
                if (timeBuildRestante != 0)
                {
                   // misdatos.Inc = false;
                    trabajadores.SetActive(false);
                    timeBuildRestante = 0;
                    
                   
                }
            
        }
        aux.x = Mathf.Round(aux.x) + 0.5f;
        aux.z = Mathf.Round(aux.z) + 0.5f;
        aux = transform.position;
        posicion.y = 0;
        transform.position = new Vector3(aux.x,5 , aux.z);
        if (moving)
        {
            renSprite.gameObject.SetActive(true);
            if (!chocando)
            {
                renSprite.color = Color.green;
            }
            else
            {
                renSprite.color = Color.red;
            }

        }
        else
        {
            renSprite.gameObject.SetActive(false);
        }
    }

    public float cerpuntocinco(float a,float b)
    {

        return Mathf.Round(a % b);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Build")
        {
            var distance = Vector3.Distance(transform.position, other.transform.position);
                free = false;
                SetTransparent();
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Build"))
        {
            colisionando++;
        }
        if(colisionando>0)
            chocando = true;
        else
            chocando = false;
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Build"))
        {
            colisionando--;
        }
        if (colisionando > 0)
        {
            if (!chocando)
            {
                distancia = transform.position - GameObject.Find("camara container").GetComponent<CamaraMove>().centro.transform.position;
                chocando = true;
            }
        }
        else
            chocando = false;
    }
 
  
    public void SetTransparent()
    {
      
            bx.isTrigger = true;
            //renSprite.gameObject.SetActive(true);
           // renSprite.color = Color.green;
    }
    public void OffTransparent()
    {
     
       // bx.isTrigger = false;
       // renSprite.gameObject.SetActive(false);
       // renSprite.color = Color.green;
    }
    public void SetNormal()
    {
        noRender = true;
        bx.isTrigger = false;
        moving = false;
        if (misdatos.id == 6 || misdatos.id == 7 || misdatos.id == 8)
            gameObject.GetComponent<carpinteriaScript>().active = true;
        if(!gameObject.tag.Equals("Build"))
        gameObject.tag = "Build";
        push.SetActive(true);
       // if (misdatos.intLevel<1)
       // nextLevel();
    }

    public void nextLevel()
    {
        misdatos.Inc = true;
        misdatos.inicio = DateTime.Now;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Build")
        {
            free = true;
        }
    }

    private void OnDrawGizmosmoving()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {


                Gizmos.color = Color.green;
                Gizmos.DrawCube(transform.position + new Vector3(x,0,y), new Vector3(1, 0.05f, 1));
            }
        }
    }
}
