using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using UnityEngine.SceneManagement;

public class BD : MonoBehaviour
{
    public valueslider Madera,mineral,coins;
	public DataService ds;
	public Usuario people;
	public List<Item> Items;
	public Misiones mision;
	public List<int> limiteCasas,limiteMoneda,numerodeCasas;
	public IEnumerable<escuadron> soldados;
	public List<escuadron> SoldadosEscuadrones;
	public List<GameObject> Objetos;
	public List<GameObject> tipodeescuadron;
	public List<objetos> predefinidos;
	public List<string> textoMision,ImagenesMision;
	public GridBuildingSystem Construir;
	
	public IEnumerable<Item> Slot;
	public List<BuildingSystem> planos;
	public List<string> misionestexto;
	public List<Misiones> misioneslista;
	public IEnumerable<Misiones> misionesobjeto;
	public ubicarmundo mundo;
	public bool tutorial=false;
	public bool PVES = false;
	public List<int> margen;
	public spawnerunits unidadeee;
	public int version = 0; 
	// Start is called before the first frame update

	public List<Misiones> getmisiones()
	{
		List<Misiones> listaM=new List<Misiones>();
		foreach (Misiones OdM in misionesobjeto)
		{
			listaM.Add(OdM);
		}

		return listaM;
	}
	void Start()
	{
		ds = new DataService("Tower.db");

		if (PVES)
		{
			people = ds.GetUsuario(1);
			soldados = ds.GetEscuadrones(people.Id);
			SoldadosEscuadrones = new List<escuadron>();
			foreach (escuadron OdM in soldados)
			{
				SoldadosEscuadrones.Add(OdM);

			}
			unidadeee.gameObject.SetActive(true);
		}
		else
		{
			iniciarT();
		}
	}

