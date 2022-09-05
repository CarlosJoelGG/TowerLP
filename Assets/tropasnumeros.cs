using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tropasnumeros : MonoBehaviour
{
    public int index = 0;
    public Text numero;
    public int cantidad = 0;
    public GameObject uni;
    // Start is called before the first frame update
    void Start()
    {
       // cantidad = uni.GetComponent<unidadesEnElMundo>().count[index];
    }

    // Update is called once per frame
    void Update()
    {
        cantidad = uni.GetComponent<unidadesEnElMundo>().count[index];
        numero.text = "" + cantidad;
    }
}
