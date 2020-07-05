using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelBuilder.DataModel
{
    public class ImageLabelPredictions
    {
        [ColumnName("softmax2")]
        public float[] PredictedLabels { get; set; }
    }
}
