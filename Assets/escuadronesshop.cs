using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escuadronesshop : MonoBehaviour
{
    public Text descripcion, cantidad, woodprecio, coinprecio, Nombre;
    public List<Sprite> imagenes;
    public string descripcionS;
    public Image Edificio;
    public int Id_User;
    public int precioGold, precioComida;
    public GameObject apagar;
    public int precioC=0, precioW=0, precioE=0,tipo_de_soldado=0;
    // Start is called before the first frame update
    void Start()
    {
        refresh();
    }
    public void refresh()
    {
        GameObject aux = GameObject.Find("BD");
        cantidad.text = aux.GetComponent<BD>().SoldadosEscuadrones.Count + "/" + 5;
        descripcion.text = descripcionS;
        woodprecio.text = precioW + "";
        coinprecio.text = precioC + "";
        Edificio.sprite = imagenes[tipo_de_soldado];
        
    }
    public void Action()
    {
        GameObject.Find("BD").GetComponent<BD>().VerificarSoldier(tipo_de_soldado, new Vector2(precioC, precioW));
        refresh();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
