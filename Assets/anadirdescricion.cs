using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anadirdescricion : MonoBehaviour
{
    public List<string> descripciones;
    public List<Sprite> descImagenes;
    public GameObject texto, Imagen,pie;
    public List<GameObject> des,indes;
    public GameObject padre;
    public GameObject BDdata;
    private bool OnOff = false;
    public GameObject botonbajar;
    public GameObject guia;
    public Misiones datos;
    public string titulotexto;
    public Text Titulo,Rango;
    public GameObject completar;
    // Start is called before the first frame update
    void Start()
    {
        Titulo.text = titulotexto;
      /*  if (datos.idR == 0)
        { Rango.text = "T"; }
        else
        Rango.text = datos.idR+"";*/
        string a = datastring();
        BDdata = GameObject.Find("BD");
        pie.GetComponent<accionPie>().textopie = a;
    }
    public string datastring()
    {
        string a = "";
        switch (datos.idR)
        {
            case 0:///Recursos
                switch (datos.idR_H)
                {
                    case 0://oro
                        a = "Recolecta " + datos.meta + " de oro";
                        break;
                    case 1://comida
                        a = "Recolecta " + datos.meta + " de Comida";
                        break;
                    case 2:// madera
                        a = "Recolecta " + datos.meta + " de Madera";
                        break;
                }
                break;
            case 1:///Edificios
                switch (datos.idR_H)
                {
                    case 0://Mina
                        a = "Contruye " + datos.meta + " Mina/as";
                        break;
                    case 1://granja
                        a = "Contruye " + datos.meta + " Granja/as";
                        break;
                    case 2://aserradero
                        a = "Contruye " + datos.meta + " Aserradero/os";
                        break;
                }
                break;
            case 2://batallas
              
                break;
        }

        return a;
    }
    public void introducir_progreso(int a)
    {
        switch (datos.idR)
        {
            case 0:///Recursos
                anadirProgreso(a);
                break;
            case 1:///Edificios
                actualizarprogreso(a);
                break;
            case 2://batallas
                anadirProgreso(a);
                break;
        }
    }
    public void anadirProgreso(int a)
    {
        datos.progreso += a;
        this.gameObject.transform.parent.gameObject.GetComponent<generarmisiones>().upMision(datos);
    }
    public void actualizarprogreso(int a)
    {
        datos.progreso = a;
        this.gameObject.transform.parent.gameObject.GetComponent<generarmisiones>().upMision(datos);
    }
    public void Completar()
    {
        datos.completada = true;
        eliminarimagenes();
        Evaluar();
        this.gameObject.transform.parent.gameObject.GetComponent<generarmisiones>().reclamar_Recompensa(datos.reward);
        this.gameObject.transform.parent.gameObject.GetComponent<generarmisiones>().upMision(datos);
    }
    public void Evaluar()
    {
        if (datos.completada)
        {
            botonbajar.SetActive(false);
        }
    }
    public void In(Misiones a)
    {
        datos = a;
        Evaluar();
    }
    public void examinar()
    {
        if (OnOff)
        {
            OnOff = false;
            eliminarimagenes();
            botonbajar.SetActive(true);
            //guia.SetActive(false);
        }
        else
        {
            OnOff = true;
            desplegarImagenes();
            botonbajar.SetActive(false);
            //guia.SetActive(true);
        }
        
    }
    public void desplegarImagenes()
    {
        for (int i = 0; i < descripciones.Count; i++)
        {
            texto.GetComponent<Text>().text = descripciones[i];
            Debug.Log(descripciones[i]);
            if (descImagenes.Count > i)
            {
                Imagen.GetComponent<Image>().sprite = descImagenes[i];
                Imagen.GetComponent<Image>().SetNativeSize();
                if (Imagen.GetComponent<Image>().rectTransform.sizeDelta.x > 240)
                {
                    Imagen.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(240, 240);
                }
                Imagen.GetComponent<Image>().color = Color.white;

            }
            des.Add(Instantiate(texto));
            des[i].transform.parent = this.transform;
            des[i].transform.localEulerAngles = new Vector3(0, 0, 0);
            des[i].transform.localScale = new Vector3(1, 1, 1);
            indes.Add(Instantiate(Imagen));
            indes[i].transform.parent = this.transform;
            indes[i].transform.localEulerAngles = new Vector3(0, 0, 0);
            indes[i].transform.localScale = new Vector3(1, 1, 1);

        }
        des.Add(Instantiate(pie));
        des[des.Count-1].transform.parent = this.transform;
        des[des.Count - 1].transform.localEulerAngles = new Vector3(0, 0, 0);
        des[des.Count - 1].transform.localScale = new Vector3(1, 1, 1);

    }
    public void eliminarimagenes()
    {
        for (int i = 0; i < des.Count;i++)
        {
            Destroy(des[i]);
        }
        for (int i = 0; i < indes.Count; i++)
        {
            Destroy(indes[i]);
        }
        des = new List<GameObject>();
        indes = new List<GameObject>();


    }

    public void CompletarAccion()
    {
        datos.completada = true;
        BDdata.GetComponent<BD>().updatemision(datos);
        string[] a = datos.reward.Split('-');
        for (int i = 0; i < 3; i++)
        { 
            BDdata.GetComponent<BD>().AddRecursos(i,int.Parse(a[i]));
        }
       
        
            transform.parent.gameObject.GetComponent<generarmisiones>().iniciar();
    }
    // Update is called once per frame
    void Update()
    {
        Canvas.ForceUpdateCanvases();  // *
        this.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = false; // **
        this.transform.parent.GetComponent<VerticalLayoutGroup>().enabled = true;

        switch (datos.idR)
        {
            case 0:///Recursos
                break;
            case 1:///edificios
                int a = BDdata.GetComponent<BD>().numerodeCasas[datos.idR_H];
                introducir_progreso(a);
                if (datos.progreso >= datos.meta)
                {
                    completar.SetActive(true);
                }
                break;
            case 2://batallas
                break;
        }
    }
}
