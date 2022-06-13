using Microsoft.AspNetCore.Mvc;
using RedBrick.Repositories;

namespace RedBrick.Controllers
{
    [ApiController]
    public class CodeTestController : ControllerBase
    {
        private readonly ICodeTestRepository codeTestRepository;

        public CodeTestController(ICodeTestRepository codeTestRepository)
        {
            this.codeTestRepository = codeTestRepository;
        }

        [HttpGet("string-test")]
        public List<Boolean> TestString()
        {
            var strings = new List<string> { null, "a", "", "null" };
            return this.codeTestRepository.CheckStrings(strings);
        }

        [HttpGet("get-divisors/{input}")]
        public List<int> TestString([FromRoute] int input)
        {
            return this.codeTestRepository.GetDivisors(input);
        }

        [HttpGet("get-area-of-triangle")]
        public double TestString([FromQuery] double sideOne, [FromQuery] double sideTwo, [FromQuery] double sideThree)
        {
            if (sideOne <= 0 || sideTwo <= 0 || sideThree <= 0)
            {
                throw new InvalidTriangleException();
            }
            return this.codeTestRepository.GetAreaOfTriangle(sideOne, sideTwo, sideThree);
        }

        [HttpGet("common-number-test")]
        public List<int> GetMostCommonNumbers()
        {
            var numbers = new List<int> {5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4} ;
            return this.codeTestRepository.GetMostCommonNumbers(numbers);
        }

        class InvalidTriangleException : Exception
        {
            public InvalidTriangleException()
                : base(String.Format("Invalid Triangle"))
            {
            }
        }
    }
}