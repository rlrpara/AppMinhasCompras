using AppMinhasCompras.Interface;
using AppMinhasCompras.Models;
using SQLite;
using System.Text;

namespace AppMinhasCompras.Helpers;

public class SQLiteDatabaseHelper : ISQLiteDatabaseHelper
{
    private readonly SQLiteAsyncConnection _connection;

    public SQLiteDatabaseHelper(string path)
    {
        _connection = new SQLiteAsyncConnection(path);
        _connection.CreateTableAsync<Produto>().Wait();
    }

    public Task<int> Insert(Produto produto)
    {
        return _connection.InsertAsync(produto);
    }
    public Task<List<Produto>> Update(Produto produto)
    {
        var sqlPesquisa = new StringBuilder();

        sqlPesquisa.AppendLine($"UPDATE Produto");
        sqlPesquisa.AppendLine($"   SET Descricao=?,");
        sqlPesquisa.AppendLine($"       Quantidade=?,");
        sqlPesquisa.AppendLine($"       Preco=?");
        sqlPesquisa.AppendLine($" WHERE Codigo=?;");

        return _connection.QueryAsync<Produto>(sqlPesquisa.ToString(), produto.Descricao, produto.Quantidade, produto.Preco, produto.Codigo);
    }
    public Task<int> Delete(int codigo)
    {
        return _connection.Table<Produto>().DeleteAsync(x => x.Codigo == codigo);
    }
    public Task<List<Produto>> GetAll()
    {
        return _connection.Table<Produto>().ToListAsync();
    }
    public Task<List<Produto>> Search(string? query)
    {
        var sqlPesquisa = new StringBuilder();

        sqlPesquisa.AppendLine($"SELECT Codigo,");
        sqlPesquisa.AppendLine($"       Descricao,");
        sqlPesquisa.AppendLine($"       Preco,");
        sqlPesquisa.AppendLine($"       Quantidade");
        sqlPesquisa.AppendLine($"  FROM Produto");
        sqlPesquisa.AppendLine($" WHERE Descricao like '%{query}%'");

        return _connection.QueryAsync<Produto>(sqlPesquisa.ToString());
    }
}
