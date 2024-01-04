using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Dto.Client
{
    public class ExamTaskDto
    {
        public string ExamName { get; set; }

        public int ReviewExamTaskID { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