	public void iniciarT()
	{
		IEnumerable<objetos> obj;
		predefinidos = new List<objetos>();
			misioneslista = new List<Misiones>();
			Items = new List<Item>();

			if (ds.ExisteTabla("usuario", 0))
			{
				people = ds.GetUsuario(1);
				if (people.version != version)
				{
				ds.dropearTablas();
				iniciarT();
				return;
				}
				else
				{ }
				misionesobjeto = ds.GetMisiones(1);
				Slot = ds.GetItems(1);
				foreach (Item OdM in Slot)
				{
					Items.Add(OdM);
				}
			}
			else
			{
				ds.CreateTablaUsuario(version);
				people = ds.GetUsuario(1);
				Misiones ag = new Misiones();
			string aux, aux2;
				for (int i = 0; i < misionestexto.Count; i++)
				{
				if (i < textoMision.Count)
				{
					aux = textoMision[i];
				}
				else
				{
					aux = "**";
				}
				if (i < ImagenesMision.Count)
				{
					aux2 = ImagenesMision[i];
				}
				else
				{
					aux2 = "**";
				}
				ag = new Misiones();
					misioneslista.Add(ag.llenar(misionestexto[i],aux,aux2));
					//misioneslista[i].llenar(misionestexto[i]);
				}


				ds.CreateMisiones(misioneslista);
				misionesobjeto = ds.GetMisiones(1);

				ds.CreateItem(LlenarItems());
				Slot = ds.GetItems(1);
				foreach (Item OdM in Slot)
				{
					Items.Add(OdM);
				}

			}
			{

				if (ds.ExisteTabla("objetos", 1))
				{
					obj = ds.GetObjetos(people.Id);
				}
				else
				{
					ds.CreateTablaObjetos(predeterminado());
					obj = ds.GetObjetos(people.Id);
				}
				if (ds.ExisteTabla("escuadron", 1))
				{
					soldados = ds.GetEscuadrones(people.Id);
				}
				else
				{
					ds.CreateTablaSoldados(LlenarEscuadron());
					soldados = ds.GetEscuadrones(people.Id);
				}
				SoldadosEscuadrones = new List<escuadron>();
				foreach (escuadron OdM in soldados)
				{
					SoldadosEscuadrones.Add(OdM);

				}
				mundo.llenarmundo(obj);
				predefinidos = new List<objetos>();
				foreach (objetos OdM in obj)
				{
					predefinidos.Add(OdM);
					numerodeCasas[OdM.Id_Obj]++;
				}

				refrescarmonedas();
			}
		
	}
	public void llenarM()
	{
		IEnumerable<objetos> obj;
		obj = ds.GetObjetos(people.Id);

		mundo.llenarmundo(obj);
		predefinidos = new List<objetos>();
		numerodeCasas = new List<int>();
		foreach (objetos OdM in obj)
		{
			predefinidos.Add(OdM);
			numerodeCasas[OdM.Id_Obj]++;
		}
	}
	public bool verificarCoins(int tipoA)
	{
		if (people.Coin + tipoA < limiteMoneda[0])
		{
			people.Coin += tipoA;
			RefrescarUsuario();
			refrescarmonedas();
			return true; 
		}
		return false;
	}
	public bool verificarMadera(int tipoA)
	{
		if (people.Madera + tipoA < limiteMoneda[2])
		{
			people.Madera += tipoA;
			RefrescarUsuario();
			refrescarmonedas();
			return true;
		}
		
		return false;
	}
	public bool verificarRecursos(int tipoA)
	{
		if (people.Mineral + tipoA < limiteMoneda[1])
		{
			people.Mineral += tipoA;
			RefrescarUsuario();
			refrescarmonedas();
			return true;
		}
		return false;
	}
	public void refrescarItem(Item a)
	{
		ds.updateItem(a);
	}
	public bool verificarSoldados(int tipoA)
	{
		return false;
	}
	public void updatemision(Misiones a)
	{
		ds.modificarMision(a);
	}
	public void refrescarmonedas()
	{
		coins.refresh(people.Coin);
		Madera.refresh(people.Madera);
		mineral.refresh(people.Mineral);
		for (int i = 0; i < 3; i++)
		{
			AddStock(i, 0);
		}
	}
	public void refreshsoldados()
	{
		for (int i = 0; i < SoldadosEscuadrones.Count; i++)
		{
			ds.UpdaterEscuadron(SoldadosEscuadrones[i]);
		}
		soldados = ds.GetEscuadrones(people.Id);
		SoldadosEscuadrones = new List<escuadron>();
		foreach (escuadron OdM in soldados)
		{
			SoldadosEscuadrones.Add(OdM);

		}
	}
	public int AddRecursos(int a, int aumento)
	{
		int residuo = 0;
			switch (a)
			{
				case 0:
				
				if ((people.Coin + aumento) < limiteMoneda[a])
				{ people.Coin += aumento;
					margen[0] += aumento;
				}
				else
				{
					residuo = (people.Coin + aumento) - limiteMoneda[a];
					people.Coin = limiteMoneda[a];
					margen[0] += (people.Coin + aumento)-((people.Coin + aumento)-(limiteMoneda[a]));
				}
				break;
				case 1:
				if ((people.Mineral + aumento) < limiteMoneda[a])
				{ people.Mineral += aumento;
					margen[1] += aumento;
				}
				else
				{
					residuo = (people.Mineral + aumento) - limiteMoneda[a];
					people.Mineral = limiteMoneda[a];
					margen[1] += (people.Coin + aumento) - ((people.Coin + aumento) - (limiteMoneda[a]));
				}
				break;
				case 2:
				if ((people.Madera + aumento) < limiteMoneda[a])
				{ people.Madera += aumento;
					margen[2] += aumento;
				}
				else
				{
					residuo = (people.Madera + aumento) - limiteMoneda[a];
					people.Madera = limiteMoneda[a];
					margen[2] += (people.Coin + aumento) - ((people.Coin + aumento) - (limiteMoneda[a]));
				}
					break;

			}
		RefrescarUsuario();
		refrescarmonedas();
		return residuo;
	}
	public void AddStock(int a,int aumento)
	{
				limiteMoneda[a] = limiteMoneda[a] + aumento;
	
		switch (a)
		{
			case 0:
				coins.newlimite(limiteMoneda[a]);
				break;
			case 1:
				mineral.newlimite(limiteMoneda[a]);
				break;
			case 2:
				Madera.newlimite(limiteMoneda[a]);
				break;

		}
	}

