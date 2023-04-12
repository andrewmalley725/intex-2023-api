using System;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.ComponentModel.DataAnnotations;

namespace intex_2023_api.Data
{
    public class SexData
    {
        public float depth { get; set; }
        public float length { get; set; }
        public float westtofeet { get; set; }
        public float wrapping_b { get; set; }
        public float area_sw { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            westtofeet, depth, length, wrapping_b, area_sw
            };

            int[] dimensions = new int[] { 1, 5 };

            DenseTensor<float> tensor = new DenseTensor<float>(data, dimensions);

            return tensor;
        }
    }
}

