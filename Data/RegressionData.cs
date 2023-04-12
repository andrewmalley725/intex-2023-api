using System;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.ComponentModel.DataAnnotations;

namespace INTEX_API.Data
{
    public class RegressionData
    {
        public float SquareNorthSouth { get; set; }
        public float SquareEastWest { get; set; }
        public float PreservationIndex { get; set; }
        public float FemurHeadDiameter { get; set; }
        public float HumerusHeadDiameter { get; set; }
        public float FemurLength { get; set; }
        public float HumerusLength { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            SquareNorthSouth, SquareEastWest, PreservationIndex, FemurHeadDiameter, HumerusHeadDiameter,FemurLength, HumerusLength
            };

            int[] dimensions = new int[] { 1, 7 };

            DenseTensor<float> tensor = new DenseTensor<float>(data, dimensions);

            return tensor;
        }
    }
}

