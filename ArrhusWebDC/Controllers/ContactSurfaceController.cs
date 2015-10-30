using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArrhusWebDC.Models;
using Umbraco.Web.Mvc;

namespace ArrhusWebDC.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult ShowForm()
        {
            ContactModel myModel = new ContactModel();
            return PartialView("ContactForm", myModel);
        }

        public ActionResult HandleFormPost(ContactModel model)
        {
            var newComment = Services.ContentService.CreateContent(model.Name + " - " + DateTime.Now, CurrentPage.Id, "ContactForm");
            newComment.SetValue("contactSender", model.Email);
            newComment.SetValue("contactReceiver", model.Name);
            newComment.SetValue("contactText", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            return RedirectToCurrentUmbracoPage();
        }
    }
}