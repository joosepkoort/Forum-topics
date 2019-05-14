using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Helpers
{
    class DbInitializator : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            List<ForumTopic> forumTopics = new List<ForumTopic>();
            forumTopics.Add(item: new ForumTopic()
            {
                Title = "vr2",
                Intro = "must read",
                Body = "long story",
                Created = "2007",
                Author = "Joosep",
                IsActive = true
            });
            forumTopics.Add(item: new ForumTopic()
            {
                Title = "vr3",
                Intro = "must read2",
                Body = "short story",
                Created = "2017",
                Author = "Joosep",
                IsActive = true
            });



            context.ForumTopics.Add(forumTopics[0]);
            context.ForumTopics.Add(forumTopics[1]);
            context.SaveChanges();

            List<Answer> answers = new List<Answer>();
            answers.Add(item: new Answer()
            {
                Title = "pealkiri",
                Text = "text",
                Author = "Joosep",
                Created = "2017",
                ForumTopicId = forumTopics[0].Id
            });
            answers.Add(item: new Answer()
            {
                Title = "pealkiri",
                Text = "test",
                Author = "Joosep",
                Created = "2016",
                ForumTopicId = forumTopics[0].Id
            });
            answers.Add(item: new Answer()
            {
                Title = "hea",
                Text = "Test",
                Author = "Joosep",
                Created = "2017",
                ForumTopicId = forumTopics[0].Id
            });

            context.Answers.Add(answers[0]);
            context.Answers.Add(answers[1]);
            context.SaveChanges();
        }

    }
}
