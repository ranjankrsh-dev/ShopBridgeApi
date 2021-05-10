using ShopBridgeApi.DbHelper;
using ShopBridgeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridgeApi.Controllers
{
    public class ProductController : ApiController
    {
        ProductRepository repository = null;
        public ProductController()
        {
            repository = new ProductRepository();
        }

        [HttpGet]
        [Route("api/GetItems")]
        public IHttpActionResult Get()
        {
            try
            {
                var resp = repository.GetAllInventory();
                return Ok(resp);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        [HttpPost]
        [Route("api/AddNewItem")]
        public IHttpActionResult Post([FromBody] Inventory inventory)
        {
            try
            {
                var resp = repository.AddNewInventory(inventory);
                return Ok(resp);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        [Route("api/UpdateItem")]
        public IHttpActionResult Put([FromBody] Inventory inventory)
        {
            try
            {
                var resp = repository.UpdateInventory(inventory);
                return Ok(resp);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        [Route("api/DeleteItem")]
        public IHttpActionResult Delete([FromBody] Inventory inventory)
        {
            try
            {
                if (inventory.ItemId != 0)
                {
                    var resp = repository.DeleteInventory(inventory);
                    return Ok(resp);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
