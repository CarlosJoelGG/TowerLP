using SQLite4Unity3d;

public class Item
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int index { get; set; }
	public string descripcion { get; set; }
	public string nombre { get; set; }
	public int rareza { get; set; }
	public int Cantidad { get; set; }
	public int Id_User { get; set; }

	public override string ToString()
	{
		return string.Format("[Person: Id={0}, index={1},  descripcion={2}, nombre={3}, rareza={4},Cantidad{5},Id_User={6}]", Id, index, descripcion, nombre, rareza, Cantidad, Id_User);
	}
}

