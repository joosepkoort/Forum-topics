using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Answer : DomainBase
    {

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }
    
        [Required]
        public string Created { get; set; }

        [Required]
        public string Text { get; set; }
        
        public int ForumTopicId { get; set; }

        [ForeignKey(name: "ForumTopicId")]
        public virtual ForumTopic ForumTopic { get; set; }
    }
}
