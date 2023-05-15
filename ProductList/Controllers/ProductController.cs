using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductList.Infrastructure.IRepository;
using ProductList.Models;

namespace ProductList.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _services;

        public ProductController(IProduct services)
        {
            _services = services;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            
            ProductInfoModel model = new ProductInfoModel();
            model.Productlist = _services.GetProductData();
            return View(model);
        }

        // GET: ProductController/Details/5
    

        [HttpGet]
        public ActionResult AddEditProduct(int id)
        {
            ProductInfo model = new ProductInfo();
            model = _services.GetProductId(id);
            if(model == null)
            {
                return View();

            }
            else
            {
                return View(model);
            }
           
        }

        // POST: ProductController/Create
        [HttpPost]
        
        public ActionResult Create(ProductInfo infomodel)
        {
            ProductInfo model = new ProductInfo();
            try
            {
                model = _services.AddProduct(infomodel);
                if(model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
               
            }
            catch
            {
                return View();
            }
        }

        

     
        //[HttpPost]
      
        public ActionResult Delete(int id)
        {
            ProductInfo model = new ProductInfo();
            try
            {
                model = _services.DeleteProduct(id);
                if (model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return View(model);
            }
        }
    }
}
