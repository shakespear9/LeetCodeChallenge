using System.Text;

namespace LeetCode
{
    public class EasySolution
    {
        public static bool IsPalindrome(int x)
        {
            string original = x.ToString();
            var charArray = original.ToCharArray();
            Array.Reverse(charArray);
            var reverse = new string(charArray);
            if (original == reverse.ToString()) return true;


            return false;

        }

        public static bool IsPalindrome2(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) return false;


            int reversedHalf = 0;
            while (x > reversedHalf)
            {
                // take 2nd half of number to compare the 1st half of number by divide by 10 for each loop
                reversedHalf = reversedHalf * 10 + x % 10;
                x /= 10;
            }

            return x == reversedHalf || x == reversedHalf / 10;
        }

        enum Roman
        {
            O = 0,
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000,
        }

        public static int RomanToInt(string s)
        {
            var result = 0;
            Roman beforeSymbol = Roman.O;

            for (var i = 0; i < s.ToCharArray().Length; i++)
            {
                var symbol = (Roman)Enum.Parse(typeof(Roman), s[i].ToString());
                if ((beforeSymbol != Roman.O) && (beforeSymbol < symbol))
                {
                    result = result - (int)beforeSymbol * 2 + (int)symbol;
                    beforeSymbol = Roman.O;
                }
                else
                {
                    result = result + (int)symbol;
                    beforeSymbol = symbol;
                }

            }

            return result;

        }

        public string LongestCommonPrefix(string[] strs)
        {
            var mainString = strs[0];

            for (var i = 1; i < strs.Length; i++)
            {
                var tempMainString = mainString;
                mainString = String.Empty;

                var maxLength = tempMainString.Length > strs[i].Length ? strs[i].Length : tempMainString.Length;
                for (var j = 0; j < maxLength; j++)
                {

                    if (tempMainString[j] == strs[i][j])
                    {
                        mainString += tempMainString[j];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return mainString;
        }

        public string LongestCommonPrefixLinq(string[] strs)
        {
            StringBuilder sb = new();
            string shortest = strs.OrderBy(s => s.Length).First();

            foreach (var (c, i) in shortest.Select((c, i) => (c, i)))
            {
                if (strs.Any(s => s[i] != c)) break;
                sb.Append(c);
            }

            return sb.ToString();
        }

        public bool IsValidBracket(string s)
        {
            Dictionary<char, char> pairBracker = new Dictionary<char, char>() {
                { ')', '(' },
                { ']', '[' },
                { '}' , '{' },
            };

            Stack<char> bracketStack = new Stack<char>();

            var stringLength = s.Length;

            if (stringLength % 2 > 0)
            {
                return false;
            }


            for (int i = 0; i < stringLength; i++)
            {

                if (pairBracker.TryGetValue(s[i], out char c))
                {
                    // if start with close bracket or not match
                    if (bracketStack.Count == 0 || bracketStack.Peek() != c)
                    {
                        return false;
                    }
                    bracketStack.Pop();
                }
                else
                {
                    bracketStack.Push(s[i]);
                }

            }

            return bracketStack.Count == 0;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var startNode = new ListNode();
            var pointerNode = startNode;

            if (list1 == null)
            {
                return list2;
            }
            else if (list2 == null)
            {
                return list1;
            }

            if (list1.val >= list2.val)
            {
                startNode.val = list2.val;
                list2 = list2.next;
            }
            else
            {
                startNode.val = list1.val;
                list1 = list1.next;
            }

            while (list1 != null && list2 != null)
            {
                if (list1.val >= list2.val)
                {
                    pointerNode.next = list2;
                    list2 = list2.next;
                }
                else
                {
                    pointerNode.next = list1;
                    list1 = list1.next;
                }

                pointerNode = pointerNode.next;
            }

            if (list1 != null)
            {
                pointerNode.next = list1;
            }
            else
            {
                pointerNode.next = list2;
            }

            /*do {
				Console.WriteLine($"next : {startNode.val}");
				startNode = startNode.next;
			}while(startNode.val != 0);*/

            return startNode;


        }

        public int RemoveDuplicates(int[] nums)
        {
            var numsLength = nums.Length;
            Array.Sort(nums);

            var beforeNum = int.MinValue;
            var intPointer = 0;

            for (int i = 0; i < numsLength; i++)
            {
                if (beforeNum != nums[i])
                {
                    nums[intPointer++] = nums[i];
                    beforeNum = nums[i];
                }
            }

            return intPointer;

        }

        public int RemoveElement(int[] nums, int val)
        {
            var numsLength = nums.Length;
            Array.Sort(nums);

            var firstPresent = Array.FindIndex(nums, (x) => x == val);
            var lastPresent = Array.FindLastIndex(nums, (x) => x == val);

            var diff = lastPresent - firstPresent;

            Console.WriteLine($"first : {firstPresent} last : {lastPresent} diff : {diff}");

            if (lastPresent == numsLength - 1)
            {
                Array.Resize(ref nums, numsLength - diff + 1);
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    Console.WriteLine(nums[i]);
                }
                return numsLength - diff + 1;
            }

            for (int i = firstPresent; i < numsLength - 1 - diff; i++)
            {
                Console.WriteLine($"i = {i}");
                nums[i] = nums[i + diff + 1];
            }

            // Array.Resize(ref nums, numsLength - diff);

            return nums.Length - diff + 1;

            //var excludeNums = nums.Where(x => x != val).ToArray();
            //Array.Sort(excludeNums);

            //foreach (var item in excludeNums)
            //{
            //    Console.Write(item);
            //}
            //return excludeNums.Length;
        }
    }

}
