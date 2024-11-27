using AppMinhasCompras.Models;

namespace AppMinhasCompras.Interface;

public interface ISQLiteDatabaseHelper
{
    Task<int> Delete(int codigo);
    Task<List<Produto>> GetAll();
    Task<int> Insert(Produto produto);
    Task<List<Produto>> Search(string? query);
    Task<List<Produto>> Update(Produto produto);
}
