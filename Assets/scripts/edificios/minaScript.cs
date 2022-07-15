using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minaScript : MonoBehaviour
{
    public StateInf state;

    public int level,  moneyMax, money, timeMax;
    public float plusPerSecond;
    public bool active;

    public GameObject collec;
    BuildingSystem build;

    // Start is called before the first frame update
    void Start()
    {
        if (state == null) state = GetComponent<StateInf>();

        build = GetComponent<BuildingSystem>();

        level = state.intLevel;

        switch (level)
        {
            case 0:
                level = 1;
                break;

            case 1:           
                moneyMax = 300;
                timeMax = 300;
                break;

            case 2:               
                moneyMax = 500;
                timeMax = 500;
                break;

            case 3:               
                moneyMax = 1000;
                timeMax = 1000;
                break;

            case 4:               
                moneyMax = 1700;
                timeMax = 1700;
                break;

            case 5:                
                moneyMax = 2800;
                timeMax = 2800;
                break;
        }

        collec.SetActive(false);



    }

    private void Update()
    {
        if (active)
        {
            if (build.timeBuildRestante <= 0)
            {


                if (build.noRender)
                {

                    plusPerSecond += Time.deltaTime;
                }
            }
        }

        money = Mathf.FloorToInt(plusPerSecond);

        if (money > 10)
        {
            collec.SetActive(true);
        }
        if ( money <= 10)
        {
            collec.SetActive(false);
        }
    }

    public void CollecAll()
    {
        var player = FindObjectOfType<playerSystem>();

       if (player.mina.Count == 1)
        {
            player.mina[0].Collec(player);
        }
        if (player.mina.Count == 2)
        {
            player.mina[0].Collec(player);
            player.mina[1].Collec(player);
        }
        if (player.mina.Count == 3)
        {
            player.mina[0].Collec(player);
            player.mina[1].Collec(player);
            player.mina[2].Collec(player);
        }
        if (player.mina.Count == 4)
        {
            player.mina[0].Collec(player);
            player.mina[1].Collec(player);
            player.mina[2].Collec(player);
            player.mina[3].Collec(player);
        }


    }

    void Collec(playerSystem player)
    {
        player.money += money;
        money = 0;
        plusPerSecond = 0;
    }
}
