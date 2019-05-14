using BL.DTOs;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IForumTopicService : IService
    {
        ForumTopicDTO GetById(int id);

        List<ForumTopicDTO> FindTopicByTitle(string heading);

        List<ForumTopicDTO> FindTopicByAuthor(string author);

        bool ModifyTopicActiveStatus(int id, bool boolValue);

        List<ForumTopicDTO> GetAll();

        ForumTopicDTO AddNewTopic(ForumTopicDTO forumTopicDTO);

        bool Update(ForumTopicDTO forumTopicDTO);

        bool DeleteById(int id);
    }
}
