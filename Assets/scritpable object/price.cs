using UnityEngine;

[CreateAssetMenu(fileName = "new Price", menuName = "Price")]
public class Price : ScriptableObject
{
    public int time = 30;
    public int  oro, madera, piedra, comida, puntosDeInvestigacion, puntosDeEjercito, puntosDeEconomia; 
}
