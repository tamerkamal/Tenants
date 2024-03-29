﻿using Newtonsoft.Json;

namespace Base.Helpers.Models
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}