	public int Comprar(StateInf edificio)
	{
		int mar = 0;
		people.Coin -= edificio.MoneyPrice;
		people.Mineral -= edificio.FoodPrice;
		people.Madera -= edificio.WoodPrice;
		objetos aux = new objetos();
		aux.Id_Obj = edificio.id;
		aux.Id_User = people.Id;
		aux.x = edificio.gameObject.transform.position.x;
		aux.y = edificio.gameObject.transform.position.y;
		aux.z = edificio.gameObject.transform.position.z;
		aux.Level = edificio.intLevel;
		aux.Inc = edificio.Inc;
		ds.insertarObjetos(aux);
		predefinidos.Add(aux);
		numerodeCasas[predefinidos[predefinidos.Count-1].Id_Obj]++;
		people = ds.updateUsuario(people);
		refrescarmonedas();
		mar = predefinidos.Count;
		return mar;
	}
	public void MoverObjeto(StateInf edificio,bool a)
	{
		objetos aux = new objetos();
		aux.Id_Obj = edificio.id;
		aux.Id_User = people.Id;
		aux.Id = edificio.marca;
		aux.x = edificio.gameObject.transform.position.x;
		aux.y = edificio.gameObject.transform.position.y;
		aux.z = edificio.gameObject.transform.position.z;
		aux.Level = edificio.intLevel;
		aux.Inc = edificio.Inc;
		 ds.modificarObjetos(aux,a);
		people = ds.updateUsuario(people);
		refrescarmonedas();
		
	}
	public void AddExp()
	{
		people.Exp++;
		if (people.Exp >= 3)
		{
			people.Exp = 0;
			people.Lv++;
		}
		RefrescarUsuario();
	}
	public void restarsoldado(int a)
	{
		SoldadosEscuadrones[a].cantidad--;
		refreshsoldados();
		RefrescarUsuario();
	}
	public void VerificarSoldier(int a, Vector2 preciosS)
	{

		int aux = 0;
		for (int i = 0; i < SoldadosEscuadrones.Count; i++)
		{
			aux += SoldadosEscuadrones[i].cantidad;
		}
		if (aux < 5)
		{
			if (people.Coin >= preciosS.x && people.Mineral >= preciosS.y)
			{
				SoldadosEscuadrones[a].cantidad++;
				refreshsoldados();
				people.Coin = people.Coin - int.Parse( Mathf.Abs(preciosS.x)+"");
				people.Mineral = people.Mineral - int.Parse(Mathf.Abs(preciosS.y) + "");
				RefrescarUsuario();
				refrescarmonedas();
				refreshsoldados();
			}

		}
	}
	public void Verificar(int a,Vector2 preciosS)
	{
		int aux = 0;
		for (int i = 0; i < predefinidos.Count; i++)
		{
			if (predefinidos[i].Id_Obj == a)
			{
				aux++;
			}
		}
		if (aux < limiteCasas[a])
		{
			if (people.Coin >= preciosS.x && people.Madera>= preciosS.y)
			{
				
				Construir.StartBuilding(planos[a]);
				
			}
			
		}
	}
	public bool verificarbarracas()
	{
		
		if (numerodeCasas[4] > 0)
			return true;
		return false;
	}
	public void RefrescarUsuario()
	{
		people = ds.updateUsuario(people);
		refrescarmonedas();
	}
	public void anadircasa()
	{/*
		objetos aa = new objetos();
		aa.x = Construir.buildFly.transform.position.x;
		aa.y = Construir.buildFly.transform.position.y;
		aa.z = Construir.buildFly.transform.position.z;

		aa.Id_User = 1;
		aa.Id_Obj = Construir.buildFly.GetComponent<StateInf>().id;
		aa.Level = Construir.buildFly.GetComponent<StateInf>().intLevel;
		aa.Horainit = DateTime.Now;
		predefinidos.Add(aa);*/
	}
	public IEnumerable<objetos> predeterminado()
	{
		objetos aa=new objetos();
		for (int i = 0; i < Objetos.Count; i++)
		{
			aa = new objetos();
			aa.x = Objetos[i].transform.position.x;
			aa.y = Objetos[i].transform.position.y;
			aa.z = Objetos[i].transform.position.z;

			aa.Id_User = 1;
			aa.Id_Obj = Objetos[i].GetComponent<StateInf>().id;
			aa.Level = Objetos[i].GetComponent<StateInf>().intLevel;
			aa.Horainit = DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
			aa.Inc = false;
			predefinidos.Add(aa);
			
		}
		IEnumerable<objetos> aux=predefinidos;
	
		return aux;
	}

