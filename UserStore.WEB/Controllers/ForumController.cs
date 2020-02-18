using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Forum_Marchuk.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Forum_Marchuk.BLL.DTO;
using Forum_Marchuk.BLL.Infrastructure;
using Forum_Marchuk.Models;
using Microsoft.AspNet.Identity;

namespace Forum_Marchuk.Controllers
{
    public class ForumController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        private IReplyService ReplyService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IReplyService>();
            }
        }
        private IThemeService ThemeService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IThemeService>();
            }
        }
        private IQuestionService QuestionService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IQuestionService>();
            }
        }


        #region THEME OPERATIONS
        #region Create Theme
        [Authorize(Roles ="admin")]
        public  ActionResult CreateTheme()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> CreateTheme(ThemeModel model)
        {
           ThemeDTO themeDto = new ThemeDTO { ThemeDesc = model.ThemeDesc, ThemeTitle = model.ThemeTitle, Id =RandomStringIdGenerator.GetUniqueId() };
           await ThemeService.CreateNew(themeDto);
           return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Delete Theme
        [Authorize(Roles = "admin")]
        public ActionResult DeleteTheme(string id)
        {
            return View();
        }
        [HttpPost,ActionName("DeleteTheme")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> RemoveTheme(string id)
        {
            ThemeDTO theme = await ThemeService.FindThemeDtoById(id);
            try
            {
              if (theme!=null)
              {
               await ThemeService.Delete(theme);
              }
            }
            catch (Exception)
            {
                return RedirectToAction("Error","Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Display Themes
        public async Task<ActionResult> DisplayThemes()
        {
            return View(await ThemeService.GetAllThemes());
        }
        #endregion

        #region Edit Theme

        [HttpGet]
        public async Task<ActionResult> EditTheme(string id)
        {
            ThemeDTO theme = await ThemeService.FindThemeDtoById(id);
            if (theme!=null)
            {
            return View(theme);
            }
            return HttpNotFound();

        }
        [HttpPost]
        public async Task<ActionResult> EditTheme(ThemeDTO theme)
        {
            await ThemeService.Edit(theme);
            return RedirectToAction("DisplayThemes");
        }
        #endregion

        #endregion


        #region Question Operations

        #region CREATE QUESTION
        [Authorize(Roles = "admin,user")]
        public ActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "user,admin")]
        public async Task<ActionResult> CreateQuestion(string themeId,QuestionModel model)
        {
            QuestionDTO questionDto = new QuestionDTO {Id = RandomStringIdGenerator.GetUniqueId(),DatePosted=DateTime.Now,
                PostedUser=User.Identity.Name,QuestionDesc=model.Desc,QuestionTitlle=model.Title,ThemeId=themeId,UserId=User.Identity.GetUserId()};

            await QuestionService.CreateNew(questionDto);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Display Question
        public async Task<ActionResult> DisplayQuestions(string themeId)
        {
            List<QuestionDTO> questions = (List<QuestionDTO>)await QuestionService.GetQuestions();
            List<QuestionDTO> QuestionsChosenFromTheme = questions.Where(e => e.ThemeId == themeId).ToList();

                return View(QuestionsChosenFromTheme);
        }
        #endregion

        #region DELETE Question
        [Authorize(Roles = "admin")]
        public ActionResult DeleteQuestion(string id)
        {
            return View();
        }
        [HttpPost, ActionName("DeleteQuestion")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> RemoveQuestion(string id)
        {
            QuestionDTO question = await QuestionService.FindQuestionDtoById(id);
            try
            {
                if (question != null)
                {
                   await QuestionService.Delete(question);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region EDIT Question
        [HttpGet]
        public async Task<ActionResult> EditQuestion(string id)
        {
            QuestionDTO question = await QuestionService.FindQuestionDtoById(id);
            if (question != null)
            {
                return View(question);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public async Task<ActionResult> EditQuestion(QuestionDTO question)
        {
            await QuestionService.Edit(question);
            return RedirectToAction("DisplayThemes");
        }
        #endregion

        #endregion



        #region REPLIES Operations

        public async Task<ActionResult> DisplayReplies(string questionId)
        {
            List<ReplyDTO> replies = (List<ReplyDTO>)await ReplyService.GetAll();
            List<ReplyDTO> RepliesChosenFromQuestion = replies.Where(e => e.QuestionId == questionId).ToList();

            return View(RepliesChosenFromQuestion);
        }


        #endregion

    }
}