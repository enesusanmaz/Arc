using MYARCH.DATA.UnitofWork;
using MYARCH.DTO.EEntity;
using MYARCH.SERVICES.Interfaces;
using MYARCH.UTILITIES.PassOperations;
using MYARCH.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYARCH.WEB.Controllers
{
    public class LoginController : PublicController
    {
        public ActionResult Index() { return View(); }
        private readonly IUserService _userService;
        private readonly IUnitofWork _uow;
        private SessionContext _sessionContext;
        public LoginController(IUnitofWork uow,
            IUserService userService)
            : base(uow)
        {
            _uow = uow;
            _userService = userService;
            _sessionContext = new SessionContext();
        }

        [HttpPost]
        public ActionResult LoginControl(ELoginDTO login)
        {
            login.Password = PassManager.Base64Encrypt(login.Password);
            var result = _userService.GetUserByUserNameAndPassword(login.UserName, login.Password);
            if (result != null)
            {
                AutoMapper.Mapper.DynamicMap(result, _sessionContext);
                Session["SessionContext"] = _sessionContext;
                return Json("/profile", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Response.Redirect("/login");
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}