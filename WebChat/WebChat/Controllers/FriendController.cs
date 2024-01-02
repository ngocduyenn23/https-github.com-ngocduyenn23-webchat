using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebChat.Etities;

namespace WebChat.Controllers
{
	public class FriendController : ChattingAppControllerBase
	{
		public FriendController(ChattingAppDbContext db) : base(db)
		{
		}

		// lấy danh sách user ra( trừ tài khoản đang dùng)
		public IActionResult GetAll()
		{
			var currenUserId = Convert.ToUInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var user = _db.AppUsers
					.Where(u => u.Id != currenUserId)
					.ToList();
			return Ok(user);
		}
	}
}
