using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxConfiguration : MonoBehaviour
{
    public Sprite vacio, Relleno;
    public Image imagen;
    public musica data;
    public bool onoff = true;
    public int funcion = 0;
    public Slider efectos, musica;
    // Start is called before the first frame update

    private void Awake()
    {
        if(efectos!=null)
        efectos.onValueChanged.AddListener(data.volumenEfectos);
        if(musica!=null)
        musica.onValueChanged.AddListener(data.volumenMusica);
    }
    void Start()
    {
        data = GameObject.Find("musica").GetComponent<musica>();
    }
    public void inicio()
    {
        switch (funcion)
        {
            case 0:
                data.muteMusic();
                break;
            case 1:
                data.muteSFX();
                break;
        }
        if (onoff)
        {
            onoff = false;
            imagen.sprite = vacio;
        }
        else
        {
            onoff = true;
            imagen.sprite = Relleno;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
