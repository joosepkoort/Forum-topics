using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces.Repositories;

namespace BL.Services
{
    public class Service : IService
    {
        public string LastErrorMessage { get; private set; }


        public bool ValidateDomainModel(Object u)
        {
            var context = new ValidationContext(instance: u, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(
                    instance: u,
                    validationContext: context,
                    validationResults: validationResults,
                    validateAllProperties: true);

            StringBuilder builder = new StringBuilder();
            foreach (var item in validationResults)
            {
                builder.Append(value: item.ErrorMessage);
            }
            LastErrorMessage = builder.ToString();

            return isValid;
        }

        public bool ForumTopicIdCheck(int id, IForumTopicRepository forumTopicRepository)
        {
            var person = forumTopicRepository.Find(id: id);
            if (person != null)
            {
                return true;
            }
            LastErrorMessage = "ForumTopic not found";
            return false;
        }

        public bool DoesHeadingExist(string heading, IForumTopicRepository forumTopicRepository)
        {
            var obj = forumTopicRepository.FindTopicByTitle(title: heading);
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
