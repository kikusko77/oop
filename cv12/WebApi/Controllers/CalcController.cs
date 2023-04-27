using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpPost(Name = "Calculate")]
        public decimal Post([FromBody] CalcDTO calcDTO) => _ = calcDTO.Operation switch
        {
            "plus" => calcDTO.Operand1 + calcDTO.Operand2,
            "minus" => calcDTO.Operand1 - calcDTO.Operand2,
            "krat" => calcDTO.Operand1 * calcDTO.Operand2,
            "delene" => calcDTO.Operand1 / calcDTO.Operand2,
            _ => throw new ArgumentException("fail")
        };



    }
}
