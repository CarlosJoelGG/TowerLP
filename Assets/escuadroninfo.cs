using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escuadroninfo : MonoBehaviour
{
    public escuadron info;
    //public int Id;
    public int Id_User;
    public DateTime Horainit;
    public int Level;
    public int cantidad;

    // Start is called before the first frame update
    void Start()
    {
        info = new escuadron();
        info.Id_User = Id_User;
       // info.Horainit = DateTime.Now;
        info.Level = Level;
        info.cantidad = 0;

    }
    public escuadron inf()
    { return info; }
    public void llenar(escuadron a)
    {
       // Id = a.Id;
        Id_User = a.Id_User;
        Horainit = a.Horainit;
        Level = a.Level;
        cantidad = a.cantidad;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
