using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.APIGoogle
{
    public class OpeningHours
    {
        public bool open_now { get; set; }
        public List<object> weekday_text { get; set; }
    }
}
