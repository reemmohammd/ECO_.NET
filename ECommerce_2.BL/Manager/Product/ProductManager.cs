using ECommerce_2.BL.Dtos.Product;
using ECommerce_2.DAL;
using ECommerce_2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.BL.Manager.Product;

public class ProductManeger : IProductManager

{
    private readonly IUnitOfWork _unitOfWork;
    public ProductManeger(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //public IEnumerable<GetProductDto> GetAll()
    //{
    //    var Products = _unitOfWork.productRepositary.GetAll();
    //        if (Products!= null)
    //        {
    //            return products.Select(p => new GetProductDto
    //            {
    //                ProductId = p.ProductId,
    //                Description = p.Description,
    //                Name = p.Name,
    //                Price = p.Price,
    //            });
    //        }
    //        return null;

    //}

    //public IEnumerable<GetProductDto>? GetAll()
    //{
    //    if (_unitOfWork.productRepositary != null)
    //    {
    //        var products = _unitOfWork.productRepositary.GetAll();

    //        if (products != null)
    //        {
    //            return products.Select(p => new GetProductDto
    //            {
    //                ProductId = p.ProductId,
    //                Description = p.Description,
    //                Name = p.Name,
    //                Price = p.Price,
    //            });
    //        }
    //    }

    //    return null;
    //}




    public IEnumerable<GetProductDto>? GetAll()
    {
        var products = _unitOfWork.productRepositary?.GetAll();
        if (products is null) return Enumerable.Empty<GetProductDto>();
        return products.Select(p => new GetProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,

        });
    }

    public IEnumerable<GetProductDto>? GetByCategory(int IdCat)
    {
        var products = _unitOfWork.productRepositary.GetByCategory(IdCat);
        if (products is null) return null;
        return products.Select(p => new GetProductDto
        {
            ProductId = p.ProductId,
            Description = p.Description,
            Name = p.Name,
            Price = p.Price,
        });
    }

    public IEnumerable<GetProductDto>? GetByName(string Name)
    {
        var products = _unitOfWork.productRepositary.GetByName(Name);
        if (products is null) return null;
        return products.Select(p => new GetProductDto
        {
            ProductId = p.ProductId,
            Description = p.Description,
            Name = p.Name,
            Price = p.Price,
        });
    }
    public GetProductDetailsDto? GetById(int id)
    {
        var product = _unitOfWork.productRepositary.GetById(id);
        if (product is null) return null;

        return new GetProductDetailsDto
        {
            ProductId = product.ProductId,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            CategoryName = product?.Category?.CategoryName,
            Color = product.Color,

        };
    }
}
