using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        List<Answer> FindAnswersbyAuthor(string answer);
    }
}
