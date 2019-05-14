using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BL.ObjectFactories
{
    class AnswerFactory
    {
        public AnswerDTO Create(Answer answer)
        {
            return new AnswerDTO()
            {
                Id = answer.Id,
                Title = answer.Title,
                Text = answer.Text,
                Author = answer.Author,
                Created = answer.Created,
                ForumTopicId = answer.ForumTopicId
            };
        }

        public Answer Create(AnswerDTO answerDTO)
        {
            return new Answer()
            {
                Id = answerDTO.Id,
                Title = answerDTO.Title,
                Text = answerDTO.Text,
                Author = answerDTO.Author,
                Created = answerDTO.Author,
                ForumTopicId = answerDTO.ForumTopicId
            };
        }
    }
}
