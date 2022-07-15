using UnityEngine;

public class almacenScript : MonoBehaviour
{
    public int level=1, idrecurso, recursoanadido;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("BD").GetComponent<BD>().AddStock(idrecurso,recursoanadido*level);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
