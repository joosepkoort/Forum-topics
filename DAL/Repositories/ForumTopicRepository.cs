using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces;
using Interfaces.Repositories;

namespace DAL.Repositories
{
    public class ForumTopicRepository : EfRepository<ForumTopic>, IForumTopicRepository
    {
        public ForumTopicRepository(IAppDataContext dbContext) : base(dbContext: dbContext)
        {

        }

        public ForumTopic FindTopicByTitle(string title)
        {
            return RepositoryDbSet
                .Where(p => p.Title.ToLower().Contains(title.ToLower()))
                .FirstOrDefault();
        }

        public ForumTopic FindByAuthor(string author)
        {
            return RepositoryDbSet
                .Where(p => p.Author.ToLower().Contains(author.ToLower()))
                .FirstOrDefault();
        }
    }
}