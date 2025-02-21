namespace LeetCode
{
    public class Test
    {
        public static List<int> NumCheck()
        {
            int num = 5746;
            int numLength = num.ToString().Length;
            List<int> result = new List<int>();

            for (int i = numLength; i > 0; i--)
            {
                var remainder = (int)(num % (Math.Pow(10, i - 1)));
                result.Add(num - remainder);
                num = remainder;
            }

            Console.WriteLine(result);

            return result;

        }


    }
}
