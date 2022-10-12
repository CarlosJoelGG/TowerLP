using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [Header("botones")]
    public GameObject buildBottons, mainBottons, buildingProcess, zoomBoton;
    [Header ("edificios")]
    public GridBuildingSystem build;

    public Text moneyText, woodText, foodText, moneyText2, woodText2, foodText2;
    public Slider moneySlider, woodSlider, foodSlider;

    public playerSystem player;
    public CamaraMove camMove;
    public GameObject Alerta;

    public float xFood, xWood, xMoney;

    [Header("RecuseSlider")]
    public valueslider moneySC, woodSC, foodSC;

    [Header("RecuseAnimator")]
    public Text moneyTextA, woodTextA, foodTextA;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        mainBottons.SetActive(true);
        zoomBoton.SetActive(true);//puese el player inf y adentronel zoom
        buildingProcess.SetActive(false);
        buildBottons.SetActive(false);

/*
        xMoney = moneySC.puntos;
        xFood = foodSC.puntos;
        xWood = woodSC.puntos;
*/
    }


    public void Alertas(int a,BuildingSystem b)
    {
      //  Alerta.SetActive(true);
                Alerta.GetComponent<Alertas>().mostrar(a,b);
    }
    public void GestorIr()
    {
        Alerta.GetComponent<Alertas>().mostrar(5, null);
    }
    public void GestorTropasIr()
    {
        Alerta.GetComponent<Alertas>().mostrar(6, null);
    }
    // Update is called once per frame
    void Update()
    {
        /*
        //UI principal
        moneyText.text = player.money+ "";
        woodText.text = player.wood + "";
        foodText.text = player.food + "";

        moneySlider.maxValue = player.moneyMax;
        woodSlider.maxValue = player.woodMax;
        foodSlider.maxValue = player.foodMax;

        moneySlider.value = player.money;
        woodSlider.value = player.wood;
        foodSlider.value = player.food;

        //Ui Marquet
        moneyText2.text = player.money + "";
        woodText2.text = player.wood + "";
        foodText2.text = player.food + "";
        */

        
    }

    void LateUpdate()
    {/*
        if (xMoney != moneySC.puntos)
        {

            MoneyChange((moneySC.puntos - xMoney));
            xMoney = moneySC.puntos;
            Debug.Log("money");
        }

        if (xFood != foodSC.puntos)
        {

            FoodChange((foodSC.puntos - xFood));
            xFood = foodSC.puntos;
            Debug.Log("food");
        }

        if (xWood != woodSC.puntos)
        {

            WoodChange((woodSC.puntos - xWood));
            xWood = woodSC.puntos;
            Debug.Log("wood");
        }*/
    }



        public void MainUi()
    {
        camMove.move = true;
        zoomBoton.SetActive(true);
        mainBottons.SetActive(true);
        buildingProcess.SetActive(false);
        buildBottons.SetActive(false);
    }
    
    //Market 
    public void BuildBottonsUi()
    {
        mainBottons.SetActive(false);
        buildingProcess.SetActive(false);
        buildBottons.SetActive(true);
        zoomBoton.SetActive(false);
        camMove.move = false;
    }

    //Construyendo
    public void BuildingUi()
    {
        camMove.move = true;
        mainBottons.SetActive(false);
        buildingProcess.SetActive(true);
        buildBottons.SetActive(false);
        zoomBoton.SetActive(true);
    }

   

    private void MoneyChange(float valor)//1
    {

        Debug.Log("money1");

        if (valor > 0)
        {
            moneyTextA.GetComponent<Text>().text = "+" + valor;
            moneyTextA.GetComponent<Animator>().SetTrigger("mas");
            Debug.Log("money +" + valor);
        }
        else
        {
            moneyTextA.GetComponent<Text>().text = ""+ valor;
            moneyTextA.GetComponent<Animator>().SetTrigger("menos");
            Debug.Log("money " + valor);
        }

       
    }

    private void FoodChange(float valor)//2
    {

        Debug.Log("food1");
        if (valor > 0)
        {
            foodTextA.GetComponent<Text>().text = "+" + valor;
            foodTextA.GetComponent<Animator>().SetTrigger("mas");
            Debug.Log("food +" + valor);
        }
        else
        {
            foodTextA.GetComponent<Text>().text = "" + valor;
            foodTextA.GetComponent<Animator>().SetTrigger("menos");
            Debug.Log("food " + valor);

        }
       
    }

    private void WoodChange(float valor)//3
    {
        Debug.Log("wood1");
        if (valor > 0)
        {
            woodTextA.GetComponent<Text>().text = "+" + valor;
            woodTextA.GetComponent<Animator>().SetTrigger("mas");
            Debug.Log("wood +" + valor);
        }
        else
        {
            woodTextA.GetComponent<Text>().text = "" + valor;
            woodTextA.GetComponent<Animator>().SetTrigger("menos");
            Debug.Log("wood " + valor);

        }
        
    }
}
