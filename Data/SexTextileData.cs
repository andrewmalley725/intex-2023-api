using System;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.ComponentModel.DataAnnotations;

namespace intex_2023_api.Data
{
    public class SexTextileData
        {
        public float haircolor_rdepth { get; set; }
        public float length { get; set; }
        public float ageatdeath_a { get; set; }
        public float wrapping_bHairColor_brown { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            haircolor_rdepth, length, ageatdeath_a, wrapping_bHairColor_brown
            };

            int[] dimensions = new int[] { 1, 4 };

            DenseTensor<float> tensor = new DenseTensor<float>(data, dimensions);

            return tensor;
        }
    }
}

