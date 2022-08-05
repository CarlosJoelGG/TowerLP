using System;
using System.Collections.Generic;
using UnityEngine;

public class StateInf : MonoBehaviour
{
    public string playerid;
    public int intLevel, team,BDid;
    public Vector3 pos = Vector3.down;
    public string descripcion;
    public bool Inc=false;
    public bool recursos=false;
    public bool barraca = false;
    public Sprite IAlerta;
    public string titulo="";
    public string inicio="";
    public int MoneyPrice, WoodPrice, FoodPrice, chashPrice,id,marca; 


    // Start is called before the first frame update
    private void Awake()
    {
        if (pos != Vector3.down)
        {
            transform.position = pos;
        }
      
    }
    public int sacarsegundos()
    {
        int b = 0;
        string dia,noche;
        noche=inicio;
        DateTime aux2 = new DateTime();
        dia = DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        TimeSpan diff = DateTime.Parse(dia) - DateTime.Parse(noche);
        //Debug.Log(aux2.ToString() + "-" + inicio.ToString() + "-" + diff.TotalSeconds);
        float c= Mathf.Abs(float.Parse(diff.TotalSeconds+""));
        //Debug.Log(Mathf.Abs(c)+"----"+diff.TotalSeconds);
        string d = Mathf.Abs(c) + "";
       // Debug.Log(d);
        string[] e = d.Split(',');
        b = int.Parse(e[0]);
        return b;
    }
   
    public void iniciar(objetos a)
    {
        marca = a.Id;
        inicio = a.Horainit;
        transform.position = new Vector3(a.x, a.y, a.z);
        Inc = a.Inc;
        intLevel = a.Level;
    }
    public void seleccionar()
    {
        Debug.Log("seleccionado");
    }
    // Update is called once per frame
    void Update()
    {
        //pos = transform.position;
    }
}
