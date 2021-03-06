﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopFrontend.Gateways.Interface
{
    public interface IServiceGateway<T>
    {
        T Create(T t); //Creates an instance of the object T
        T Read(int id); // Reads an instane of the object T 
        List<T> ReadAll(); // Reads a list of the instances
        bool Delete(T t); // Deletes an instance of the object T 
        bool Update(T t); // Updates an instance of the object T
    }
}
