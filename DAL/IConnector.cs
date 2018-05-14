using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IConnector<T>
    {
        void Create(T t); //Creates an instance of the object T
        T Read(int id); // Reads an instane of the object T 
        List<T> ReadAll(); // Reads a list of the instances
        void Delete(int id); // Deletes an instance of the object T 
        void Update(T t); // Updates an instance of the object T
    }
}
