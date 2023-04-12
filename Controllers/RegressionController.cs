using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using INTEX_API.Data;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace INTEX_API.Controllers
{
    [ApiController]
    [Route("/regression")]
    public class RegressionController : ControllerBase
    {
        private InferenceSession _session;

        public RegressionController(InferenceSession session)
        {
            _session = new InferenceSession("Data/modelstuff2.onnx");
        }

        [HttpPost]
        public ActionResult Score(RegressionData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
                    {
                        NamedOnnxValue.CreateFromTensor("input", data.AsTensor())
                    });
            Tensor<float> score = result.First().AsTensor<float>();
            var prediction = new PredictNumeric { PredictionNumeric = score.First() };
            result.Dispose();
            return Ok(prediction);
        }
    }
}

