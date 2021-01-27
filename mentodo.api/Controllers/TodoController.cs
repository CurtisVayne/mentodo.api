using Mentodo.Api.Data;
using Mentodo.Api.Model;
using Mentodo.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Mentodo.Api.Controllers
{
    /// <summary>
    /// The Controller for Api endpoints of the Todo items 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TodoController(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List of Todo items
        /// </summary>
        /// <example>
        /// GET http://url/todo
        /// </example>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Todo> Index()
        {
            //Thread.Sleep(500);
            return _context.Todos.OrderBy(p => p.info).ToList();
        }

        /// <summary>
        /// Returns a single todo item
        /// </summary>
        /// <example>
        /// GET http://url/todo/123
        /// </example>
        /// <param name="id">The id of the item</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            Thread.Sleep(500);
            return _context.Todos.FirstOrDefault(p => p.id == id);
        }
        
        /// <summary>
        /// Delete a todo item by id
        /// </summary>
        /// <example>
        /// DELETE http://url/todo/123
        /// </example>
        /// <param name="id">The id of the item to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            ApiResponse result = new ApiResponse();
            //Thread.Sleep(500);
            try
            {
                var item = _context.Todos.FirstOrDefault(p => p.id == id);
                if (item != null)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                    result.success = true;
                    result.message = "A törlés megtörtént";
                }
                else
                {
                    result.success = false;
                    result.message = "A tétel nem található";
                }
            }
            catch (System.Exception)
            {
                result.success = false;
                result.message = "Hiba történt a mentés közben";
            }

            return result;
        }

        /// <summary>
        /// Saves a todo item into the DB
        /// </summary>
        /// POST http://url/todo (item)
        /// <param name="item">The todo item to save</param>
        /// <returns></returns>
        [HttpPost("save")]
        public ApiResponse Save(Todo item)
        {
            ApiResponse result = new ApiResponse();
            //Thread.Sleep(500);
            try
            {

                if (_context.Todos.Count() > 500)
                {
                    var lst = _context.Todos.Take(100).ToList();
                    foreach (var delitem in lst)
                    {
                        _context.Remove(delitem);
                    }
                    _context.SaveChanges();
                    Thread.Sleep(1000);
                }

                if (item.id == 0 || !_context.Todos.Any(p => p.id == item.id))
                {
                    _context.Todos.Add(item);
                    result.message = "A tétel létrehozás megtörtént";
                }
                else
                {
                    _context.Update(item);
                    result.message = "A módosítás megtörtént";
                }
                _context.SaveChanges();
                result.success = true;
                result.id = item.id;
            }
            catch (System.Exception)
            {
                result.success = false;
                result.message = "Hiba történt a mentés közben";
            }

            return result;
        }
    }
}
