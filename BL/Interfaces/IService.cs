using Interfaces.Repositories;
using System;

namespace BL.Services
{
    public interface IService
    {
        string LastErrorMessage { get;}
        bool ValidateDomainModel(Object u);

        bool ForumTopicIdCheck(int id, IForumTopicRepository forumTopicRepository);
    }
}