	public string ItemDescr(int a)
	{
		string b = "";
		switch (a)
		{
			case 0:
				b = "Un paquete lleno de Monedas:";
				break;
			case 1:
				b = "Un paquete lleno de Comida:";
				break;
			case 2:
				b = "Un paquete lleno de Madera:";
				break;
			case 3:
				break;
		}
		return b;
	}
	public string ItemNombre(int a)
	{
		string b = "";
		switch (a)
		{
			case 0://Coin
				b = "Monedas";
				break;
			case 1://mineral
				b = "Alimentos";
				break;
			case 2://madera
				b = "Madera";
				break;
			case 3:
				break;
		}
		return b;
	}
	public void ActualizarEscuadron()
	{
		IEnumerable<escuadron>  Soldados;
		Soldados = ds.GetEscuadrones(people.Id);
		SoldadosEscuadrones = new List<escuadron>();
				foreach (escuadron OdM in Soldados)
				{
					SoldadosEscuadrones.Add(OdM);

				}
	}
	public IEnumerable<Item> LlenarItems()
	{
		Item aa = new Item();
		for (int i = 0; i < 3; i++)
		{//Id, index, descripcion, nombre, rareza, Cantidad, Id_User
			for (int j = 0; j < 3; j++)
			{
				aa = new Item();
				aa.Id_User = 1;
				aa.index = i;
				aa.descripcion = ItemDescr(i);
				aa.nombre = ItemNombre(i);
				aa.rareza = j;
				aa.Cantidad = 5;
				aa.tipo = 0;
				Items.Add(aa);
			}

		}
		IEnumerable<Item> aux = Items;

		return aux;
	}
	public string Escuadrondescripcion(int a)
	{
		string b = "Sin Descripcion";
		switch (a)
		{
			case 0:
				b = "Soldado Razo de a pie";
				break;
			case 1:
				b = "Soldado Razo de a pie que ataca a distancia";
				break;
			case 2:
				b = "Unidad a Caballo mas rapida que un soldado a pie";
				break;

		}
		return b;
	}
	public string EscuadronNombre(int a)
	{
		string b = "-Sin Nombre-";
		switch (a)
		{
			case 0:
				b = "Soldado";
				break;
			case 1:
				b = "Arquero";
				break;
			case 2:
				b = "Caballero";
				break;
		}
		return b;
	}
	public string EscuadronPrecio(int a)
	{
		string b = "0-0-0";
		switch (a)
		{
			case 0:
				b="350-0-250";
				break;
			case 1:
				b = "150-0-350";
				break;
			case 2:
				b = "300-0-300";
				break;
		}
		return b;
	}
	public IEnumerable<escuadron> LlenarEscuadron()
	{
		SoldadosEscuadrones = new List<escuadron>();

			  escuadron aa = new escuadron();
		for (int i = 0; i < 3; i++)
		{//Id, index, descripcion, nombre, rareza, Cantidad, Id_User

			aa = new escuadron();
			aa.Id_User = 1;
			aa.cantidad = 0;
			aa.descripcion = Escuadrondescripcion(i);
			aa.Nombre = EscuadronNombre(i);
			aa.precio = EscuadronPrecio(i);
			aa.Level = 1;
			aa.index = i;
			aa.Horainit = new DateTime().Date;
			SoldadosEscuadrones.Add(aa);


		}
		IEnumerable<escuadron> aux = SoldadosEscuadrones;

		return aux;
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
