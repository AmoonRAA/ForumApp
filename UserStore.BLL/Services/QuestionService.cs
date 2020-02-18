using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.BLL.DTO;
using Forum_Marchuk.BLL.Infrastructure;
using Forum_Marchuk.BLL.Interfaces;
using Forum_Marchuk.DAL.Entities;
using Forum_Marchuk.DAL.Interfaces;

namespace Forum_Marchuk.BLL.Services
{
    class QuestionService : IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork UOW)
        {
            Database = UOW;
        }
        public async Task<OperationDetails> CreateNew(QuestionDTO questionDTO)
        {

            Question question = await Database.QuestionManager.GetById(questionDTO.Id);
            if (question == null)
            {
                question = new Question
                {
                    QuestionTitlle=questionDTO.QuestionTitlle,
                    QuestionDesc=questionDTO.QuestionDesc,
                    PostedUser=questionDTO.PostedUser,
                    DatePosted=questionDTO.DatePosted,
                    ThemeId=questionDTO.ThemeId,
                    Id=questionDTO.Id,
                    ClientId=questionDTO.UserId
                    
                };
                await Database.QuestionManager.Create(question);
                await Database.SaveAsync();
                return new OperationDetails(true, "Питання додано успішно!", "");
            }
            else
            {
                return new OperationDetails(false, "Сталася помилка", "");
            }
        }

        public async Task<OperationDetails> Delete(QuestionDTO questionDTO)
        {
            Question question = await Database.QuestionManager.GetById(questionDTO.Id);
            if (question != null)
            {
                await Database.QuestionManager.Delete(question);
                await Database.SaveAsync();
                return new OperationDetails(true, "Питання видалено успішно!", "");
            }
            else
            {
                return new OperationDetails(true, "Сталася помилка!", "");
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> Edit(QuestionDTO questionDTO)
        {
            Question question = await Database.QuestionManager.GetById(questionDTO.Id);
            if (question != null)
            {
                question.QuestionTitlle = questionDTO.QuestionTitlle;
                question.QuestionDesc = questionDTO.QuestionDesc;
                await Database.SaveAsync();
                return new OperationDetails(true, "Питання відредаговано успішно!", "");
            }
            else
            {
                return new OperationDetails(true, "Сталася помилка!", "");
            }
        }

        public async Task<ICollection<QuestionDTO>> GetQuestions()
        {
            IEnumerable<Question> questions = await Database.QuestionManager.GetAll();

            ICollection<QuestionDTO> list = new List<QuestionDTO>();
            QuestionDTO dTO;
            foreach (Question item in questions)
            {
                dTO = new QuestionDTO
                {
                    Id = item.Id,
                    DatePosted=item.DatePosted,
                    PostedUser=item.PostedUser,
                    QuestionDesc=item.QuestionDesc,
                    QuestionTitlle=item.QuestionTitlle,
                    ThemeId=item.ThemeId,
                    UserId=item.ClientId
                };
                list.Add(dTO);
            }


            return list;
        }

        public async Task<QuestionDTO> FindQuestionDtoById(string id)
        {
           Question question = await Database.QuestionManager.GetById(id);
           QuestionDTO dto = new QuestionDTO {Id=question.Id,DatePosted=question.DatePosted,PostedUser=question.PostedUser
             ,QuestionDesc=question.QuestionDesc,QuestionTitlle=question.QuestionTitlle,ThemeId=question.ThemeId,UserId=question.ClientId};
            return dto;
        }




    }
}
