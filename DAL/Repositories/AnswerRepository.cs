using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces;

namespace DAL.Repositories
{
    public class AnswerRepository : EfRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(IAppDataContext dbContext) : base(dbContext: dbContext)
        {

        }

        public List<Answer> FindAnswersbyAuthor(string answer)
        {
            return RepositoryDbSet
                .Where(x => x.Author.ToLower().Contains(answer.ToLower()))
                .ToList();
        }
    }
}
