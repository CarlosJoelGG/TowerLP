using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escuadronesshop : MonoBehaviour
{
    public Text descripcion, cantidad, woodprecio, coinprecio, Nombre;
    public List<Sprite> imagenes;
    public Image Edificio;
    public int Id_User;
    public int precioGold, precioComida;
    public GameObject apagar;
    // Start is called before the first frame update
    void Start()
    {
        refresh();
    }
    public void refresh()
    {
        GameObject aux = GameObject.Find("BD");
        cantidad.text = aux.GetComponent<BD>().SoldadosEscuadrones.Count + "/" + 5;
        descripcion.text = "Soldado Razo de a pie";
        woodprecio.text = 200 + "";
        coinprecio.text = 350 + "";
        Edificio.sprite = imagenes[0];
        
    }
    public void Action()
    {
        GameObject.Find("BD").GetComponent<BD>().VerificarSoldier(0, new Vector2(350, 200));
        refresh();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
