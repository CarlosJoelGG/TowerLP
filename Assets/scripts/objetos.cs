using SQLite4Unity3d;
using System;
public class objetos
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	public int Id_User  { get; set; }
	public int Id_Obj { get; set; }
	public DateTime Horainit { get; set; }

	public int Level { get; set; }
	public float x { get; set; }
	public float y { get; set; }
	public float z { get; set; }
	public bool Inc { get; set; }//en construccion


	public override string ToString()
	{
		return string.Format("[Objetos: Id={0}, Id_User={1},Id_Obj ={2} Horainit={3}, x={4}, y={5},z={6},nivel={7},Inc={8}]", Id, Id_User,Id_Obj, Horainit, x, y,z,Level,Inc);
	}
}
