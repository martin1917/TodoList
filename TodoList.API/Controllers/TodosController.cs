using Microsoft.AspNetCore.Mvc;
using TodoList.API.Data;

namespace TodoList.API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodosController(TodoDbContext context)
        {
            _context = context;
        }


    }
}
