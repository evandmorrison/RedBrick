namespace RedBrick.Repositories
{
    public interface ICodeTestRepository
    {
        List<bool> CheckStrings(List<string> strings);
        double GetAreaOfTriangle(double sideOne, double sideTwo, double sideThree);
        List<int> GetDivisors(int number);
        List<int> GetMostCommonNumbers(List<int> numbers);
    }

    public class CodeTestRepository : ICodeTestRepository
    {
        public List<Boolean> CheckStrings(List<string> strings)
        {
            var result = new List<Boolean>();
            foreach (var s in strings)
            {
                if (s == null || s.Length == 0)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);

                }
            }

            return result;
        }

        public List<int> GetDivisors(int number)
        {
            var result = new List<int>();

            for (int i = 1; i < number; i++)
            {
                if ((number % i) == 0)
                {
                    result.Add(i);
                }
            }

            result.Add(number);
            return result;
        }

        public double GetAreaOfTriangle(double sideOne, double sideTwo, double sideThree)
        {
            var p = (sideOne + sideTwo + sideThree) / 2;
            
            return Math.Sqrt(p * (p - sideOne) * (p - sideTwo) * (p - sideThree));
        }

        public List<int> GetMostCommonNumbers(List<int> numbers)
        {
            var result = new List<int>();
            var highestFrequency = 1;

            var frequencies = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (!frequencies.ContainsKey(number))
                {
                    frequencies.Add(number, 1);
                }
                else
                {
                    frequencies[number]++;
                    if (frequencies[number] > highestFrequency)
                    {
                        highestFrequency = frequencies[number];
                    }
                }
            }
            var mostFrequent = frequencies.Where(x => x.Value == highestFrequency);

            foreach (var number in mostFrequent)
            {
                result.Add(number.Key);
            }
            return result;
        }
    }
}