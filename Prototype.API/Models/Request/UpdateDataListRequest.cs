using System;
using System.Collections.Generic;
using System.Text;

namespace SampleNetCore.Model.Models.Request
{
    public class UpdateDataListRequest
    {
        public string SamplingTime { get; set; }
        public string Properties { get; set; }
        public string stFilePath { get; set; }
    }
}
