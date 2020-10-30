namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItemById
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string Type { get; set; }

        public string Brand { get; set; }
    }
}