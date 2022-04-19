using Microsoft.AspNetCore.Mvc;

namespace CSharpAngular.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }


    }
}
