using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace intex_2023_api.Data
{
    public class WrappingData
    {
        public float depth { get; set; }
        public float FemurLength { get; set; }
        public float adultsubadult_ { get; set; }
        public float HairColor_brown { get; set; }
        public float Area_ne { get; set; }
        public float Area_se { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                depth, FemurLength, adultsubadult_, HairColor_brown, Area_ne,
                Area_se
            };

            int[] dimensions = new int[] { 1, 6 };

            DenseTensor<float> tensor = new DenseTensor<float>(data, dimensions);

            return tensor;
            //return new DenseTensor<float>(data.Cast<float>().ToArray(), dimensions);
        }
    }
}

