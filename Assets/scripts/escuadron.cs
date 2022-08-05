using SQLite4Unity3d;
using System;

public class escuadron 
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Id_User { get; set; }
	public int index { get; set; }
	public DateTime Horainit { get; set; }//al salir de la pelea
	public int Level { get; set; }
	public int cantidad { get; set; }//en descanso.
	public string precio { get; set; }//precio
	public string descripcion { get; set; }//descripcion :v
	public string Nombre { get; set; }


	public override string ToString()
	{
		return string.Format("[escuadron: Id_User={0}, Horainit={1},nivel={2},cantidad={3},precio{4},descripcion{5},Nombre{6}]", Id_User, Horainit, Level, cantidad, precio, descripcion, Nombre);
	}
}
