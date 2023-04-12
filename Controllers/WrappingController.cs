using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using intex_2023_api.Data;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace intex_2023_api.Controllers
{
    [ApiController]
    [Route("/wrapping")]
    public class WrappingController : ControllerBase
    {
        private InferenceSession _session;

        public WrappingController()
        {
            _session = new InferenceSession("Data/wrappingmodel.onnx");
        }

        [HttpPost]
        public ActionResult Score(WrappingData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
                    {
                        NamedOnnxValue.CreateFromTensor("feature_input", data.AsTensor())
                    });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First() };
            result.Dispose();
            return Ok(prediction);
        }
    }
}