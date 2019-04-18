using MYARCH.DATA.UnitofWork;
using MYARCH.DTO.EEntity;
using MYARCH.SERVICES.Interfaces;
using MYARCH.UTILITIES.PassOperations;
using MYARCH.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYARCH.WEB.Controllers
{
    public class ProfileController : AdminController
    {
        private readonly IUserService _userService;
        private readonly IUnitofWork _uow;
        public ProfileController(IUnitofWork uow,
            IUserService userService)
            : base(uow)
        {
            _uow = uow;
            _userService = userService;

        }

        public ActionResult Index()
        {
            Session["TempImage"] = null;
            return View(_userService.Find(((SessionContext)Session["SessionContext"]).Id));
        }

        [HttpPost]
        public ActionResult TempImage(HttpPostedFileBase ImageFormData)
        {
            using (BinaryReader reader = new BinaryReader(ImageFormData.InputStream))
            {
                Session["TempImage"] = reader.ReadBytes((Int32)ImageFormData.ContentLength);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult TempImageShow(HttpPostedFileBase ImageFormData)
        {
            return new FileContentResult((byte[])Session["TempImage"], "image/png");
        }

        public ActionResult Update(EUserDTO user)
        {
            try
            {
                user.Id = ((SessionContext)Session["SessionContext"]).Id;
                user.Password = PassManager.Base64Encrypt(user.Password);
                _userService.Update(user);
                _uow.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult UserImageUpdate()
        {
            try
            {
                _userService.Update(new EUserDTO
                {
                    WhichUpdate = "I",
                    value = (byte[])Session["TempImage"],
                    Id = ((SessionContext)Session["SessionContext"]).Id
                });
                _uow.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}