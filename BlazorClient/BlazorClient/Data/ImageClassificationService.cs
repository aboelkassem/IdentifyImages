using BlazorClient.Utilities;
using Microsoft.Extensions.ML;
using ModelBuilder.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Data
{
    public class ImageClassificationService
    {
        private PredictionEnginePool<ImageInputData, ImageLabelPredictions> _predictionEnginePool;
        private string[] _labels;

        public ImageClassificationService(PredictionEnginePool<ImageInputData, ImageLabelPredictions> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
            // Read the labels from txt file available in the output bin folder
            string labelsFileLocation = PathUtilities.GetPathFromBinFolder(Path.Combine("TFInceptionModel", "imagenet_comp_graph_label_strings.txt"));
            _labels = System.IO.File.ReadAllLines(labelsFileLocation);
        }

        public ImageClassificationResult Classify(MemoryStream image)
        {
            // Convert to image to Bitmap and load into an ImageInputData 
            Bitmap bitmapImage = (Bitmap)Image.FromStream(image);
            ImageInputData imageInputData = new ImageInputData { Image = bitmapImage };

            // Run the model
            var imageLabelPredictions = _predictionEnginePool.Predict(imageInputData);

            // Find the label with the highest probability 
            // and return the ImageClassificationResult instance
            float[] probabilities = imageLabelPredictions.PredictedLabels;
            var maxProbability = probabilities.Max();
            var maxProbabilityIndex = probabilities.AsSpan().IndexOf(maxProbability);
            
            return new ImageClassificationResult()
            {
                Label = _labels[maxProbabilityIndex],
                Probability = maxProbability
            };
        }
    }
}
