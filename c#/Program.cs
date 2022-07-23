﻿using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using Mat = OpenCvSharp.Mat;
using OutputArray = OpenCvSharp.OutputArray;

namespace godot_net_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string pathToModel = @"C:\Users\Gizon\Desktop\Study\moais\secondCourse\courseReasearch\pythonProject37\cnn.h5.onnx";
            const string pathToPng = @"C:\Users\Gizon\Desktop\Study\moais\secondCourse\courseReasearch\1.jpg";
            
            var mlContext = new MLContext();

            // Load trained model
            var modelScorer = new OnnxModelScorer(pathToModel, mlContext);

            var floats = GetImageFromPath(pathToPng);
            var modelInput = new List<ModelInput> {new() {Input = floats.ToArray()}};
            var prediction= GetPrediction(mlContext, modelInput, modelScorer);

            ConsoleWriteResult(prediction);

            /*
            var pyInput = new List<ModelInput>()
            {
                new ModelInput
                {
                    Input = new[] {
                            0, 0, 0, 0, 0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.32941177f,
                            0.7254902f,
                            0.62352943f,
                            0.5921569f,
                            0.23529412f,
                            0.14117648f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.87058824f,
                            0.99607843f,
                            0.99607843f,
                            0.99607843f,
                            0.99607843f,
                            0.94509804f,
                            0.7764706f,
                            0.7764706f,
                            0.7764706f,
                            0.7764706f,
                            0.7764706f,
                            0.7764706f,
                            0.7764706f,
                            0.7764706f,
                            0.6666667f,
                            0.20392157f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.2627451f,
                            0.44705883f,
                            0.28235295f,
                            0.44705883f,
                            0.6392157f,
                            0.8901961f,
                            0.99607843f,
                            0.88235295f,
                            0.99607843f,
                            0.99607843f,
                            0.99607843f,
                            0.98039216f,
                            0.8980392f,
                            0.99607843f,
                            0.99607843f,
                            0.54901963f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.06666667f,
                            0.25882354f,
                            0.05490196f,
                            0.2627451f,
                            0.2627451f,
                            0.2627451f,
                            0.23137255f,
                            0.08235294f,
                            0.9254902f,
                            0.99607843f,
                            0.41568628f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.3254902f,
                            0.99215686f,
                            0.81960785f,
                            0.07058824f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.08627451f,
                            0.9137255f,
                            1,
                            0.3254902f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.5058824f,
                            0.99607843f,
                            0.93333334f,
                            0.17254902f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.23137255f,
                            0.9764706f,
                            0.99607843f,
                            0.24313726f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.52156866f,
                            0.99607843f,
                            0.73333335f,
                            0.01960784f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.03529412f,
                            0.8039216f,
                            0.972549f,
                            0.22745098f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.49411765f,
                            0.99607843f,
                            0.7137255f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.29411766f,
                            0.9843137f,
                            0.9411765f,
                            0.22352941f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.07450981f,
                            0.8666667f,
                            0.99607843f,
                            0.6509804f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.01176471f,
                            0.79607844f,
                            0.99607843f,
                            0.85882354f,
                            0.13725491f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.14901961f,
                            0.99607843f,
                            0.99607843f,
                            0.3019608f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.12156863f,
                            0.8784314f,
                            0.99607843f,
                            0.4509804f,
                            0.00392157f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.52156866f,
                            0.99607843f,
                            0.99607843f,
                            0.20392157f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.23921569f,
                            0.9490196f,
                            0.99607843f,
                            0.99607843f,
                            0.20392157f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.4745098f,
                            0.99607843f,
                            0.99607843f,
                            0.85882354f,
                            0.15686275f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0.4745098f,
                            0.99607843f,
                            0.8117647f,
                            0.07058824f,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0,
                        }
                }
            };
            
            // Create IDataView from empty list to obtain input data schema
            var dataView = mlContext.Data.LoadFromEnumerable(pyInput);
            
            // Get prediction
            var result = modelScorer.Score(dataView);

            Console.WriteLine("[");
            foreach (var f in result)
            {
                Console.Write($"{f}\n");
            }
            Console.Write("]");*/
        }

        private static void ConsoleWriteResult(IEnumerable<float>? prediction)
        {
            Console.WriteLine("[");
            foreach (var f in prediction)
            {
                Console.Write($"{f}\n");
            }

            Console.Write("]");
        }

        private static IEnumerable<float> GetPrediction(MLContext? mlContext, IEnumerable<ModelInput> modelInput, OnnxModelScorer? modelScorer)
        {
            var dataView = mlContext.Data.LoadFromEnumerable(modelInput);
            // Get prediction
            var prediction = modelScorer.Score(dataView);

            return prediction;
        }

        private static IEnumerable<float> GetImageFromPath(string pathToPng)
        {
            var image = Cv2.ImRead(pathToPng, ImreadModes.Grayscale);
            var smaller = new Mat();
            Cv2.Resize(image, smaller, new Size(28, 28));
            var floats = smaller.Dump().ToIEnumerableFloat();
            return floats;
        }
    }
}