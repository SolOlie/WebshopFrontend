﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopFrontend.Gateways.Interface
{
    public interface IProductGateway : IServiceGateway<Product>
    {
        Product GetDefaultproduct();
    }
}
