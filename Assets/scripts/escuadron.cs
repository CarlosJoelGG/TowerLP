using SQLite4Unity3d;
using System;

public class escuadron 
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Id_User { get; set; }
	public DateTime Horainit { get; set; }//al salir de la pelea
	public int Level { get; set; }
	public bool Inc { get; set; }//en descanso.


	public override string ToString()
	{
		return string.Format("[escuadron: Id_User={0}, Horainit={1},nivel={2},Inc={3}]", Id_User, Horainit, Level, Inc);
	}
}
