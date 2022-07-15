using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public int index = 0;
    public List<GameObject> partes;
    public void siguientepaso()
    {
        index++;
        partes[index].SetActive(true);
        partes[index - 1].SetActive(false);        
    }
}
