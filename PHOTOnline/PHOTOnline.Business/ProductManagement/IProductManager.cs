using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.ProductManagement.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.ProductManagement
{
    public interface IProductManager
    {
        Task<Result<string>> AddShopProduct(ShopProductInput input);
    }
}
