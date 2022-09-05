using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using SQLite4Unity3d;


public class ubicarmundo : MonoBehaviour
{
	public DataService ds;
	public IEnumerable<objetos> people;
	public List<GameObject> objetosdelmundo;
	public List<GameObject> casasdelmundo;
	public List<GameObject> prefabobjetos;
	// Start is called before the first frame update
	void Start()
	{
	
		
	}
	public void destruir()
	{
		for (int i = 0; i < objetosdelmundo.Count; i++)
		{
			Destroy(objetosdelmundo[i]);
		}
	}
	public void MundoAdd(GameObject a)
	{
		objetosdelmundo.Add(a);
	}
	public void llenarmundo(IEnumerable<objetos> objdelmundo)
	{
		destruir();
		objetosdelmundo = new List<GameObject>();
		foreach (objetos OdM in objdelmundo)
		{
			//Debug.Log(OdM.Id_Obj+"-");
			objetosdelmundo.Add(Instantiate(prefabobjetos[OdM.Id_Obj]));
			objetosdelmundo[objetosdelmundo.Count - 1].GetComponent<StateInf>().iniciar(OdM);
			objetosdelmundo[objetosdelmundo.Count - 1].transform.parent = transform;

		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
   
}
