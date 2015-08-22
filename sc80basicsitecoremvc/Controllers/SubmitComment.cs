using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sc80basicsitecoremvc.Controllers
{
    public class SubmitComment : Controller
    {
        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(sc80basicsitecoremvc.Models.CommentForm commentsForm)
        {
            using (new SecurityDisabler())
            {
                Database master = Sitecore.Configuration.Factory.GetDatabase("master");
                master.GetItem("/sitecore/content/home");
                Item item = Sitecore.Context.Database.GetItem(new ID("{C9E3730D-E1C6-466F-9524-DA44861A45CB}"));
                ID sitecoreID = new Sitecore.Data.ID(item.ID.ToString());
                TemplateID templateID = new TemplateID(sitecoreID);
                string name = ItemUtil.ProposeValidItemName(Sitecore.DateUtil.IsoNow);
                Item newComment = Sitecore.Context.Item.Add(name, templateID);
                newComment.Editing.BeginEdit();
                newComment.Fields["Comment Author"].Value = commentsForm.CommentsAuthor.ToString();
                newComment.Fields["Comment Text"].Value = commentsForm.CommentsText.ToString();
                LinkField website = newComment.Fields["Comment Author Website"];
                website.Url = commentsForm.CommentsAuthorWebsite.ToString();
                website.Text = commentsForm.CommentsAuthorWebsite.ToString();
                website.Target = "_blank";
                website.LinkType = "external";
                newComment.Editing.EndEdit();
            }

            return View();
        }
    }
}