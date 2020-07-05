using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Data
{
    public class ImageClassificationResult
    {
        public string Label { get; set; }
        public float Probability { get; set; }
    }
}
