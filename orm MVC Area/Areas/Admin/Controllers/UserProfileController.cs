using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: Admin/UserPfrofile
        [OutputCache(Duration = 3600)]
        public ActionResult UserInfo()
        {
            var userId = User.Identity.GetUserId();
            using (var db = new OnlineSoreDataContext())
            {
                var userProfile = db.UserProfiles.SingleOrDefault(q => q.Id == userId);
                var model = new UserProfileViewModel
                {
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    FullName = $"{userProfile.FirstName} {userProfile.LastName}",
                    PhotoUrl = userProfile.PhotoUrl,
                };
                return View(model);
            }
        }
    }
}