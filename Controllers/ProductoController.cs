using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api_ASP.NET_Core.Controllers
{
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        public AppDb Db { get; }

        public ProductoController(AppDb db){
            Db = db;
        }
        
        // GET api/producto
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var query = new ProductosQuery(Db);
            var result = await query.AllProductosAsync();
            return new OkObjectResult(result);
        }

        // GET api/producto/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ProductosQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/producto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Productos body){
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/producto/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody]Productos body){
            await Db.Connection.OpenAsync();
            var query = new ProductosQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.nombre = body.nombre;
            result.codigo_barra = body.codigo_barra;
            result.precio = body.precio;
            result.disponible = body.disponible;
            result.detalle = body.detalle;
            result.imagen = body.imagen;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/producto/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id){
            await Db.Connection.OpenAsync();
            var query = new ProductosQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult(); 
        }

        // DELETE api/producto
        [HttpDelete]
        public async Task<IActionResult> DeleteAll(){
            await Db.Connection.OpenAsync();
            var query = new ProductosQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

    }
}