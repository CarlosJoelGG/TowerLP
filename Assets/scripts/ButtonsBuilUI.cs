using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsBuilUI : MonoBehaviour
{
    public Info edfi;
    public playerSystem player;

    [Header("informacion ")]
    public Text NameText, InfoText, MoneyCostText, WoodCostText;
    public Image image;

    public GameObject prefab;
    public int MoneyCost, WoodCost;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = edfi.sprite;
        NameText.text = edfi.nombre;
        InfoText.text = edfi.info;
        //MoneyCostText.text = edfi.moneyCost+"";
       // WoodCostText.text = edfi.woodCost + "";

        //Values
        prefab = edfi.prefab;
       // MoneyCost = edfi.moneyCost;
        //WoodCost = edfi.woodCost;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
