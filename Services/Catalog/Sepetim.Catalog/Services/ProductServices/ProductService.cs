using AutoMapper;
using MongoDB.Driver;
using Sepetim.Catalog.Dtos.ProductDtos;
using Sepetim.Catalog.Entities;
using Sepetim.Catalog.Settings;

namespace Sepetim.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var connection = new MongoClient(_databaseSettings.ConnectionString);
            var database = connection.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }


        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public Task<ResultProductDto> GetProductByIdAsync(string id)
        {
            var value = _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<Task<ResultProductDto>>(value);
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            return _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);
        }
    }
}
