using UnityEngine;
using UnityEngine.UI;

public class TextShadown : MonoBehaviour
{
    public Text shadown;
    Text value;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        shadown.text = value.text;
    }
}
