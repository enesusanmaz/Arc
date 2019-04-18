using MYARCH.DATA.UnitofWork;
using MYARCH.DTO.EEntity;
using MYARCH.SERVICES.Interfaces;
using MYARCH.UTILITIES.SessionOperations;
using MYARCH.UTILITIES.StringOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYARCH.WEB.Controllers
{
    public class PostController : AdminController
    {
        private readonly IPostService _postService;
        private readonly IUnitofWork _uow;
        public PostController(IUnitofWork uow,
            IPostService postService)
            : base(uow)
        {
            _uow = uow;
            _postService = postService;

        }
        public ActionResult Index()
        {
            Session["TempImage"] = null;
            return View(_postService.GetPostsByFilterParams(((SessionContext)Session["SessionContext"]).Id, 0, null, null));
        }
        public ActionResult GetPostsByFilterParams(int pageNumber, string title, int? categoryId)
        {
            title = title == "null" ? title = null : title;
            return Json(_postService.GetPostsByFilterParams(((SessionContext)Session["SessionContext"]).Id, pageNumber, title, categoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPostCount()
        {
            return Json(_postService.GetPostCount(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPostDetailByPostId(int postId)
        {
            var result = _postService.GetPostDetailByPostId(postId);
            result.PostContent = HttpUtility.HtmlDecode(result.PostContent);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(EIdDTO model)
        {
            _postService.Delete(model.Id);
            _uow.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(EPostDTO post)
        {
            post.Slug = _postService.GetSlugAnyPost(StringManager.ToSlug(post.Title));
            post.UserId = ((SessionContext)Session["SessionContext"]).Id;
            post.PostContent = HttpUtility.HtmlEncode(post.PostContent);
            if (Session["TempImage"] != null)
                post.Image = (byte[])Session["TempImage"];
            _postService.Update(post);
            _uow.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Insert(EPostDTO post)
        {
            try
            {
                _uow.BeginTransaction();
                post.Slug = _postService.GetSlugAnyPost(StringManager.ToSlug(post.Title));
                post.UserId = ((SessionContext)Session["SessionContext"]).Id;
                post.PostContent = HttpUtility.HtmlEncode(post.PostContent);
                if (Session["TempImage"] != null)
                    post.Image = (byte[])Session["TempImage"];
                _postService.Insert(post);
                _uow.SaveChanges();
                _uow.Commit();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                _uow.Rollback();
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}