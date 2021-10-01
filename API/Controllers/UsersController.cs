using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        //private readonly ILogger<UsersController> _logger;

        // public UsersController(ILogger<UsersController> logger)
        // {
        //     _logger = logger;
        // }
        public readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public  async Task<AppUser> GetUser(int id)
        {
            return  await _context.Users.FindAsync(id);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}