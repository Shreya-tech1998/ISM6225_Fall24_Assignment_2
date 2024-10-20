using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = {1,2,3,4};
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
               List<int> result = new List<int>();
                
               // Get the length of the array 
               int length = nums.Length;
                // Initilize a counter
                int counter = 1;
               // run a for loop
               for(int i = 0;i<length;i++)
                {
                    bool ispresent = Array.Exists(nums, element => element == counter);                    
                    if (ispresent!=true)
                    {
                        result.Add(counter);
                    }
                    counter++;
                }                

                return result;
            }
            catch (Exception)
            {                
                
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                if (nums == null)
                {
                    throw new ArgumentNullException("nums", "Input array cannot be null.");
                }
                

                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }

                    if (nums[left] % 2 == 0) left++;
                    if (nums[right] % 2 == 1) right--;
                }

                return nums;
            }
              
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new int[0]; // Return an empty array in case of an error

            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                
                Dictionary<int, int> result = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int residual = target - nums[i];
                    if (result.ContainsKey(residual))
                    {
                        return new int[] { result[residual], i };

                    }
                    if(!result.ContainsKey(nums[i]))
                    {
                        result[nums[i]] = i;
                    }

                }
                // If no solution is found, throw an exception
                throw new ArgumentException("No two sum solution exists for the given input.");
                //return new int[0]; // Placeholder
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return new int[0]; // Return an empty array in case of an error

            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                
                // The integer array should at least have 3 numbers else raise an exception
                // Sort the array 
                // take the largest three numbers in the array multiply and return the result
                if(nums==null||nums.Length<3)
                {
                    throw new ArgumentException("Array must at least contain three numbers");
                }
                Array.Sort(nums);                
                int n = nums.Length;

                // Option 1: The product of the three largest numbers, case when all the nums are only positive or negative
                int option1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // Option 2: The product of the two smallest numbers (negative) and the largest number, case when we have a mix of positive and negative numbers
                int option2 = nums[0] * nums[1] * nums[n - 1];

                // Return the maximum of the two options
                return Math.Max(option1, option2);


                
            }
            catch (Exception ex)
            {
                
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return 0;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here              

                // Check if the number is negative
                bool isNegative = decimalNumber < 0;
                if (isNegative)
                {
                    decimalNumber = Math.Abs(decimalNumber);
                }

                // Edge case for 0
                if (decimalNumber == 0)
                {
                    return "0";
                }

                // Initialize a StringBuilder to hold the binary result
                StringBuilder binary = new StringBuilder();

                // Loop to convert the decimal number to binary
                while (decimalNumber > 0)
                {
                    int remainder = decimalNumber % 2;
                    binary.Insert(0, remainder);
                    decimalNumber /= 2;
                }
                // Handle negative numbers using two’s complement
                if (isNegative)
                    {
                    // Flip the bits
                    for (int i = 0; i < binary.Length; i++)
                        {
                         binary[i] = binary[i] == '0' ? '1' : '0';
                        }
                    // Add 1 to the flipped bits
                    bool carry = true;
                    for (int i = binary.Length - 1; i >= 0; i--)
                        {
                                if (binary[i] == '1' && carry)
                                {
                                    binary[i] = '0';
                                }
                                else if (binary[i] == '0' && carry)
                                {
                                    binary[i] = '1';
                                    carry = false;
                                }
                         }

                     // Handle overflow carry bit
                     if (carry)
                        {
                                binary.Insert(0, '1');
                        }
                     }

                        return binary.ToString();                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty; // Return an empty string in case of an error

            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here

                // Check if the array is empty
                if (nums == null || nums.Length == 0)
                {
                    throw new ArgumentException("Array must not be null or empty.");
                }

                // utilizing binary search to get the minimum element.
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                return nums[left];

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return int.MinValue; // Return a distinctive value in case of an error

            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here

                // Negative numbers are not palindromes
                if (x < 0)
                {
                    return false;
                }

                // Store the original number
                int original = x;
                int reversed = 0;

                // Reverse the number
                while (x > 0)
                {
                    int remainder = x % 10;
                    reversed = reversed * 10 + remainder;
                    x /= 10;
                }

                // Check if the original number is equal to the reversed number
                return original == reversed;                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Return false in case of an error

            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here

                // Base cases: Fibonacci(0) = 0, Fibonacci(1) = 1
                if (n < 0)
                {
                    throw new ArgumentException("Input must be a non-negative integer.");
                }
                if (n == 0)
                {
                    return 0;
                }
                if (n == 1)
                {
                    return 1;
                }

                // Initialize the first two Fibonacci numbers
                int a = 0;
                int b = 1;

                // Loop to calculate the nth Fibonacci number
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }

                return b;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 0; // Return 0 in case of an error
            
            }
        }
    }
}
