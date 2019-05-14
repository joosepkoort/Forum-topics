using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class ForumTopicDTO : BaseDto
    {
        public string Title { get; set; }
        public string Intro { get; set; }

        public string Body { get; set; }

        public string Created { get; set; }
        public string Author { get; set; }

        public bool IsActive { get; set; }
    }
}
