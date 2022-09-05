using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab;

    public Transform target;

    public int cantidadSpwan;

    public GameObject[] groups;
    public GameObject Mundos;
    public bool NPC = false;
    public GameObject group;
    int groupInt;

    public List<UnitsAi> units = new List<UnitsAi>();

    public SpriteRenderer marca;

    public Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {



        group = Instantiate(groups[cantidadSpwan-1], transform.position, Quaternion.identity);

        groupInt = cantidadSpwan;

        if (unitPrefab != null && cantidadSpwan > 0)
        {
            for (int i = 0; i < group.transform.childCount; i++)
            {
                var u = Instantiate(unitPrefab, group.transform.GetChild(i).position, Quaternion.identity).GetComponent<UnitsAi>();

                u.spawner = this;

                units.Add(u);
            }

        }

        if (healthBar != null)
        {
            healthBar.maxValue = units[0].vidaMax * cantidadSpwan;
            healthBar.value = units[0].vidaMax * cantidadSpwan;

        }

        Mundos = GameObject.Find("mundo");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (units.Count >= 1)
        {
            if (units.Count - 1 != groupInt)
            {
                Destroy(group.gameObject);

                group = Instantiate(groups[units.Count - 1], transform.position, Quaternion.identity);

                groupInt = units.Count - 1;

                for (int i = 0; i < units.Count; i++)
                {
                    if (units[i] == null) { units.RemoveAt(i); }

                    units[i].ChangeTarget(group.transform.GetChild(i));
                    units[i].intSpawner = i;

                }
            }

            if (units.Count == 1)
            {
                if(units[0]!=null)
                transform.position = units[0].transform.position;
            }

            if (units.Count > 1)
            {
                var bounds = new Bounds(units[0].transform.position, Vector3.zero);

                bounds.Encapsulate(units[0].transform.position);
                bounds.Encapsulate(units[units.Count - 1].transform.position);

                transform.position = bounds.center;
            }
        }





    }

    void Update()
    {
       
        



        if (marca != null)
        {



            marca.transform.parent.transform.LookAt(group.transform, Vector3.up);
            marca.size = new Vector2(Vector3.Distance(transform.position, group.transform.position), 1);


        }

        if (units.Count >= 1)
        {

            float vida = 0;

            for (int i = 0; i < units.Count; i++)
            {
                if (units[i] == null)
                {
                    units.RemoveAt(i);

                }
                else
                {
                    vida += units[i].vida;
                }
            }

            healthBar.value = vida;
        }
        else if (units.Count == 0)
        {
            Mundos.GetComponent<spawnerunits>().vidamenos(NPC);
            Destroy(gameObject);
        }
    }

    public void TargetMove(Vector3 pos)//
    {


        group.transform.position = pos;

            if (units.Count == 1)
            {
            units[0].ChangeTarget(group.transform.GetChild(0));
            transform.position = units[0].transform.position;

            }

            if (units.Count > 1)
            {
                

                for (int i = 0; i < units.Count; i++)
                {
                    if (units[i] == null) { units.RemoveAt(i); }

                    units[i].ChangeTarget(group.transform.GetChild(i));


                }


               
            }


        
    }


}
