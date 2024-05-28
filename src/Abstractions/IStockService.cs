using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Abstractions
{
    public interface IStockService
    {
        public IEnumerable<StockReadDto> FindMany();
        public StockReadDto CreateOne(StockCreateDto stock);
        public Stock? FindOne(Guid stockId);
        public IEnumerable<Stock>? DeleteProduct(Guid stockId);
        public Stock UpdateOne(Guid stockId, Stock updatedStock);
    }
}