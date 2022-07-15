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

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        mainBottons.SetActive(true);
        zoomBoton.SetActive(true);//puese el player inf y adentronel zoom
        buildingProcess.SetActive(false);
        buildBottons.SetActive(false);

    }


    public void Alertas(int a,BuildingSystem b)
    {
      //  Alerta.SetActive(true);
                Alerta.GetComponent<Alertas>().mostrar(a,b);
    }

    // Update is called once per frame
    void Update()
    {
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
}
