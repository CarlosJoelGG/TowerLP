using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetList : MonoBehaviour
{
    public List<UnitsAi> units = new List<UnitsAi>();
    float delay= 0.2f;

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            if (units.Count == 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
