using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Sitecore.Mvc.Presentation;

namespace sc80basicsitecoremvc.Models
{
    public class CommentForm : RenderingModel
    {
        [Display(Name = "Comment Author", ShortName = "CommentAuthor")]
        [Required(AllowEmptyStrings = false), StringLength(60)]
        public string CommentsAuthor { get; set; }

        [Display(Name = "Comment Text", ShortName = "CommentText")]
        [Required(AllowEmptyStrings = false), StringLength(60)]
        public string CommentsText { get; set; }

        [Display(Name = "Comment Author Website", ShortName = "CommentAuthorWebsite")]
        [Required(AllowEmptyStrings = false), StringLength(60)]
        public string CommentsAuthorWebsite { get; set; }
    }
}