﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces.Repositories
{
    public interface IForumTopicRepository : IRepository<ForumTopic>
    {
        ForumTopic FindTopicByTitle(string title);

        ForumTopic FindByAuthor(string author);
    }
}
