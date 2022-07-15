using SQLite4Unity3d;
using UnityEngine;
using System;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
      //  Debug.Log("Final PATH: " + dbPath);     

	}

	public void CreateTablaUsuario(){
		_connection.DropTable<Usuario> ();
		_connection.CreateTable<Usuario> ();
		_connection.InsertAll (new[]{
			new Usuario{
				Id = 1,
				Madera = 800,
				Mineral = 800,
				Coin = 1500,
				Exp=0,
				prim=true
			}
		});
	}
	public void CreateTablaescuadron()
	{
		
	}
	public void CreateTablaSoldados()
	{
		_connection.DropTable<escuadron>();
		_connection.CreateTable<escuadron>();
		//ToConsole(a);
		_connection.InsertAll(new[]{
			new escuadron{
				Id = 0,
				Id_User = 0,
				Horainit= DateTime.Now,
				Level=0,
				Inc=false
			}
		});
	}
	public void getTablaSoldados(IEnumerable<escuadron> a)
	{
		
	}
	public void CreateTablaObjetos(IEnumerable<objetos> a)
	{
		_connection.DropTable<objetos>();
		_connection.CreateTable<objetos>();
		ToConsole(a);
		_connection.InsertAll(a);
	}
	public bool ExisteTabla(string a,int marca)
    {
		switch (a) 
		{
			case "usuario":
				try
				{
					IEnumerable<Usuario> b = _connection.Table<Usuario>();
					ToConsole(b);
				}
				catch (SQLiteException)
				{
					return false;
				}
				
				break;
			case "objetos":
				try
				{
					IEnumerable<objetos> c = _connection.Table<objetos>().Where(x => x.Id_User == marca);
					ToConsole(c);
				}
				catch (SQLiteException)
				{
					return false;
				}
				break;
			case "escuadron":
				try
				{
					IEnumerable<escuadron> c = _connection.Table<escuadron>().Where(x => x.Id_User == marca);
					ToConsole(c);
				}
				catch (SQLiteException)
				{
					return false;
				}
				break;
		}
		return true;
	}
	private void ToConsole(IEnumerable<objetos> people)
	{
		foreach (objetos person in people)
		{
			ToConsole(person.ToString());
		}
	}
	private void ToConsole(IEnumerable<escuadron> people)
	{
		foreach (escuadron person in people)
		{
			ToConsole(person.ToString());
		}
	}
	private void ToConsole(IEnumerable<Usuario> people)
	{
		foreach (Usuario person in people)
		{
			ToConsole(person.ToString());
		}
	}
	private void ToConsole(string msg)
	{
		//DebugText.text += System.Environment.NewLine + msg;
		//Debug.Log("");
	}
	public IEnumerable<Usuario> GetUsuario(){
		return _connection.Table<Usuario>();
	}
	public IEnumerable<objetos> GetObjetos(int a)
	{
		return _connection.Table<objetos>().Where(x => x.Id_User == a);
		
	}
	public IEnumerable<escuadron> GetEscuadrones(int a)
	{
		return _connection.Table<escuadron>().Where(x => x.Id_User == a);

	}

	public void insertarObjetos(objetos i)
	{
		objetos p = i;
		p.Horainit = DateTime.Now;
		_connection.Insert(p);
	}
	public void insertarEscuadrones(escuadron i)
	{
		escuadron p;
		p = new escuadron
		{
			Id_User = 1,
			Horainit = DateTime.Now,
			Level = 0,
			Inc = false
		};
		//p.Horainit = DateTime.Now;
		_connection.Insert(p);
	}
	public int modificarObjetos(objetos i,bool b)
	{
		objetos p = i;
		if(!b)
		p.Horainit = DateTime.Now;
		_connection.Update(p);
		return _connection.Update(p);
	}
	public Usuario GetUsuario(int a)
	{
		return _connection.Table<Usuario>().Where(x => x.Id == a).FirstOrDefault();
	}
	public Usuario CreatePerson(){
		//Debug.Log("CP");
		Usuario p = new Usuario{
			Madera = 150,
			Mineral = 150,
			Coin = 500,
			Exp = 0,
			prim=true
		};
		_connection.Insert (p);
		
		return p;
	}
	public Usuario updateUsuario(Usuario a)
	{
		Usuario p = a;
		p.prim = false;
		_connection.Update(p);
		return p;
	}
	public void CreateUsuario()
	{
		//Debug.Log("CP");
		var p = new Usuario
		{
			Madera = 150,
			Mineral = 150,
			Coin = 500,
			Exp = 0,
			prim = true
		};
		_connection.Insert(p);
		//return p;
	}
}
