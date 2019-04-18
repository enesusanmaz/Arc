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
    public class CategoryController : AdminController
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly IUnitofWork _uow;
        public CategoryController(IUnitofWork uow,
            ICategoryService categoryService,
            IPostService postService)
            : base(uow)
        {
            _uow = uow;
            _categoryService = categoryService;
            _postService = postService;

        }
        public ActionResult Index()
        {
            return View(_categoryService.GetCategories());
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            var list = _categoryService.GetCategories();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCategoryDetailByCategoryId(int categoryId)
        {
            var result = _categoryService.GetCategoryDetailByCategoryId(categoryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(EIdDTO model)
        {
            if (_postService.AnyPostByCategoryId(model.Id) == false)
            {
                _categoryService.Delete(model.Id);
                _uow.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Update(ECategoryDTO category)
        {
            _categoryService.Update(category);
            _uow.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Insert(ECategoryDTO category)
        {
            _categoryService.Insert(category);
            _uow.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}