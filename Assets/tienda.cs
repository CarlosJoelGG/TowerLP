using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tienda : MonoBehaviour
{
    public List<Sprite> imagenes;
    public List<int> Casas,Minas,granjas,lenador,almacen,cuartel,ayuntamientos;
    public BD personaje;
    public List<GameObject> casasPre,nueva;
    // Start is called before the first frame update
    void Start()
    {
       // iniciar();
    }
    public void iniciar()
    {

        for (int j = 2; j < personaje.limiteCasas.Count; j++)
        {
            personaje.limiteCasas[j] = 0;
        }

        for (int i = 0; i <= personaje.people.Lv; i++)
        {
            personaje.limiteCasas[2] = personaje.limiteCasas[2] + ayuntamientos[i];

            personaje.limiteCasas[3] = personaje.limiteCasas[3] + almacen[i];
            personaje.limiteCasas[4] = personaje.limiteCasas[4] + cuartel[i];
            personaje.limiteCasas[5] = personaje.limiteCasas[5] + Casas[i];
            personaje.limiteCasas[6] = personaje.limiteCasas[6] + lenador[i];
            personaje.limiteCasas[7] = personaje.limiteCasas[7] + granjas[i];
            personaje.limiteCasas[8] = personaje.limiteCasas[8] + Minas[i];

        }
        for (int k = 0; k < casasPre.Count; k++)
        {
            if (nueva[k] != null)
            {
                Destroy(nueva[k]);
            }
            nueva[k] = new GameObject();
            if (personaje.numerodeCasas[k + 3] < personaje.limiteCasas[k + 3])
            {
                nueva[k] = Instantiate(casasPre[k]);
                nueva[k].transform.parent = transform;
                nueva[k].name = casasPre[k].name;
                nueva[k].SetActive(true);
                nueva[k].transform.localEulerAngles = new Vector3(0, 0, 0);
                nueva[k].transform.localScale = new Vector3(1f, 1f, 1f);
                nueva[k].transform.position = casasPre[k].transform.position;

            }
        }
    }
    private void Awake()
    {
       // iniciar();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
