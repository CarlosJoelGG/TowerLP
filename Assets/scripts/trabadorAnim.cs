using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trabadorAnim : MonoBehaviour
{
    public Animator anim;
    [Range(0,3)]
    public int tipe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        if(anim != null)
        {
            if(anim.GetInteger("Tipe")!=tipe)
            anim.SetInteger("Tipe", tipe);
        }*/
    }
}
