using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public StockController(ApplicationDBContext dbContext)
        {
         _dbContext=dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks=_dbContext.Stocks.ToList();
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
            {
            var stocks=_dbContext.Stocks.Find(id);
            if(stocks == null){
                return NotFound();
            }
            
            return Ok(stocks);
            }
    }
    
}