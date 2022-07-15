using UnityEngine;

[CreateAssetMenu(fileName = "new Info", menuName = "Info")]
public class Info : ScriptableObject
{
    public string nombre;
    public Sprite sprite;
    public string info;
    public GameObject prefab;

}
