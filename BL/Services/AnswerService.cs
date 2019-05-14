using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Interfaces;
using BL.ObjectFactories;
using Domain;
using Interfaces;
using Interfaces.Repositories;

namespace BL.Services
{
    public class AnswerService : Service, IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IForumTopicRepository _forumTopicRepository;
        private readonly AnswerFactory _answerFactory;

        public AnswerService(IAnswerRepository answerRepository,
            IForumTopicRepository forumTopicRepository)
        {
            _answerRepository = answerRepository;
            _forumTopicRepository = forumTopicRepository;
            _answerFactory = new AnswerFactory();
        }


        public AnswerDTO GetById(int id)
        {
            var answer = _answerRepository.Find(id: id);
            if (answer == null)
            {
                return null;
            }
            return _answerFactory.Create(answer: answer);
        }

        public List<AnswerDTO> FindAnswersbyAuthor(string answer)
        {
            return _answerRepository
                .FindAnswersbyAuthor(answer: answer)
                .Select(selector: x => _answerFactory.Create(answer: x))
                .ToList();

        }


        public List<AnswerDTO> GetAll()
        {
            return _answerRepository
                .All
                .Select(selector: x => _answerFactory.Create(answer: x))
                .ToList();
        }

        public AnswerDTO AddNewAnswer(AnswerDTO answerDto)
        {
            //create ForumTopic model
            Answer domain = _answerFactory.Create(answerDTO: answerDto);

            if (!ValidateDomainModel(u: domain) ||
                !ForumTopicIdCheck(id: domain.ForumTopicId, forumTopicRepository: _forumTopicRepository))
            {
                return null;
            }

            var ret = _answerRepository.Add(entity: domain);
            _answerRepository.SaveChanges();

            return _answerFactory.Create(answer: ret);
        }

        public bool Update(AnswerDTO answerDto)
        {
            Answer newDomain = _answerFactory.Create(answerDTO: answerDto);
            Answer domain = _answerRepository.Find(id: answerDto.Id);

            if (domain == null ||
                !ValidateDomainModel(u: newDomain) ||
                !ForumTopicIdCheck(id: newDomain.ForumTopicId, forumTopicRepository: _forumTopicRepository))
            {
                return false;
            }

            domain.Title = newDomain.Title;
            domain.Text = newDomain.Text;
            domain.Author = newDomain.Author;
            domain.Created = newDomain.Created;
            domain.ForumTopicId = newDomain.ForumTopicId;


            _answerRepository.Update(entity: domain);
            _answerRepository.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            var ret = GetById(id: id);
            if (ret == null)
            {
                return false;
            }
            _answerRepository.Remove(id: id);
            _answerRepository.SaveChanges();
            return true;
        }
    }
}
