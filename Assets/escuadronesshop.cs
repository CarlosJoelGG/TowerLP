using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escuadronesshop : MonoBehaviour
{
    public Text descripcion, cantidad, woodprecio, coinprecio, Nombre;
    public List<Sprite> imagenes;
    public string descripcionS,Name="";
    public Image Edificio;
    public int Id_User;
    public int precioGold, precioComida;
    public int index = 0;
    public escuadron datos;
    public GameObject apagar;
    public int precioC=0, precioW=0, precioE=0,tipo_de_soldado=0;
    public GameObject Bd;
    // Start is called before the first frame update
    void Start()
    {
        Bd = GameObject.Find("BD");
        refresh();
    }
    public void llenar(escuadron a)
    {
        datos = a;
        descripcionS = a.descripcion;
        string[] b = a.precio.Split('-');
        precioW = int.Parse(b[2]);
        precioC = int.Parse(b[0]);
        tipo_de_soldado = a.index;
        Name = a.Nombre;
        Edificio.sprite = imagenes[tipo_de_soldado];
     
    }
    public void refresh()
    {
        int aux2 = 0;
        GameObject aux = GameObject.Find("BD");
        for (int i = 0; i < aux.GetComponent<BD>().SoldadosEscuadrones.Count; i++)
        {
            aux2 += aux.GetComponent<BD>().SoldadosEscuadrones[i].cantidad;
        }
        cantidad.text = aux2 + "/" + 5;
        descripcion.text = descripcionS;
        woodprecio.text = precioW + "";
        coinprecio.text = precioC + "";
        Edificio.sprite = imagenes[tipo_de_soldado];
        Nombre.text = Name;
        
    }
    public void Action()
    {
        GameObject.Find("BD").GetComponent<BD>().VerificarSoldier(tipo_de_soldado, new Vector2(precioC, precioW));
       // refresh();
    }
    // Update is called once per frame
    void Update()
    {
        refresh();
    }
}
