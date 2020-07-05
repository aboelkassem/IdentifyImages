using Microsoft.ML;
using ModelBuilder.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ModelBuilder
{
    class ModelBuilder
    {
        private string _tensorFlowModelFilePath;
        private string _mlnetOutputZipFilePath;

        public ModelBuilder(string tensorFlowModelFilePath, string mlnetOutputZipFilePath)
        {
            _tensorFlowModelFilePath = tensorFlowModelFilePath;
            _mlnetOutputZipFilePath = mlnetOutputZipFilePath;
        }

        public void Run()
        {
            // Create new model context
            var mlContext = new MLContext();

            // Define the model pipeline:
            //    1. loading and resizing the image
            //    2. extracting image pixels
            //    3. running pre-trained TensorFlow model
            var pipeline = mlContext.Transforms.ResizeImages(
                    outputColumnName: "input",
                    imageWidth: 224,
                    imageHeight: 224,
                    inputColumnName: nameof(ImageInputData.Image)
                )
                .Append(mlContext.Transforms.ExtractPixels(
                    outputColumnName: "input",
                    interleavePixelColors: true,
                    offsetImage: 117)
                )
                .Append(mlContext.Model.LoadTensorFlowModel(_tensorFlowModelFilePath)
                    .ScoreTensorFlowModel(
                        outputColumnNames: new[] { "softmax2" },
                        inputColumnNames: new[] { "input" },
                        addBatchDimensionInput: true));

            // Train the model
            // Since we are simply using a pre-trained TensorFlow model, 
            // we can "train" it against an empty dataset
            var emptyTrainingSet = mlContext.Data.LoadFromEnumerable(new List<ImageInputData>());

            ITransformer mlModel = pipeline.Fit(emptyTrainingSet);

            // Save/persist the model to a .ZIP file
            // This will be loaded into a PredictionEnginePool by the 
            // Blazor application, so it can classify new images
            mlContext.Model.Save(mlModel, null, _mlnetOutputZipFilePath);

            // Create some predictions from output file zip,
            // loading the model from the zip file
            DataViewSchema predictionPipelineSchema;
            mlModel = mlContext.Model.Load(_mlnetOutputZipFilePath, out predictionPipelineSchema);

            // create a prediction for classifying one image at a time, taking input data, model, output 
            var predictionEngine = mlContext.Model.CreatePredictionEngine<ImageInputData, ImageLabelPredictions>(mlModel);


            // loading images for some tests
            var image = (Bitmap)Bitmap.FromFile("../../SampleImages/toaster.jpg");
            var input = new ImageInputData { Image = image };
            var prediction = predictionEngine.Predict(input);

            // get the labels of prediction that showing probability
            var maxProbability = prediction.PredictedLabels.Max();
            var labelIndex = prediction.PredictedLabels.AsSpan().IndexOf(maxProbability);
            var allLabels = System.IO.File.ReadAllLines("TFInceptionModel/imagenet_comp_graph_label_strings.txt");
            var classifiedLabel = allLabels[labelIndex];

            Console.WriteLine($"Test input image 'toaster.jpg' predicted as '{classifiedLabel}' with probability {100 * maxProbability}%");
        }

    }
}
