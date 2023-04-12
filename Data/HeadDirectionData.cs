using System;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.ComponentModel.DataAnnotations;

namespace intex_2023_api.Data
{
    public class HeadDirectionData
    {
        public float depth { get; set; }
        public float samplescollected_unknown { get; set; }
        public float Area_sw { get; set; }
  

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                    depth, samplescollected_unknown, Area_sw
            };

            int[] dimensions = new int[] { 1, 3 };

            DenseTensor<float> tensor = new DenseTensor<float>(data, dimensions);

            return tensor;
        }
    }
}
