using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despensometro2.Repositories
{
    public interface IRepository<T>
        where T: class
    {   
        //obtém uma lista com todos os elementos de determinada classe
        IQueryable<T> ListAll();

        //obtém um elemento de determinado id
        T GetById(int id);

        //adiciona um elemento
        void AddElement(T element);

        //update de um elemento
        void UpdateElement(T element);

        //delete por id
        Boolean Delete(int id);

    }
}