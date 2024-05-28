using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafters_backend_teamwork.src.Controllers
{
    public class StockController : CustomizedController
    {
        private IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<StockReadDto>> FindMany()
        {
            return Ok(_stockService.FindMany());
        }
        [HttpGet("{stockId}")]
        public Stock? FindOne(Guid stockId)
        {
            return _stockService.FindOne(stockId);
        }
        [HttpPost]
        public ActionResult<IEnumerable<StockReadDto>> CreateOne([FromBody] StockCreateDto stock)
        {
            return CreatedAtAction(nameof(CreateOne), _stockService.CreateOne(stock));

        }
        [HttpDelete("{stockId}")]
        public IEnumerable<Stock>? DeleteProduct([FromRoute] Guid stockId)
        {
            return _stockService.DeleteProduct(stockId);
        }
        [HttpPatch("{stockId}")]
        public Stock UpdateOne(Guid stockId, Stock updatedStock)
        {
            return _stockService.UpdateOne(stockId, updatedStock);
        }

    }
}