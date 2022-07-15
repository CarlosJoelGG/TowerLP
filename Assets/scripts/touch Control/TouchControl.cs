using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TouchControl : MonoBehaviour
{
    public List <GameObject> units;
    
    public GameObject target, targetPrefab;
    private Camera cam;
    private bool SelecUnits;
    private Plane groundPlane;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.touches[0].position);
            RaycastHit  hit;
            
            if(Physics.Raycast(ray, out hit) && Input.touches[0].phase == TouchPhase.Began)
            {
                if(hit.collider != null)
                {
                    if(hit.collider.tag == "Build")
                    {

                    }
                    else
                    {
                        if (hit.collider.tag == "Unit")
                        {
                            hit.collider.transform.GetComponent<NavegationSystem>().Selec();

                            units.Add(hit.collider.gameObject);
                            
                        }

                        if (hit.collider.tag == "ground")
                        {
                            Vector3 pos = hit.point;
                            if (target == null)
                            {
                               target =  Instantiate(targetPrefab, pos, Quaternion.identity);

                                if(units.Count >0)
                                {
                                    for( int i=0 ; i <= units.Count; i++)
                                    {
                                        units[i].GetComponent<NavegationSystem>().ChangeTarget(target.transform);
                                    }
                                }

                            }


                        }

                    }
                }
            }

            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                Destroy(target,1);
            }

            if(units.Count > 0)
            {
                SelecUnits = true;
            }
            else
            {
                SelecUnits = false;
            }

        }
        
    }
}
