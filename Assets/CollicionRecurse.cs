using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollicionRecurse : MonoBehaviour
{

    public int Col,objeticos=0;
    public bool test;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            switch (Col)
            {
                case 0:
                    if (other.tag.Equals("piedra"))
                    {
                        if (transform.parent.GetComponent<BuildingSystem>().moving || !transform.parent.GetComponent<BuildingSystem>().misdatos.Inc) { 
                        transform.parent.GetComponent<carpinteriaScript>().NC += 3;

                        other.GetComponent<madera>().TrabajadorOn();
                        if (test)
                        {
                            other.GetComponent<madera>().on = true;
                        }
                    }

                    }
                    break;
                case 1:
                    if (other.tag.Equals("arbustos"))
                    {
                        if (transform.parent.GetComponent<BuildingSystem>().moving || !transform.parent.GetComponent<BuildingSystem>().misdatos.Inc)
                        {
                            transform.parent.GetComponent<carpinteriaScript>().NC++;
                            other.GetComponent<madera>().TrabajadorOn();
                            if (test)
                            {
                                other.GetComponent<madera>().on = true;
                            }
                        }
                    }
                    break;
                case 2:
                    if (other.tag.Equals("madera"))
                    {
                        if (transform.parent.GetComponent<BuildingSystem>().moving || !transform.parent.GetComponent<BuildingSystem>().misdatos.Inc)
                        {
                            transform.parent.GetComponent<carpinteriaScript>().NC++;
                            other.GetComponent<madera>().TrabajadorOn();
                            if (test)
                            {
                                other.GetComponent<madera>().on = true;
                            }
                        }
                    }
                    break;
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {

            switch (Col)
            {
                case 0:
                    if (other.tag.Equals("piedra"))
                    {
                        if (transform.parent.GetComponent<BuildingSystem>().moving || !transform.parent.GetComponent<BuildingSystem>().misdatos.Inc)
                        {
                            transform.parent.GetComponent<carpinteriaScript>().NC -= 3;
                            other.GetComponent<madera>().TrabajadorOff();
                            if (test)
                            {
                                other.GetComponent<madera>().on = true;
                            }
                        }
                    }
                    break;
                case 1:
                    if (other.tag.Equals("arbustos"))
                    {
                        if (transform.parent.GetComponent<BuildingSystem>().moving || !transform.parent.GetComponent<BuildingSystem>().misdatos.Inc)
                        {
                            transform.parent.GetComponent<carpinteriaScript>().NC--;
                            other.GetComponent<madera>().TrabajadorOff();
                            if (test)
                            {
                                other.GetComponent<madera>().on = true;
                            }
                        }
                    }
                    break;
                case 2:
                    if (other.tag.Equals("madera"))
                    {
                        if (transform.parent.GetComponent<BuildingSystem>().moving || !transform.parent.GetComponent<BuildingSystem>().misdatos.Inc)
                        {
                            transform.parent.GetComponent<carpinteriaScript>().NC--;
                            other.GetComponent<madera>().TrabajadorOff();
                            if (test)
                            {
                                other.GetComponent<madera>().on = true;
                            }
                        }
                    }
                    break;
            }

        }
    }
}
