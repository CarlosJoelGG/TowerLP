using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSystem : MonoBehaviour
{


    public int level, exp, food, foodMax, money, moneyMax, wood, woodMax, cash, conquestPoint, energy, energyMax, hammer, hammerMax;
    public string playerName;
    public string playerID;
    private bool check;
    private float timeCheck = 0.5f;
    [Header("Almacenes")]
    public List<almacenScript> almacenes = new List<almacenScript>();
    [Header("Minas")]
    public List<minaScript> mina = new List<minaScript>();
    public List<granjaScript> granja = new List<granjaScript>();
    public List<carpinteriaScript> carpinteria = new List<carpinteriaScript>();
    public List<UnitsAi> units = new List<UnitsAi>();


    private void Start()
    {
        if (level == 0) level = 1;
    }
    // Update is called once per frame
    void Update()
    {

        #region comprobar valores maxinmos

        if (timeCheck > 0)
        {
            timeCheck -= Time.deltaTime;
        }
        if (timeCheck <= 0 )
        {
            check = true;
        }

        if (check)
        {
            if (food > foodMax) food = foodMax;

            if (money > moneyMax) money = moneyMax;

            if (wood > woodMax) wood = woodMax;

            if (energy > energyMax) energy = energyMax;

            if (hammer > hammerMax) hammer = hammerMax;

        }


        #endregion

        #region Units


        #endregion
    }

}
