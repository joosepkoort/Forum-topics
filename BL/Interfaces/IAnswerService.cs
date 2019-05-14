using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL.DTOs;


namespace BL.Interfaces
{
    public interface IAnswerService : IService
    {
        AnswerDTO GetById(int id);

        List<AnswerDTO> FindAnswersbyAuthor(string author);

        List<AnswerDTO> GetAll();

        AnswerDTO AddNewAnswer(AnswerDTO answerDTO);

        bool Update(AnswerDTO answerDTO);

        bool DeleteById(int id);
    }
}
