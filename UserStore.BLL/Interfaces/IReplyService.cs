using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.BLL.DTO;
using Forum_Marchuk.BLL.Infrastructure;
using Forum_Marchuk.DAL.Entities;

namespace Forum_Marchuk.BLL.Interfaces
{
    public interface IReplyService:IDisposable
    {
        Task<OperationDetails> CreateNew(ReplyDTO replyDto);
        Task<OperationDetails> Edit(ReplyDTO replyDto);
        Task<OperationDetails> Delete(ReplyDTO replyDto);
        Task<ICollection<ReplyDTO>> GetAll();

    }
}
