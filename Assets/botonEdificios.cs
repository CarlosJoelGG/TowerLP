using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class botonEdificios : MonoBehaviour
{


    public BuildingSystem Data;
    public Text descripcion, cantidad, woodprecio, coinprecio, Nombre;
    public List<Sprite> imagenes;
    public Image Edificio;

    public void Action()
    {
       
        GameObject.Find("BD").GetComponent<BD>().Verificar(Data.gameObject.GetComponent<StateInf>().id,new Vector2(Data.gameObject.GetComponent<StateInf>().MoneyPrice, Data.gameObject.GetComponent<StateInf>().WoodPrice));
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject aux = GameObject.Find("BD");
        cantidad.text = aux.GetComponent<BD>().numerodeCasas[Data.gameObject.GetComponent<StateInf>().id] + "/" + aux.GetComponent<BD>().limiteCasas[Data.gameObject.GetComponent<StateInf>().id];
        descripcion.text = Data.gameObject.GetComponent<StateInf>().descripcion;
        woodprecio.text = Data.gameObject.GetComponent<StateInf>().WoodPrice+"";
        coinprecio.text = Data.gameObject.GetComponent<StateInf>().MoneyPrice + "";
        Edificio.sprite = imagenes[Data.gameObject.GetComponent<StateInf>().id];


    }
    private void Awake()
    {
        GameObject aux = GameObject.Find("BD");
        cantidad.text = aux.GetComponent<BD>().numerodeCasas[Data.gameObject.GetComponent<StateInf>().id] + "/" + aux.GetComponent<BD>().limiteCasas[Data.gameObject.GetComponent<StateInf>().id];
        descripcion.text = Data.gameObject.GetComponent<StateInf>().descripcion;
        woodprecio.text = Data.gameObject.GetComponent<StateInf>().WoodPrice + "";
        coinprecio.text = Data.gameObject.GetComponent<StateInf>().MoneyPrice + "";
        Edificio.sprite = imagenes[Data.gameObject.GetComponent<StateInf>().id];
    }
    // Update is called once per frame
    void Update()
    {if(!Nombre.text.Equals(name))
        Nombre.text = name + "";
        GameObject aux = GameObject.Find("BD");
        cantidad.text = aux.GetComponent<BD>().numerodeCasas[Data.gameObject.GetComponent<StateInf>().id] + "/" + aux.GetComponent<BD>().limiteCasas[Data.gameObject.GetComponent<StateInf>().id];
    }
}
