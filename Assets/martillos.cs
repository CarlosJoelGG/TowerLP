using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class martillos : MonoBehaviour
{

    public Slider martillitos;
    public BD data;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        martillitos.maxValue = data.people.Maxconstructor;
        martillitos.value = data.people.constructor;
        texto.text = data.people.constructor + "/" + data.people.Maxconstructor;
    }
}
