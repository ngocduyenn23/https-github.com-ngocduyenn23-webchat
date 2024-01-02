using Microsoft.AspNetCore.Mvc;
using WebChat.Etities;

namespace WebChat.Controllers
{
    public class ChattingAppControllerBase : Controller
    {
        protected readonly ChattingAppDbContext _db;
      public ChattingAppControllerBase(ChattingAppDbContext db ) : base()
        {
            _db = db;
        }
    }
}
