using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavegationSystem : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agente;
    public bool selected;
    public int faction;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agente.destination = target.position;
        }
        

    }
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;

    }
    public void Selec()
    {
        selected = true;

    }

    public void DesSelec()
    {
        selected = false;

    }

}
