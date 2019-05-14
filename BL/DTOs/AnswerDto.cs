using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
   public  class AnswerDTO : BaseDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public string Created { get; set; }

        public int ForumTopicId { get; set; }
    }
}
