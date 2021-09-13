using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
