using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ForumTopic : DomainBase
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Intro { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Created { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
