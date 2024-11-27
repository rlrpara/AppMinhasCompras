using SQLite;

namespace AppMinhasCompras.Models;

public class Produto
{
    [PrimaryKey, AutoIncrement]
    public int Codigo { get; set; }
    public string? Descricao { get; set; }
    public double Preco { get; set; }
    public double Quantidade { get; set; }
}
