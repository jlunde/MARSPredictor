using System;
using System.IO;
using System.Linq;

using AForge.Neuro;
using AForge.Neuro.Learning;

namespace MARS
{
    class Program
    {
        const int NumInput = 12;
        const int NumOutput = 1;
        const double CutoffThreshold = .3;
        const int xFold = 10;

        const double LearningRate = 0.1;
        const double Momentum = 0.0;
        const double SigmoidAlphaValue = 0.5;
        const double ErrorThreshold = 0.1;
        const int MaxEpochs = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Neural Network Test Program");

            //Read from the input file
            var inputLines = File.ReadAllLines(@"C:\Identifi\nnoutput.csv");
            if (xFold > inputLines.Length)
            {
                Console.WriteLine("Too many folds input. Input file not large enough to support {0} folds", xFold);
                Console.WriteLine("Press any key to continue...");
                Console.Read();
                Environment.Exit(0);
            }

            double pred1Is1 = 0;
            double pred0Is0 = 0;
            double pred1Is0 = 0;
            double pred0Is1 = 0;

            var inputData = new double[inputLines.Length][];
            var outputData = new double[inputLines.Length][];
            for (var i = 0; i < inputLines.Length; i++)
            {
                inputData[i] = ExtractXValues(inputLines[i]);
                outputData[i] = ExtractOutputData(inputLines[i]);
            }

            var testIndex = 0;
            var lowIndex = 0;
            var highIndex = 0;

            while (testIndex < xFold)
            {
                lowIndex = highIndex;
                highIndex += (inputLines.Length / xFold);


                var network = new ActivationNetwork(
                    new BipolarSigmoidFunction(SigmoidAlphaValue),
                    NumInput, 12, 12, 1);
                var teacher = new BackPropagationLearning(network)
                {
                    LearningRate = LearningRate,
                    Momentum = Momentum,
                };

                var xValueData = inputData.Where((arr, index) => (index < lowIndex || index > highIndex)).ToArray();
                var tValueData = outputData.Where((arr, index) => (index < lowIndex || index > highIndex)).ToArray();

                var epoch = 1;

                while (epoch < MaxEpochs)
                {
                    var error = teacher.RunEpoch(xValueData, tValueData);

                    if (error < ErrorThreshold)
                    {
                        Console.WriteLine("Found weights and bias values that meet the error criterion at epoch " + epoch);
                        Console.ReadLine();
                        break;
                    }
                    epoch++;
                }

                for (int i = lowIndex; i < highIndex; i++)
                {

                    var xValue = inputData.Where((arr, index) => index == i).ToArray()[0];
                    var tValue = outputData.Where((arr, index) => index == i).ToArray()[0];
                    var yValue = network.Compute(xValue);

                    Console.WriteLine("Validate " + i + ":");
                    Console.Write("y value: ");
                    Helpers.ShowVector(yValue, 8, 8, true);

                    Console.Write("t value: ");
                    Helpers.ShowVector(tValue, 8, 8, true);

                    if ((yValue[0] > CutoffThreshold) && (tValue[0] == 1))
                    {
                        pred1Is1++;
                        Console.WriteLine("Predicted 1. Correct");
                    }
                    else if ((yValue[0] < CutoffThreshold) && (tValue[0] == 0))
                    {
                        pred0Is0++;
                        Console.WriteLine("Predicted 0. Correct");
                    }
                    else if ((yValue[0] > CutoffThreshold) && (tValue[0] == 0))
                    {
                        pred1Is0++;
                        Console.WriteLine("Predicted 1. Wrong!!!!!!!!!!");
                    }
                    else if ((yValue[0] < CutoffThreshold) && (tValue[0] == 1))
                    {
                        pred0Is1++;
                        Console.WriteLine("Predicted 0. Wrong!!!!!!!!!!");
                    }
                }
                testIndex++;

                Console.WriteLine("NumPred0is0 is " + pred0Is0);
                Console.WriteLine("NumPred1is1 is " + pred1Is1);
                Console.WriteLine("NumPred1is0 is " + pred1Is0);
                Console.WriteLine("NumPred0is1 is " + pred0Is1);
            }

            Console.WriteLine("All done");
            Console.WriteLine("Num Correct is " + (pred0Is0 + pred1Is1) + ". Out of " + inputLines.Length + " cases.");
            Console.WriteLine("Accuracy " + (pred0Is0 + pred1Is1) / inputLines.Length);

            Console.WriteLine("NumPred0is0 is " + pred0Is0);
            Console.WriteLine("NumPred1is1 is " + pred1Is1);
            Console.WriteLine("NumPred1is0 is " + pred1Is0);
            Console.WriteLine("NumPred0is1 is " + pred0Is1);

            Console.Read();
        }

        public static double[] ExtractOutputData(string currentLine)
        {
            double[] outputValues = new double[NumOutput];

            string[] split_line = currentLine.Split(',');
            int index = 0;
            for (int i = (split_line.Length - NumOutput); i < split_line.Length; i++)
            {
                outputValues[index] = Convert.ToDouble(split_line[i]);
                index++;
            }
            return outputValues;
        }

        public static double[] ExtractXValues(string currentLine)
        {
            double[] new_xValues = new double[NumInput];

            string[] split_line = currentLine.Split(',');
            int index = 0;
            for (int i = 0; i < split_line.Length - NumOutput; i++)
            {
                new_xValues[index] = Convert.ToDouble(split_line[i]);
                index++;
            }
            return new_xValues;
        }
    }

    public class Helpers
    {
        public static void ShowVector(double[] vector, int decimals, int valsPerLine, bool blankLine)
        {
            for (int i = 0; i < vector.Length; ++i)
            {
                if (i > 0 && i % valsPerLine == 0) // max of 12 values per row 
                    Console.WriteLine("");
                if (vector[i] >= 0.0) Console.Write(" ");
                Console.Write(vector[i].ToString("F" + decimals) + " "); // n decimals
            }
            if (blankLine) Console.Write("\n");
        }
    }
}
