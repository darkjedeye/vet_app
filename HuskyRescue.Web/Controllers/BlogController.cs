using HuskyRescue.Core.Service.Blog;
using System.Web.Mvc;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
    public class BlogController : BaseController
    {
		private readonly PostHandler _postHandler = new PostHandler();
		private readonly ILogger _logger;
		public BlogController(ILogger logger)
		{
			_logger = logger;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="p">Page number</param>
		/// <returns></returns>
		public ViewResult Posts(int p = 1)
		{
			var posts = _postHandler.ReadAll();

			ViewBag.Title = "Latest Posts";

			return View("List", posts);
		}
    }
}
