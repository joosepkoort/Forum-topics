using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Interfaces;
using BL.ObjectFactories;
using Domain;
using Interfaces;
using Interfaces.Repositories;
using System.Globalization;

namespace BL.Services
{
    public class ForumTopicService : Service, IForumTopicService
    {
        private readonly IForumTopicRepository _forumTopicRepository;
        private readonly ForumTopicFactory _forumTopicFactory;

        public ForumTopicService(IForumTopicRepository forumTopicRepository)
        {
            _forumTopicRepository = forumTopicRepository;
            _forumTopicFactory = new ForumTopicFactory();
        }

        public ForumTopicDTO GetById(int id)
        {
            var topic = _forumTopicRepository.Find(id: id);
            if (topic == null)
            {
                return null;
            }
            return _forumTopicFactory.Create(forumTopic: topic);
        }

        public List<ForumTopicDTO> FindTopicByTitle(string title)
        {

            return _forumTopicRepository
            .All
            .Where(p => CultureInfo.CurrentCulture.CompareInfo.IndexOf(p.Title, title, CompareOptions.IgnoreCase) >= 0)
            .Select(selector: x => _forumTopicFactory.Create(x))
            .ToList();
        }

        public List<ForumTopicDTO> FindTopicByAuthor(string author)
        {
            return _forumTopicRepository
            .All
            .Where(p => CultureInfo.CurrentCulture.CompareInfo.IndexOf(p.Author, author, CompareOptions.IgnoreCase) >= 0)
            .Select(selector: x => _forumTopicFactory.Create(x))
            .ToList();
        }

        public bool ModifyTopicActiveStatus(int id, bool boolValue)
        {
            ForumTopic domain = _forumTopicRepository.Find(id: id);
            if (!ForumTopicIdCheck(id: id, forumTopicRepository: _forumTopicRepository))
            {
                return false;
            }
            domain.IsActive = boolValue;
            _forumTopicRepository.Update(entity: domain);
            _forumTopicRepository.SaveChanges();

            return true;
        }

        public List<ForumTopicDTO> GetAll()
        {
            return _forumTopicRepository
                .All
                .Select(selector: x => _forumTopicFactory.Create(forumTopic: x))
                .ToList();
        }

        public ForumTopicDTO AddNewTopic(ForumTopicDTO forumTopicDto)
        {
            ForumTopic domain = _forumTopicFactory.Create(forumTopicDto: forumTopicDto);

            if (!ValidateDomainModel(u: domain) ||
                !DoesHeadingExist(heading: domain.Title, forumTopicRepository: _forumTopicRepository))
            {
                return null;
            }

            domain.IsActive = true;

            var ret = _forumTopicRepository.Add(entity: domain);
            _forumTopicRepository.SaveChanges();

            return _forumTopicFactory.Create(forumTopic: ret);
        }

        public bool Update(ForumTopicDTO forumTopicDto)
        {
            Trace.WriteLine(message: forumTopicDto.ToString());
            ForumTopic newDomain = _forumTopicFactory.Create(forumTopicDto: forumTopicDto);
            ForumTopic domain = _forumTopicRepository.Find(id: forumTopicDto.Id);

            if (domain == null ||
                !ValidateDomainModel(u: newDomain))
            {
                return false;
            }

            domain.Title = newDomain.Title;
            domain.Intro = newDomain.Intro;
            domain.Body = newDomain.Body;
            domain.Created = newDomain.Created;
            domain.Author = newDomain.Author;
            domain.IsActive = newDomain.IsActive;

            _forumTopicRepository.Update(entity: domain);
            _forumTopicRepository.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            var ret = GetById(id: id);
            if (ret == null)
            {
                return false;
            }
            _forumTopicRepository.Remove(id: id);
            _forumTopicRepository.SaveChanges();
            return true;
        }
    }
}