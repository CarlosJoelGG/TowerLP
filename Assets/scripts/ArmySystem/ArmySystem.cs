using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmySystem : MonoBehaviour
{
   
    public GameObject armyPrefab;// prefab
    public enum typeArmy { vikingoSoldado, vikingoArquero, goblinSimple}//tipo
    public typeArmy tipo;

    public int armyUnitsMax, units, unitsPendientes, unitsCanDo, unitsValue;//Cantidad

    public int moneyPrice, woodPrice, footPrice, diamonPrice, godsPrice;// precio

    public float currentTime, armyTime;// tiempo

    public List<Transform> armysPlace = new List<Transform>();

    public List<UnitsAi> armys = new List<UnitsAi>();



    // Start is called before the first frame update
    void Awake()
    {
        if (armyUnitsMax == 0) armyUnitsMax = 1;
        unitsPendientes = -1;

        switch (tipo)
        {
            case typeArmy.vikingoSoldado:
                moneyPrice = 10;
                footPrice = 20;
                woodPrice = 0;
                diamonPrice = 1;
                godsPrice = 0;
                armyUnitsMax = 16;
                armyTime = 1;
                break;

            case typeArmy.vikingoArquero:
                moneyPrice = 15;
                footPrice = 0;
                woodPrice = 30;
                diamonPrice = 1;
                godsPrice = 0;
                armyUnitsMax = 9;
                armyTime = 5;
                break;

            case typeArmy.goblinSimple:
                moneyPrice = 15;
                footPrice = 0;
                woodPrice = 0;
                diamonPrice = 1;
                godsPrice = 0;
                armyUnitsMax = 15;
                armyTime = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        unitsCanDo = armyUnitsMax - units;
        
        if (unitsPendientes > 0)
        {


            if(currentTime <= 0)
            {
                unitsPendientes--;
                SpwanUnits();
                if (unitsPendientes > 0)
                {
                    currentTime = armyTime;
                }
               
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }

        if(armys.Count > 0)
        {
            foreach (UnitsAi uni in armys)
            {
                if (uni == null)
                {
                    armys.Remove(uni);
                    units = armys.Count; 
                }
            }
        }
        
    }

    public void DoUnits(int count)
    {
        unitsPendientes = count;
        currentTime = armyTime;
    }

    private void SpwanUnits()
    {
        float xx = Random.Range(transform.position.x - 0.2f, transform.position.x + 2.2f);
        float zz = Random.Range(transform.position.z - 0.2f, transform.position.z + 2.2f);
        Vector3 pos = new Vector3(xx, 0, zz);

        GameObject unit = Instantiate(armyPrefab, armysPlace[units].transform.position , Quaternion.identity);

        units++;

        armys.Add(unit.GetComponent<UnitsAi>());

    }
}
