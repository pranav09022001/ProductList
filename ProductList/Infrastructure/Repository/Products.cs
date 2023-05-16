using ProductList.Infrastructure.IRepository;
using ProductList.Models;
using System.Data;
using Dapper;

namespace ProductList.Infrastructure.Repository
{
    public class Products : IProduct

    {
        private readonly IDapperServices _dapper;
        //private readonly ProductInfo productinfo;

        public Products(IDapperServices dapper)
        {
            _dapper = dapper;
        }

        public ProductInfo AddProduct(ProductInfo productInfo)
        {

          
            ProductInfo model = new ProductInfo();

            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@SN", productInfo.SN);
                
                dbPara.Add("Product", productInfo.Product);
                dbPara.Add("Descrip", productInfo.Descrip);

                dbPara.Add("Price", productInfo.Price);


                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<ProductInfo>("productAddEdit1", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            { 

                throw;
            } 
            return model;


        }

        public ProductInfo DeleteProduct(int id)
        {
            ProductInfo model2 = new ProductInfo();
            try
            {
                var dbPara=new DynamicParameters();
                dbPara.Add("@SN", id);
                model2.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<ProductInfo>("productDelete1", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {

                throw;
            }
            return model2;

           // throw new NotImplementedException();
        }

        

        public List<ProductInfo> GetProductData()
        {
            var query = @"select *, ROW_NUMBER() OVER(ORDER BY SN) No from product";
            List<ProductInfo> products=new List<ProductInfo>();
            try
            {
                products = Task.FromResult(_dapper.GetAll<ProductInfo>(query, null, commandType: CommandType.Text)).Result;
            }
            catch (Exception)
            {

                throw;
            }
            return products;
        }


        public ProductInfo GetProductId(int id)
        {
            var query = @"select * from product where SN=@SN";
            ProductInfo productinfo =new ProductInfo() ;

            try
            {
                var dbPara=new DynamicParameters();
                dbPara.Add("SN", id);
                productinfo = Task.FromResult(_dapper.Get<ProductInfo>(query, dbPara, commandType: CommandType.Text)).Result;
            }
            catch (Exception)
            {

                throw;
            }
            return productinfo;
        }

        public ProductInfo GetProductIdData(int id)
        {
            throw new NotImplementedException();
        }

        public ProductInfo UpdateProduct(ProductInfo productInfo)
        {
            ProductInfo model = new ProductInfo();

            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@SN", productInfo.SN);

                dbPara.Add("Product", productInfo.Product);
                dbPara.Add("Descrip", productInfo.Descrip);
                dbPara.Add("Price", productInfo.Price);


                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<ProductInfo>("productAddEdit", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {

                throw;
            }
            return model;
        }
    }
}

