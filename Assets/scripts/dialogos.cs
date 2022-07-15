using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogos : MonoBehaviour
{
    public Text mensaje;
    public GameObject Escena;
    public List<string> textos;
    public int index = 0;
    public GameObject Encender;
    // Start is called before the first frame update
    void Start()
    {
        NextTexto();
    }

    public void NextTexto()
    {
        if (index < textos.Count)
        {
            StopAllCoroutines();
            StartCoroutine( Mostrar(textos[index]));

            index++;
        }
        else
        {
            Escena.GetComponent<Animator>().Play("bajar");
            index = 0;
            Encender.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Mostrar(string a)
    {
        mensaje.text = "";
        foreach (char c in a.ToCharArray())
        {
            mensaje.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
