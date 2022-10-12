using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
    public List<GameObject> Objetos;
    public int indexCofre = 0;
    public GameObject Prefab;
    public BD data;
    public int Dec = 0;
    public GameObject indexDescripcion= null;
    public Text descripcion,nombre;
    public Image etiqueta;
    public List<Sprite> imagenes;
    public Sprite defaul;
    public Text Slidertexto;
    public Slider SliderLinea;
    public int Cantidad = 1;
    public GameObject SliderObjeto;
    // Start is ca lled before the first frame update
    void Start()
    {
        SliderObjeto.SetActive(false);
        Iniciar();
    }
    public void MaxMin(bool a)
    {
        if(a)
            Cantidad = indexDescripcion.GetComponent<inventarioSock>().objeto.Cantidad;
        else
            Cantidad = 0;

        refrescarCantidad();
    }
    public void refrescarCantidad()
    {
        if (indexDescripcion != null)
        {
            SliderLinea.maxValue = indexDescripcion.GetComponent<inventarioSock>().objeto.Cantidad;
        }
        SliderLinea.value = Cantidad;
        Slidertexto.text = SliderLinea.value + "";
    }
    public void cantidades(int a)
    {
        Cantidad += a;
        if (Cantidad < 0)
            Cantidad = 0;
        if (Cantidad > indexDescripcion.GetComponent<inventarioSock>().objeto.Cantidad)
        {
            Cantidad = indexDescripcion.GetComponent<inventarioSock>().objeto.Cantidad;
        }
        refrescarCantidad();
    }
    public void IndexInventario(int a)
    {
        indexCofre = a;
        resetdescripcion();
        Cantidad = 1;
        Iniciar();
    }
    public void ImagenBoton(Image b)
    {
        b.sprite = defaul;
    }
    public void PropiedadesAccion(GameObject a)
    {
        indexDescripcion = a;
        descripcion.text = a.GetComponent<inventarioSock>().objeto.descripcion+" "+RarezaRecursos(a.GetComponent<inventarioSock>().objeto.rareza);
        nombre.text = a.GetComponent<inventarioSock>().objeto.nombre;
        etiqueta.sprite = imagenes[a.GetComponent<inventarioSock>().objeto.index];
        SliderObjeto.SetActive(true);
        SliderLinea.maxValue = indexDescripcion.GetComponent<inventarioSock>().objeto.Cantidad;
        Cantidad = 1;
        refrescarCantidad();
    }

    public void resetdescripcion()
    {
        indexDescripcion = null;
        descripcion.text = "";
        nombre.text = "";
        etiqueta.sprite = defaul;
        Cantidad = 1;
        SliderObjeto.SetActive(false);
    }
    public void Usar()
    {
        if (indexDescripcion != null)
        {   for(int i=0;i<Cantidad;i++)
            indexDescripcion.GetComponent<inventarioSock>().accion();

            if (indexDescripcion.GetComponent<inventarioSock>().cantidad <= 0)
            {
                resetdescripcion();
                Iniciar();
            }
         
            refrescarCantidad();
        }
       
    }
    public int RarezaRecursos(int a)
    {
        int aux = 1;
        switch (a)
        {
            case 0://normal
                aux = 50;
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
    public void destruir()
    {
        for (int i = 0; i < Objetos.Count; i++)
        {
            Destroy(Objetos[i]);
        }
        Objetos = new List<GameObject>();
    }
    public void GestionarConsumo(int a)
    {
        
    }
    public void Iniciar()
    {
        indexDescripcion = null;
        destruir();
        int aux = 8;
        for (int i = 0; i < data.Items.Count; i++)
        {
            if (data.Items[i].Cantidad > 0 && data.Items[i].tipo==indexCofre)
            {
                
                if (aux >= 7)
                { Objetos.Add(Instantiate(Prefab));
                    Objetos[Objetos.Count-1].transform.parent = transform;
                    Objetos[Objetos.Count - 1].transform.localEulerAngles = new Vector3(0, 0, 0);
                    Objetos[Objetos.Count - 1].transform.localPosition = new Vector3(0, 0, 0);
                    Objetos[Objetos.Count - 1].transform.localScale = new Vector3(1, 1, 1);
                    aux = 0;
                }
                    
                    Objetos[Objetos.Count - 1].GetComponent<listado>().AddItem(data.Items[i]);
                    aux++;
                
            }
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
