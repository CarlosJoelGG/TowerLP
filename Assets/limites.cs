using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limites : MonoBehaviour
{
    public CamaraMove gestor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colision");
    }
    private void OnCollisionExit(Collision collision)
    {

    }
    private void OnCollisionStay(Collision collision)
    {

    }
  
}
