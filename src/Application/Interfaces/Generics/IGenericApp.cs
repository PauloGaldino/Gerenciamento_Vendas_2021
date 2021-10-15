using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Generics
{
    public interface IGenericApp<T> where T : class
    {
        //===========Métodos CRUD=================
        Task Add(T Object);
        Task Update(T Object);
        Task Delete(T Object);


        //===========Métodos para pesquisa========
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();

    }
}