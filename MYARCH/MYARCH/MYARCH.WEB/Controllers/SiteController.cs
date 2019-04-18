using MYARCH.DATA.UnitofWork;
using MYARCH.DTO.EEntity;
using MYARCH.SERVICES.Interfaces;
using MYARCH.UTILITIES.ImageOperations;
using MYARCH.UTILITIES.SessionOperations;
using MYARCH.UTILITIES.StringOperations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYARCH.WEB.Controllers
{
    public class SiteController : PublicController
    {
        private readonly IUnitofWork _uow;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public SiteController(IUnitofWork uow,
            IPostService postService,
            ICategoryService categoryService,
             IUserService userService)
            : base(uow)
        {
            _uow = uow;
            _postService = postService;
            _categoryService = categoryService;
            _userService = userService;
        }
        public static string html = null;
        public ActionResult Index()
        {
            Session["a"] = 0;
            html = null;
            var result = _categoryService.GetCategories();
            foreach (var item in result)
            {
                html += "<li><a href='/" + StringManager.ToSlug(item.Name) + "-" + item.Id + "' style='color:" + item.Color + "!important;'><i class='" + item.Icon + "'></i>" + item.Name + "</a></li>";
            }
            return View(_postService.GetPostAll(null, 0));
        }

        public ActionResult PostList(int categoryId, string categoryName)
        {
            Session["pageNumber"] = 0;
            Session["categoryId"] = categoryId;
            Session["IsEmpty"] = _postService.GetPostAll(categoryId, 1);
            return View(_postService.GetPostAll(categoryId, 0));

        }
        public ActionResult PostMore()
        {
            Session["pageNumber"] = (int)Session["pageNumber"] + 1;
            var list = _postService.GetPostAll((Int32)Session["categoryId"], (Int32)Session["pageNumber"]);
            Session["IsEmpty"] = _postService.GetPostAll((Int32)Session["categoryId"], (Int32)Session["pageNumber"] + 1);
            return PartialView("~/Views/Shared/PostMore.cshtml", list); 
        }
        public ActionResult PostDetail(string categoryName, string slug)
        {
            EPostDetailPageDTO pdp = new EPostDetailPageDTO();
            pdp.PostDetail = _postService.GetPostDetailBySlug(slug);
            pdp.PostList = _postService.GetPostAll(null, 0).Take(5).ToList();
            return View(pdp);
        }

        public FileContentResult ProfileImageView(int id, int? w, int? h)
        {
            return new FileContentResult(ImageManager.ConvertToSize(_userService.GetUserImage(id), w, h), "image/png");
        }

        public ActionResult PostImageView(int id, int? w, int? h)
        {
            return new FileContentResult(ImageManager.ConvertToSize(_postService.GetPostImageById(id), w, h), "image/png");
        }

    }
}