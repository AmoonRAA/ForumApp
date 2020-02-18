using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.BLL.DTO;
using Forum_Marchuk.BLL.Infrastructure;

namespace Forum_Marchuk.BLL.Interfaces
{
    public interface IQuestionService:IDisposable
    {
        Task<OperationDetails> CreateNew(QuestionDTO questionDTO);
        Task<OperationDetails> Edit(QuestionDTO questionDTO);
        Task<OperationDetails> Delete(QuestionDTO questionDTO);
        Task<QuestionDTO> FindQuestionDtoById(string id);
        Task<ICollection<QuestionDTO>> GetQuestions();
        //Task<ICollection<ReplyDTO>> GetReplies();
    }
}
