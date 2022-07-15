using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granjaScript : MonoBehaviour
{
    public StateInf state;

    public int level, foodMax, food, timeMax;
    public float plusPerSecond;

    public GameObject collec;

    public bool active;
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
                foodMax = 300;
                timeMax = 300;
                break;

            case 2:
                foodMax = 500;
                timeMax = 500;
                break;

            case 3:
                foodMax = 1000;
                timeMax = 1000;
                break;

            case 4:
                foodMax = 1700;
                timeMax = 1700;
                break;

            case 5:
                foodMax = 2800;
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
        food = Mathf.FloorToInt(plusPerSecond);

        if (food > 10)
        {
            collec.SetActive(true);
        }
        if (food <= 10)
        {
            collec.SetActive(false);
        }
    }

    public void CollecAll()
    {
        var player = FindObjectOfType<playerSystem>();

        if (player.granja.Count == 1)
        {
            player.granja[0].Collec(player);
        }
        if (player.granja.Count == 2)
        {
            player.granja[0].Collec(player);
            player.granja[1].Collec(player);
        }
        if (player.mina.Count == 3)
        {
            player.granja[0].Collec(player);
            player.granja[1].Collec(player);
            player.granja[2].Collec(player);
        }
        if (player.mina.Count == 4)
        {
            player.granja[0].Collec(player);
            player.granja[1].Collec(player);
            player.granja[2].Collec(player);
            player.granja[3].Collec(player);
        }


    }

    void Collec(playerSystem player)
    {
        player.food += food;
        food = 0;
        plusPerSecond = 0;
    }
}
