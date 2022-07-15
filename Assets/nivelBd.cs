using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nivelBd : MonoBehaviour
{
    public Text textonivel;
    public BD nivel;
   
    void Update()
    {
        textonivel.text = (nivel.people.Lv+1) + "";
    }
}
