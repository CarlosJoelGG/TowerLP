using SQLite4Unity3d;

public class Usuario
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Madera { get; set; }
	public int Mineral { get; set; }
	public int Coin { get; set; }
	public int Exp { get; set; }
	public int Lv { get; set; }
	public bool prim { get; set; }

	public override string ToString()
	{
		return string.Format("[Person: Id={0}, Madera={1},  Mineral={2}, Coin={3}, Exp={4},prim{5},Lv{6}]", Id, Madera, Mineral, Coin,Exp,prim,Lv);
	}
}
