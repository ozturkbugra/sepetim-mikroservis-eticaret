namespace Sepetim.Catalog.Entities
{
    public class ProductImages
    {
        public int ProductImagesID { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string ProductID { get; set; }

        public Product Product { get; set; }
    }
}
