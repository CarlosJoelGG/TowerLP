using SQLite4Unity3d;
using System.Collections.Generic;

public class Misiones
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int tipo { get; set; }
	public int idR { get; set; }
	public bool completada { get; set; }
	public string textos { get; set; }
	public string imagenes { get; set; }
	public string titulo { get; set; }
	public int progreso { get; set; }
	public string reward { get; set; }
	public int Id_User { get; set; }
	public int idR_H { get; set; }

	public int meta { get; set; }

	public Misiones(){}
	public override string ToString()
	{
		return string.Format("[Person: Id={0}, tipo={1},  idR={2}, completada={3}, reward={4}, Id_User={5},progreso{6},idR_H={7},meta{8},textos{9},imagenes{10},titulo{11}]", Id, tipo, idR, completada, reward, Id_User, progreso, idR_H, meta, textos, imagenes, titulo);
	}
	public Misiones llenar(string a,string c, string e)
	{
		textos = c;
		imagenes = e;
		Id = default;
		string[] b = a.Split('*');
		tipo = int.Parse( b[0]);
		idR = int.Parse(b[1]);
		idR_H= int.Parse(b[2]);

		progreso = 0;
		completada = false;
		reward = b[3];
		meta = int.Parse(b[4]);
		titulo =b[5];
		Id_User = 1;

		return this;
	}
}
