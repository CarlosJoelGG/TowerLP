using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SriteUnits : MonoBehaviour
{
    
    SpriteRenderer sprite;

    public NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.rotation = Quaternion.Euler(-30, transform.parent.transform.rotation.y+45, 0);

        

    }
}
