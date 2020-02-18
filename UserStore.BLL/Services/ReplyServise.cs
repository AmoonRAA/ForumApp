using System;
using System.Collections.Generic;
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
    class ReplyServise : IReplyService
    {
        IUnitOfWork Database { get; set; }

        public ReplyServise(IUnitOfWork UOW)
        {
            Database = UOW;
        }


        public async Task<OperationDetails> CreateNew(ReplyDTO replyDto)
        {

            Reply reply = await  Database.ReplyManager.GetById(replyDto.Id);
            if (reply==null)
            {
                reply = new Reply
                {
                    Id = replyDto.Id,
                    UserPosted = replyDto.UserPosted,
                    QuestionId = replyDto.QuestionId,
                    ReplyText = replyDto.ReplyText
                };
                await Database.ReplyManager.Create(reply);
                await Database.SaveAsync();
                return new OperationDetails(true, "Відповідь додано успішно!", "");
            }
            else
            {
                return new OperationDetails(false, "Сталася помилка", "");
            }
            
        }

        public async Task<OperationDetails> Delete(ReplyDTO replyDto)
        {
            Reply reply = await Database.ReplyManager.GetById(replyDto.Id);
            if (reply!=null)
            {
               await Database.ReplyManager.Delete(reply);
               await Database.SaveAsync();
                return new OperationDetails(true, "Відповідь видалено успішно!", "");
            }
            else
            {
                return new OperationDetails(true, "Сталася помилка!", "");
            }
        }

        public async Task<OperationDetails> Edit(ReplyDTO replyDto)
        {
            Reply reply = await Database.ReplyManager.GetById(replyDto.Id);
            if (reply != null)
            {

                await Database.ReplyManager.Update(reply);
                await Database.SaveAsync();
                return new OperationDetails(true, "Відповідь відредаговано успішно!", "");
            }
            else
            {
                return new OperationDetails(true, "Сталася помилка!", "");
            }
        }

        public async Task<ICollection<ReplyDTO>> GetAll()
        {
            IEnumerable<Reply> replies = await Database.ReplyManager.GetAll();

            ICollection<ReplyDTO> list= new List<ReplyDTO>();
            ReplyDTO dTO;
            foreach (Reply item in replies)
            {
                dTO = new ReplyDTO { Id = item.Id, QuestionId = item.QuestionId, UserPosted = item.UserPosted,
                    ReplyText = item.ReplyText };
                list.Add(dTO);
            }


            return list;
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
