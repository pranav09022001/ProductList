namespace ProductList.Models
{
    public class ProductInfo
    {

        public int No { get; set; }
        public int SN { get; set; }
        public string Product { get; set; }
        public string Descrip { get; set; }

        public int Price { get; set; }
        public DateTime Created { get; set; }
        public int TotalRowCount { get;  set; }
    }
    public class ProductInfoModel
    {
         private List<ProductInfo> _products=new List<ProductInfo>();    
        public List<ProductInfo> Productlist
        {
            get { return _products; }
            set { _products = value; }  
        }
    }
} 
