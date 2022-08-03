using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarmisiones : MonoBehaviour
{
    public BD data;
    public List<Misiones> listaM=new List<Misiones>();
    public List<GameObject> MisionesListaObjeto;
    public List<GameObject> ML=new List<GameObject>();
    public int index=0;
    // Start is called before the first frame update
    void Start()
    {
        listaM= data.getmisiones();
        for (int i = 0+(3*index); i < 3+(3*index); i++)
        {
            
            ML.Add(Instantiate(MisionesListaObjeto[listaM[i].tipo]));
            ML[i].GetComponent<anadirdescricion>().In(listaM[i]);
            ML[i].transform.parent = this.transform;
            ML[i].transform.localEulerAngles = new Vector3(0, 0, 0);
            ML[i].transform.localScale = new Vector3(1, 1, 1);

        }
    }
    public void reclamar_Recompensa(string a)
    {
        string[] b = a.Split('-');
        data.AddRecursos(0, int.Parse(b[0]));
        data.AddRecursos(1, int.Parse(b[1]));
        data.AddRecursos(2, int.Parse(b[2]));
        data.RefrescarUsuario();
    }
    public void upMision(Misiones a)
    {
        data.updatemision(a);
    }

    public void tomarAumento(int progreso, int tipo,int clase)
    {
        for (int i = 0; i < ML.Count; i++)
        {
            if (ML[i].GetComponent<anadirdescricion>().datos.idR==tipo)
            {
                if (ML[i].GetComponent<anadirdescricion>().datos.idR_H == clase)
                { 
                    ML[i].GetComponent<anadirdescricion>().introducir_progreso(progreso); 
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
