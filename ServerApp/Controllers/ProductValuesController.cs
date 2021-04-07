using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/products")]
    [ApiController]
    public class ProductValuesController : Controller
    {
        public DataContext _context;
        public ProductValuesController(DataContext ctx)
        {
            _context = ctx;
        }
        [HttpGet("{id}")]
        public Product GetProduct(long id) {
            Product p = _context.Products.Include(p => p.Type).Include(p => p.ParentProduct).ThenInclude(pp => pp.MainPoc).ThenInclude(ppp => ppp.Question1).Include(p => p.OperatingSystemSupport).ThenInclude( p => p.OperatingSystem ).Include(p => p.ParentProduct).Include(p => p.Prerequisites).Include(p => p.Ratings).Include(p => p.Supplier).Include(p => p.ClientBrowserSupports).ThenInclude( p => p.Browser ).FirstOrDefault( p => p.ProductId == id);
            if(p.Supplier != null)
            {  
                if(p.Supplier.Products != null)
                {
                    //p.Supplier.Products = p.Supplier.Products.Select( sp => new Product { ProductId = sp.ProductId, Name = sp.Name, Category = sp.Category, Description = sp.Description, ParentProduct = sp.ParentProduct, OperatingSystem = sp.OperatingSystem, Prerequisites = sp.Prerequisites, Ratings = sp.Ratings, ReleaseNotes = sp.ReleaseNotes, Updated = sp.Updated } );
                    p.Supplier.Products = null;
                }
            }
            if (p.Ratings != null )
            {
                //p.Supplier.Products = p.Supplier.Products.Select( sp => new Product { ProductId = sp.ProductId, Name = sp.Name, Category = sp.Category, Description = sp.Description, ParentProduct = sp.ParentProduct, OperatingSystem = sp.OperatingSystem, Prerequisites = sp.Prerequisites, Ratings = sp.Ratings, ReleaseNotes = sp.ReleaseNotes, Updated = sp.Updated } );
                foreach(Rating r in p.Ratings)
                {
                    if(r != null && r.Product == p)
                    {
                        r.Product = new Product { Name = r.Product.Name };
                    }
                }
            }
            return p;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            IQueryable<Product> products = _context.Products.Include(p => p.Ratings).Include(p => p.Supplier);
            ///IQueryable<Product> products = _context.Products.Include(p => p.Type).Include(p => p.OperatingSystemSupport).ThenInclude( p => p.OperatingSystem ).Include(p => p.ParentProduct).ThenInclude(pp => pp.MainPoc).Include(p => p.Prerequisites).Include(p => p.Ratings).ThenInclude( r => r.Product).Include(p => p.Supplier).Include(p => p.ClientBrowserSupports).ThenInclude( p => p.Browser ).OrderBy(p => p.Name);
            List<Product> list = products.ToList();
            if(list != null)
            {
                foreach(Product p in list)
                {
                    if(p.Supplier != null)
                    {
                        p.Supplier.Products = null;
                    }
                    if (p.Ratings != null)
                    {
                        p.Ratings.ForEach(r => r.Product = null);
                    }
                }
            }
            return list;
        }
    }
}
