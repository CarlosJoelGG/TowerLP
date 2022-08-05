using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colFlecha : MonoBehaviour
{

    public flecha Flecha;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unit")
        {
            if (other.GetComponent<UnitsAi>() != null)
            {
                Flecha.TakeDamage(other.GetComponent<UnitsAi>());

                Debug.Log("Col");
            }
        }
    }
}
