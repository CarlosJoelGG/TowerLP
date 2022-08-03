using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventarioSock : MonoBehaviour
{
    public string nama, descripcion;
    public int index;
    public int cantidad=0;
    public List<Sprite> imagenes;
    public int contenido = 0;
    public Image item_imagen;
    public GameObject data;
    public int rareza = 0;
    public Text nombre, descip,canti,conte;
    public List<Color> colores;
    public Image fondi;
    public Item objeto;

    // Start is called before the first frame update
    void Start()
    {
        Iniciar();
    }

    public void Iniciar()
    {//data.GetComponent<BD>();
        data = GameObject.Find("BD");
        nombre.text = nama;
        descip.text = descripcion;
        item_imagen.sprite = imagenes[index];
        llenarcontenido();
        canti.text = "" + cantidad;
        conte.text = "" + contenido;
        fondi.color = colores[rareza];
    }
    public void LlenarObjeto(Item a)
    {
        index = a.index;
        nama = a.nombre;
        descripcion = a.descripcion;
        rareza = a.rareza;
        cantidad = a.Cantidad;
        objeto = a;
        Iniciar();
    }
    public int RarezaRecursos(int a)
    {
        int aux = 1;
        switch (a)
        {
            case 0://normal
                aux= 50;
                break;
            case 1://raro
                aux = 500;
                break;
                
            case 2://epico
                aux = 1000;
                break;
        }
        return aux;
    }
    public int RarezaSoldados(int a)
    {
        int aux = 1;
        switch (a)
        {
            case 0://normal
                aux = 1;
                break;
            case 1://raro
                aux = 5;
                break;

            case 2://epico
                aux = 10;
                break;
        }
        return aux;
    }
    public void llenarcontenido()
    {
        switch (index)
        {
            case 0://coins
                contenido = RarezaRecursos(rareza);
                break;
            case 2://madera
                contenido = RarezaRecursos(rareza);
                break;
            case 1://comida
                contenido = RarezaRecursos(rareza);
                break;
            case 3://soldado Razo
                contenido = RarezaSoldados(rareza);
                break;
        }

    }
    public void mensajeError()
    {
        gameObject.transform.parent.gameObject.GetComponent<mensajes>().alerta();

    }
    public void accion()
    {
        if (cantidad > 0)
        {
            switch (index) 
            {
                case 0://coins
                    if (data.GetComponent<BD>().verificarCoins(contenido))
                    {
                        cantidad--;
                    }
                    else
                    {
                        mensajeError();
                 
                    }
                    break;
                case 2://madera
                    if (data.GetComponent<BD>().verificarMadera(contenido))
                    {
                        cantidad--;
                    }
                    else
                    {
                        mensajeError();
                    }
                    break;
                case 1://comida
                    if (data.GetComponent<BD>().verificarRecursos(contenido))
                    {
                        cantidad--;
                    }
                    else
                    {
                        mensajeError();
                    }
                    break;
                case 3://soldados
                    if (data.GetComponent<BD>().verificarSoldados(contenido))
                    {
                        cantidad--;
                    }
                    else
                    {
                        mensajeError();
                    }
                    break;

            }
          
        }
        objeto.Cantidad = cantidad;
        data.GetComponent<BD>().refrescarItem(objeto);
        gameObject.transform.parent.gameObject.GetComponent<Cofre>().Iniciar();
    }
    // Update is called once per frame
    void Update()
    {
        descip.text = descripcion + " " + contenido;
        canti.text = "" + cantidad;
        conte.text = "" + contenido;
    }
}
