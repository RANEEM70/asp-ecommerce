using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Entities;
using CodeCrafters_backend_teamwork.src.Databases;
using Microsoft.EntityFrameworkCore;

namespace CodeCrafters_backend_teamwork.src.Repositories
{
    public class StockRepository : IStockRepository
    {
        private DbSet<Stock> _stocks;
        private DatabaseContext _databaseContext;

        public StockRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
            _stocks = databaseContext.Stocks;

        }
        public IEnumerable<Stock> FindMany()
        {
            return _stocks;
        }
        public IEnumerable<Stock> CreateOne(Stock stock)
        {
            _stocks.Add(stock);
            _databaseContext.SaveChanges(); 
            return _stocks;

        }
        public Stock? FindOne(Guid stockId) 
        {
            Stock? stock = _stocks.FirstOrDefault(stock => stock.Id == stockId);
            return stock;

        }
        public IEnumerable<Stock>? DeleteProduct(Guid stockId)  
        {
             Stock? stockFound = FindOne(stockId);
            if(stockFound != null)
            {
            _stocks.Remove(stockFound); 
            _databaseContext.SaveChanges();
            }
            return _stocks; 

        }
        public Stock UpdateOne(Guid stockId, Stock updatedStock) 
        {

            Stock? stock = _stocks.FirstOrDefault(stock => stock.Id == stockId);
            if (stock != null)
            {
                stock.Size = updatedStock.Size;
                stock.Color = updatedStock.Color;
                _databaseContext.SaveChanges(); 
                return stock;
            }

            return updatedStock;

        }
    }
}