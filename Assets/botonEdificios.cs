using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class botonEdificios : MonoBehaviour
{


    public BuildingSystem Data;
    public Text descripcion, cantidad, woodprecio, coinprecio, Nombre,Tproduce,Talmacenamiento;
    public List<Sprite> imagenes,ImgProduce;
    public Image Edificio,Produce,Almacenamiento;
    public Color marron, marronclaro, dorado;

    public void Action()
    {
       
        GameObject.Find("BD").GetComponent<BD>().Verificar(Data.gameObject.GetComponent<StateInf>().id,new Vector2(Data.gameObject.GetComponent<StateInf>().MoneyPrice, Data.gameObject.GetComponent<StateInf>().WoodPrice));
    }

    // Start is called before the first frame update
    void Start()
    {

        refreshArt();

    }
    public void refreshArt()
    {
        GameObject aux = GameObject.Find("BD");
        cantidad.text = aux.GetComponent<BD>().numerodeCasas[Data.gameObject.GetComponent<StateInf>().id] + "/" + aux.GetComponent<BD>().limiteCasas[Data.gameObject.GetComponent<StateInf>().id];

        descripcion.text = Data.gameObject.GetComponent<StateInf>().descripcion;

        woodprecio.text = Data.gameObject.GetComponent<StateInf>().WoodPrice + "";

        coinprecio.text = Data.gameObject.GetComponent<StateInf>().MoneyPrice + "";

        Edificio.sprite = imagenes[Data.gameObject.GetComponent<StateInf>().id];
        if (Data.gameObject.GetComponent<StateInf>().id == 8 || Data.gameObject.GetComponent<StateInf>().id == 6 || Data.gameObject.GetComponent<StateInf>().id == 7)
        {
            Tproduce.text = "+5";
            switch (Data.gameObject.GetComponent<StateInf>().id)
            {
                case 8://ayuntamiento // coin
                    Produce.sprite = ImgProduce[1];
                    Tproduce.color = dorado;
                    Almacenamiento.sprite= ImgProduce[10];
                    Talmacenamiento.color = dorado;
                    break;
                case 6://almacen // wood
                    Produce.sprite = ImgProduce[3];
                    Almacenamiento.sprite = ImgProduce[11];
                    Tproduce.color = marron;
                    Talmacenamiento.color = marron;
                    break;
                case 7://food ///granja
                    Produce.sprite = ImgProduce[5];
                    Almacenamiento.sprite = ImgProduce[12];
                    Tproduce.color = marronclaro;
                    Talmacenamiento.color = marronclaro;
                    break;
            }
        }
        if (Data.gameObject.GetComponent<StateInf>().id == 3 || Data.gameObject.GetComponent<StateInf>().id == 2 || Data.gameObject.GetComponent<StateInf>().id == 5)
        {
            Talmacenamiento.text = "+" + Data.GetComponent<almacenScript>().recursoanadido;
            switch (Data.gameObject.GetComponent<StateInf>().id)
            {
                case 2://ayuntamiento // coin
                    Almacenamiento.sprite = ImgProduce[0];
                    Produce.sprite = ImgProduce[10];
                    break;
                case 3://almacen // wood
                    Almacenamiento.sprite = ImgProduce[2];
                    Produce.sprite = ImgProduce[11];
                    break;
                case 5://food ///granja
                    Almacenamiento.sprite = ImgProduce[4];
                    Produce.sprite = ImgProduce[12];
                    break;
            }
        }
    }
    private void Awake()
    {
        refreshArt();
    }
    // Update is called once per frame
    void Update()
    {if(!Nombre.text.Equals(name))
        Nombre.text = name + "";
        GameObject aux = GameObject.Find("BD");
        cantidad.text = aux.GetComponent<BD>().numerodeCasas[Data.gameObject.GetComponent<StateInf>().id] + "/" + aux.GetComponent<BD>().limiteCasas[Data.gameObject.GetComponent<StateInf>().id];
    }
}
