using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemyCalculator.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult SomaGet( string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        
        return BadRequest("Invalid Input");
        
    }
    
    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult SubtracaoGet(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }
        
        return BadRequest("Invalid Input");
    }

    [HttpGet("mul/{firstNumber}/{secondNumber}")]
    public IActionResult MultiplicaçãoGet(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mul = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mul.ToString());
        }
        
        return BadRequest("Invalid Input");
    }
    
    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult DivisaoGet(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(div.ToString());
        }
        
        return BadRequest("Invalid Input");
    }

    [HttpGet("med/{firstNumber}/{secondNumber}")]
    public IActionResult MediaGet(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
            return Ok(med.ToString());
        }
        
        return BadRequest("Invalid Input");
    }
    
    [HttpGet("raizquadrada/{firstNumber}")]
    public IActionResult RaizQuadradaGet(string firstNumber)
    {
        if (IsNumeric(firstNumber) )
        {
            var med = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(med.ToString());
        }
        
        return BadRequest("Invalid Input");
    }
    
    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber,
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);
        
        return isNumber;
    }
    
    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;

        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        
        return 0;
    }

}