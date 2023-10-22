/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the 
        inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Initialize result list
                List<IList<int>> missingRanges = new List<IList<int>>();

                // Initialize prev to be 1 lower than lower bound 
                int prev = lower - 1;

                // Loop through nums array
                for (int i = 0; i <= nums.Length; i++)
                {

                    // Get current number, use upper + 1 if at end
                    int curr = (i < nums.Length) ? nums[i] : upper + 1;

                    // Check if difference between curr and prev is 2 or more
                    if (curr - prev >= 2)
                    {

                        // Add missing range to result
                        missingRanges.Add(new List<int> { prev + 1, curr - 1 });
                    }

                    // Update prev to current
                    prev = curr;
                }

                // Return result list
                return missingRanges;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /* *******************************************************************************************
                Self-reflection:

                    This question tested the ability to find missing ranges in a sorted array. 
                    The key learning was using a prev pointer to track the previous number, 
                    and comparing it with the current number to check for gaps of size >= 2.


       **************************************************************************************************** */

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Iterate through each character in the input string
                for (int i = 0; i < s.Length; i++)
                {
                    // iterates through the input string

                    if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                    {
                        // If an opening bracket is found, search for its corresponding closing bracket
                       

                        for (int j = i + 1; j < s.Length; j++)
                        {
                            // Iterate through the characters after the opening bracket

                            if (s[j] == ')' || s[j] == '}' || s[j] == ']')
                            {
                                // If a closing bracket is found, break the inner loop
                                break;
                            }
                        }
                    }
                }

                // If the function completes without finding any mismatched brackets, return true
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* ********************************************************************************
            Self-reflection

             Can use data structure like stack to achieve a better time complexity of O(n)
           ******************************************************************************************* */

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104
        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Variables to track buying and selling indices and maximum profit
                int left = 0; // Buy
                int right = 1; // Sell
                int maxProfit = 0;

                // Loop until the selling index reaches the end of the prices array
                while (right < prices.Length)
                {
                    // Calculate the current profit by subtracting buying price from selling price
                    int currentProfit = prices[right] - prices[left];

                    // If the buying price is less than the selling price, update the maximum profit
                    if (prices[left] < prices[right])
                    {
                        maxProfit = Math.Max(currentProfit, maxProfit);
                    }
                    else
                    {
                        // If the buying price is greater than or equal to the selling price,
                        // update the left index to the current right index (new buying position)
                        left = right;
                    }

                    // Move the right index to the next element in the prices array
                    right++;
                }

                // Return the maximum profit achieved
                return maxProfit;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* *************************************************************************************************************
            Self Reflection
            Learned the sliding window approach to track min price for optimizing buy/sell
            profit. Useful pattern for other optimization problems.


         * ******************************************************************************************************** */

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string num)
        {

            try
            {
                // Hash table to map rotated numbers
                Dictionary<char, char> map = new Dictionary<char, char>() { { '0', '0' }, { '1', '1' }, { '6', '9' }, { '8', '8' }, { '9', '6' } };

                int left = 0;
                int right = num.Length - 1;

                while (left <= right)
                {
                    // Check if mapping exists
                    if (!map.ContainsKey(num[left]) || map[num[left]] != num[right])
                    {
                        return false;
                    }
                    left++;
                    right--;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* *************************************************************************************************************
        Self Reflection  
        
        Learned an efficient approach to validate palindrome-like patterns using hash maps to store mappings. Can apply this for other palindrome problems.
       
         ************************************************************************************************************** */


        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {

            try
            {
                // Create a dictionary to store the count of each number encountered in the 'nums' array
                Dictionary<int, int> count = new Dictionary<int, int>();

                // Variable to store the final result, which represents the number of pairs with the same value
                int result = 0;

                // Iterate through each number in the 'nums' array
                foreach (int num in nums)
                {
                    // Check if the number already exists in the 'count' dictionary
                    if (count.ContainsKey(num))
                    {
                        // If the number exists, add the current count to the 'result'
                        // This represents the number of pairs with the same value encountered so far
                        result += count[num];

                        // Increment the count for the current number in the 'count' dictionary
                        count[num]++;
                    }
                    else
                    {
                        // If the number is encountered for the first time, initialize its count to 1 in the 'count' dictionary
                        count[num] = 1;
                    }
                }

                // Return the final result, which represents the total number of pairs with the same value in the 'nums' array
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /* ******************************************************************************************************************
            Self Reflection
            This problem tested the ability to use hash tables to optimize counting pairs.

            Learned that using hash tables is an efficient way to count pairs or 
            combinations in arrays by leveraging the frequency counts.

        ****************************************************************************************************************** */

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {

            try
            {

                // Initialize a SortedSet to store unique values in ascending order
                SortedSet<int> sortedSet = new SortedSet<int>();

                // Add elements to the SortedSet
                foreach (int num in nums)
                {
                    if (!sortedSet.Contains(num))
                    {
                        sortedSet.Add(num);
                        // If the size of the SortedSet exceeds 3, remove the minimum element
                        if (sortedSet.Count > 3)
                        {
                            sortedSet.Remove(sortedSet.First());
                        }
                    }
                }

                // If there are less than 3 distinct elements, return the maximum element
                if (sortedSet.Count < 3)
                {
                    return sortedSet.Max();
                }

                // The third maximum element is at the first position in the SortedSet (zero-based index)
                return sortedSet.First();
    
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* ******************************************************************************************************************
            Self Reflection
            
           My implementation (using SortedSet) has a higher time complexity (O(n log n)) due to the logarithmic time operations in the SortedSet, 
            whereas if we use HashSet we will have a lower time complexity (O(n)) because it performs constant time operations.
       
        ********************************************************************************************************************** */
        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {

            try
            {
                List<string> result = new List<string>();

                // Use StringBuilder for efficient string manipulation
                StringBuilder sb = new StringBuilder(currentState);

                for (int i = 1; i < sb.Length; i++)
                {
                    // Check for valid flip
                    if (sb[i] == '+' && sb[i - 1] == '+')
                    {
                        // Flip the characters in StringBuilder
                        sb[i - 1] = '-';
                        sb[i] = '-';

                        // Add the modified StringBuilder to the result
                        result.Add(sb.ToString());

                        // Revert the characters back to the original state for further iterations
                        sb[i - 1] = '+';
                        sb[i] = '+';
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* *********************************************************************************************************************
         Self Reflection

        Learned an efficient way to generate all combinations of a state by 
        iterating through input and modifying locally. Useful for backtracking 
        problems.

        ********************************************************************************************************************** */
        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {

            // HashSet to store vowels
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            StringBuilder result = new StringBuilder();

            foreach (char c in s)
            {
                // Add character if not a vowel
                if (!vowels.Contains(char.ToLower(c)))
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /* ******************************************************************************************************************
        Self Reflection
        Learned that HashSets allow fast lookup and are useful for filtering strings or arrays based on membership.
        ***************************************************************************************************************** */

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
