using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;
using Movie_Website.Models;

namespace Movie_Website.Areas.Admin.Controllers
{
    public class CommentController : AdminBaseController
    {
        private readonly ApplicationContext _db;
        public CommentController(ApplicationContext context)
        {
            _db = context;
        }
        [AllowAnonymous]
        public IActionResult ShowComment(int id)
        {
            var commnets = _db.CommentModels.Select(x => x.MovieId == 3).ToList();
            return PartialView(commnets);
        }

        public async Task<IActionResult> CreateComment([FromBody] CommentModel comment)
        {
            if ((comment == null) || (string.IsNullOrEmpty(comment.Description)))
            {
                return Json(new { success = false, message = "Invalid comment data" });
            }

            _db.CommentModels.Add(comment);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Comment created successfully" });
        }
    }
}
