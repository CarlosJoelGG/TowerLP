using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rectscrollcontrol : MonoBehaviour
{

    public List<RectTransform> contenido;
    public ScrollRect scroll;
    public List<Image> botones;
    public List<Sprite> OverBotones;
    //public Image Ibotones;
    public Color claro, oscuro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void contenidos(int a)
    {
        for (int i = 0; i < contenido.Count; i++)
        {
            if (i == a)
            {
                contenido[i].transform.gameObject.SetActive(true);
                scroll.content = contenido[i];
                botones[i].sprite = OverBotones[i];
                //botones[i].color = claro;
            }
            else
            { 
                contenido[i].transform.gameObject.SetActive(false);
                botones[i].sprite = OverBotones[i + contenido.Count];
                //botones[i].color = oscuro;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
