using System.Collections.Immutable;
using System.Reflection;
using System.Text;

namespace ConsoleApp1;
public class LeetcodeKnowledge
{
    #region HashTable
    public bool CanConstruct(string ransomNote, string magazine)
    {

        Dictionary<char, int> Letters = new();

        foreach (char letter in magazine)
        {
            if (!Letters.ContainsKey(letter))
            {
                Letters.Add(letter, 1);
            }
            else
            {
                Letters[letter]++;
            }
        }

        StringBuilder result = new(ransomNote);

        foreach (char letter in ransomNote)
        {
            if (Letters.ContainsKey(letter) && Letters[letter] > 0)
            {
                result.Remove(0, 1);
                Letters[letter]--;
            }
            else
            {
                return false;
            }
        }
        return result.Length == 0;
    }

    #endregion
    public int CoinChange(int[] coins, int amount)
    {
        int initialValue = 0;

        int result = 0;

        Queue<(int, int)> queue = new();

        HashSet<int> visited = new();

        visited.Add(initialValue);
        queue.Enqueue((initialValue, 0));

        while (queue.Count > 0)
        {

            var currentVertex = queue.Dequeue();

            int currentVertexValue = currentVertex.Item1;

            foreach (int coin in coins)
            {
                if (!visited.Contains(currentVertexValue + coin))
                {
                    visited.Add(currentVertexValue + coin);

                    if (currentVertexValue + coin == amount)
                    {
                        return currentVertex.Item2 + 1;
                    }

                    queue.Enqueue((currentVertexValue + coin, currentVertex.Item2 + 1));
                }
            }
        }
        return -1;
    }

    //public int CoinChange(int[] coins, int amount)
    //{
    //    if (amount == 0)
    //    {
    //        return 0;
    //    }

    //    // Initialize the queue for BFS
    //    Queue<int> queue = new Queue<int>();
    //    queue.Enqueue(0); // Start with 0 amount

    //    // Track visited sums to avoid revisiting the same value
    //    HashSet<int> visited = new HashSet<int>();
    //    visited.Add(0);

    //    // Initialize the number of coins used
    //    int coinCount = 0;

    //    // Perform BFS
    //    while (queue.Count > 0)
    //    {
    //        int size = queue.Count;
    //        coinCount++;

    //        // Process all nodes at the current level (i.e., all possible sums with coinCount coins)
    //        for (int i = 0; i < size; i++)
    //        {
    //            int currentAmount = queue.Dequeue();

    //            // Try all coins
    //            foreach (int coin in coins)
    //            {
    //                int newAmount = currentAmount + coin;

    //                // If we reached the target amount, return the result
    //                if (newAmount == amount)
    //                {
    //                    return coinCount;
    //                }

    //                // If the new amount is less than the target and hasn't been visited, enqueue it
    //                if (newAmount < amount && !visited.Contains(newAmount))
    //                {
    //                    visited.Add(newAmount);
    //                    queue.Enqueue(newAmount);
    //                }
    //            }
    //        }
    //    }

    //    // If BFS completes without finding a solution, return -1
    //    return -1;
    //}
    public int CalPoints(string[] operations)
    {
        Stack<int> values = new();
        int.TryParse(operations[0], out int result);
        values.Push(result);

        for (int i = 1; i < operations.Length; i++)
        {
            if (int.TryParse(operations[i], out int number))
            {
                values.Push(number);
            }

            else if (operations[i] == char.ToString('+'))
            {
                int addUp = values.ElementAt(1) + values.First();
                values.Push(addUp);
            }

            else if (operations[i] == char.ToString('D'))
            {
                int multiply = values.First() * 2;
                values.Push(multiply);
            }
            else
            {
                values.Pop();
            }
        }
        return values.Sum();
    }

    public IList<string> FizzBuzz(int n)
    {
        string[] resultArray = new string[n];
        int start = 1;

        while (start <= n)
        {
            if (start % 3 == 0 && start % 5 == 0)
            {
                resultArray[start - 1] = "FizzBuzz";
            }
            else if (start % 3 == 0 && start % 5 != 0)
            {
                resultArray[start - 1] = "Fizz";
            }
            else if (start % 5 == 0 && start % 3 != 0)
            {
                resultArray[start - 1] = "Buzz";
            }
            else
            {
                resultArray[start - 1] = start.ToString();
            }
            start++;
        }
        return resultArray;
    }

    #region TwoPointers

    public bool IsSubsequence(string s, string t)
    {

        int pointer1 = 0;
        int pointer2 = 0;

        var longString = t.ToCharArray();
        var shortString = s.ToCharArray();

        while (pointer2 < t.Length)
        {
            if (shortString[pointer1] == longString[pointer2])
            {
                pointer1++;
                pointer2++;
            }
            else
            {
                pointer2++;
            }
            if (pointer1 > s.Length)
            {
                return true;
            }
        }
        return false;
    }

    public int RemoveDuplicates(int[] nums)
    {
        int counter = 1;
        int Unique = 0;
        int Current = 1;

        while (Current < nums.Length)
        {
            if (nums[Unique] < nums[Current])
            {
                Unique++;
                nums[Unique] = nums[Current];
                counter++;
            }
            else
            {
                Current++;
            }
        }
        return counter;
    }

    //public int[] TwoSum(int[] numbers, int target)
    //{

    //    int left = 0;
    //    int right = numbers.Length - 1;


    //    while (left < right)
    //    {
    //        int actual = (numbers[left] + numbers[right]);

    //        if (actual == target)
    //        {
    //            return new int[] { left + 1, right + 1 };
    //        }
    //        if (target < actual)
    //        {
    //            right--;
    //        }
    //        else if (target > actual)
    //        {
    //            left++;
    //        }
    //        else
    //        {
    //            return new int[] { left + 1, right + 1 };
    //        }
    //    }
    //    return numbers;
    //}

    // toto este skusit cez greedy
    public int MaxArea(int[] height)
    {

        int left = 0;
        int right = height.Length - 1;
        int currentArea = 0;
        int actualArea = 0;

        int[] tops = new int[2] { height[left], height[right] };

        int stranaAvyska = 0;
        int stranaBdlzka = 0;

        while (left < right)
        {
            int resultHeight = Math.Min(height[left], height[right]);
            int resultHeight1 = tops.Min();

            stranaAvyska = resultHeight;

            int resultLength = Math.Abs(right - left);
            stranaBdlzka = resultLength;

            currentArea = resultHeight * resultLength;

            if (currentArea > actualArea)
            {
                actualArea = currentArea;
            }

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return actualArea;
    }
    #endregion

    public string ReverseWords(string s)
    {
        var a = s.Split(' ');
        var b = a.Where(x => x != "").Reverse().ToArray();

        return string.Join(" ", b);
    }

    public void SS()
    {
        int number = 12345;
        int sum = 0;
        List<int> digits = new List<int>();

        while (number > 0)
        {
            digits.Add(number % 10);  // Extract last digit
            number /= 10;  // Remove last digit
        }

        digits.Reverse();  // Digits were added in reverse order
        Console.WriteLine(string.Join(", ", digits));

        foreach (int num in digits)
        {
            //sum += Math.Pow
        }
    }

    public bool IsHappy(int n)
    {
        try
        {
            int current = n;
            int sum = 0;

            while (sum != 1)
            {
                var digits = ParseNumber(current);

                foreach (var num in digits)
                {
                    sum += (int)Math.Pow(num, 2);
                }

                current = sum;

                if (sum == 1)
                {
                    return true;
                }

                sum = 0;
            }
            return false;
        }
        catch (Exception ex)
        {

            return false;
        }

    }

    public List<int> ParseNumber(int n)
    {
        List<int> digits = new List<int>();

        while (n > 0)
        {
            digits.Add(n % 10);
            n /= 10;
        }

        digits.Reverse();

        return digits.Select(x => x).ToList();
    }

    public int LengthOfLastWord(string s)
    {
        int counter = 0;

        var newS = s.TrimEnd();

        for (int i = newS.Length - 1; i >= 0; i--)
        {
            if (newS[i] != ' ')
            {
                counter++;
            }
            else
            {
                return counter;
            }
        }
        return counter;
    }

    public int StrStr(string haystack, string needle)
    {
        //"mississippi"
        //"issip"

        int additionalPointer = 0;
        int needlePointer = 0;
        int haystackPointer = 0;

        while (haystackPointer < haystack.Length)
        {
            if (haystack[haystackPointer] == needle[0] && needlePointer > 0)
            {
                additionalPointer = haystackPointer;
            }
            if (haystack[haystackPointer] == needle[needlePointer])
            {
                //if()
                //{
                //    additionalPointer = haystackPointer;
                //}
                needlePointer++;
                haystackPointer++;
            }
            else
            {
                needlePointer = 0;
                haystackPointer++;
            }
            if (needlePointer == needle.Length)
            {
                return haystackPointer - needlePointer;
            }
        }
        return -1;
    }
    //public virtual int solution(int[] A)
    //{
    //    // Implement your solution here
    //    int smallest = 0;
    //    int currMiss = A.Min() + 1;
    //    var ss = A.ToHashSet();
    //    List<int> list = A.ToList();
    //    list.Sort();

    //    for (int i = 0; i < A.Length; i++)
    //    {

    //        if (A[i] > 0)
    //        {
    //            smallest = A[i];
    //            if (currMiss > smallest + 1)
    //            {
    //                currMiss = smallest + 1;
    //            }
    //        }
    //    }

    //    if (currMiss > 0)
    //    {
    //        return currMiss;
    //    }

    //    return 1;
    //}
    public int Solution(int[] A)
    {
        // Implement your solution here
        int currentSmallest = 0;
        int possibleMissing = 0;
        int left = 0;

        if (A.Length == 0 || A.All(x => x < 0))
        {
            return 1;
        }

        List<int> list = A.ToList();
        list.Sort();


        while (list.Count > 0)
        {

            if (list[left] < 0)
            {
                list.Remove(list[left]);
                left++;
            }
            else
            {
                currentSmallest = list[left];
                possibleMissing = currentSmallest + 1;
            }
            if (!list.Contains(possibleMissing))
            {
                return possibleMissing;
            }
            else
            {
                list.Remove(currentSmallest);
                left++;
            }
        }
        return 1;
    }

    #region 24.2.2025
    public bool RotateString(string s, string goal)
    {
        StringBuilder sb = new(s);
        sb.Remove(0, 1);
        HashSet<char> hs = new(s);

        for (int i = 0; i < s.Length; i++)
        {
            if (s != goal)
            {
                char first = s[0];

                sb.Append(first);

                var ns = s.Remove(0, 1);

                ns += first;
            }
        }
        return false;
    }
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> dict = new();

        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.ContainsKey(s[i]))
            {
                dict.Add(s[i], 1);
            }
            else
            {
                dict[s[i]]++;
            }
        }
        for (int i = 0; i < t.Length; i++)
        {
            if (!dict.ContainsKey(t[i]))
            {
                return false;
            }
            else
            {
                dict[t[i]]--;
            }
        }
        if (dict.Values.All(x => x == 0))
        {
            return true;
        }
        return false;
    }

    public int Search(int[] nums, int target)
    {

        int l = 0;
        int r = nums.Length - 1;


        while (l <= r)
        {
            int mid = l + (l + r) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                r = mid + 1;
            }
            else
            {
                l = mid - 1;
            }
        }
        return -1;

    }

    #endregion

    #region 25.2.2025
    public bool AreOccurrencesEqual(string s)
    {
        Dictionary<char, int> dict = new();

        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.ContainsKey(s[i]))
            {
                dict.Add(s[i], 1);
            }
            else
            {
                dict[s[i]]++;
            }
        }

        return dict.All(x => x.Value == dict.Values.First());
    }

    public string CapitalizeTitle(string title)
    {
        List<string> list = new();
        var ss = title.Split();

        foreach (string word in ss)
        {
            string ns = word.ToLower();

            if (ns.Length > 2)
            {
                var bns = ns[0].ToString().ToUpper() + ns.Substring(1);
                list.Add(bns);
            }
            else
            {
                list.Add(ns);
            }

        }

        return string.Join(" ", list);
    }



    #endregion

    #region 27.2.2025

    //Binary Search solution
    //[-2, -1, 1, 2, 3, 4, 5, 6]
    // doriesit pre pripad vyskytu nul v poli
    public int MaximumCount(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        int positiveCounter = 0;
        int negativeCounter = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == 0)
            {
                negativeCounter += ((mid - 1) - left) + 1;
                positiveCounter += (right - (mid + 1)) + 1;
            }

            if (nums[mid] < 0)
            {
                negativeCounter += (mid - left) + 1;

                left = mid + 1;
            }
            else if (nums[mid] > 0)
            {
                positiveCounter += (right - mid) + 1;
                right = mid - 1;
            }
        }

        return Math.Max(negativeCounter, positiveCounter);
    }
    //[1,1,1]
    //    [1]
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head != null)
        {
            if (head.next == null)
            {
                return head;
            }

            ListNode curr = head;

            while (curr != null && curr.next != null)
            {
                if (curr.val == curr.next.val)
                {
                    curr = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }
            return head;
        }
        return null;
    }

    //public ListNode DeleteDuplicates(ListNode head)
    //{
    //    if (head == null)
    //    {
    //        return null;
    //    }

    //    ListNode curr = head;

    //    while (curr != null && curr.next != null)
    //    {
    //        if (curr.val == curr.next.val)
    //        {
    //            curr.next = curr.next.next;
    //        }
    //        else
    //        {
    //            curr = curr.next;
    //        }
    //    }

    //    return head;
    //}

    //public ListNode RemoveElements(ListNode head, int val)
    //{
    //    if (head == null)
    //    {
    //        return null;
    //    }

    //    if (head.val == val)
    //    {
    //        head = head.next;
    //        return head;
    //    }

    //    var curr = head;

    //    while (curr != null)
    //    {
    //        if (curr.next.val == val)
    //        {
    //            curr.next = curr.next.next;
    //        }
    //        else
    //        {
    //            curr = curr.next;
    //        }
    //    }
    //    return head;
    //}


    #endregion

    #region 3.3.2025

    public bool IsValidd(string s)
    {
        Stack<char> chars = new();
        HashSet<char> closingBrackets = new HashSet<char> { ')', ']', '}' };

        if (s.Length < 2)
        {
            return false;
        }
        if (s.StartsWith(')') || s.StartsWith(']') || s.StartsWith('}'))
        {
            return false;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{')
            {
                chars.Push(s[i]);
            }
            else if (s[i] == ')' || s[i] == ']' || s[i] == '}')
            {
                if (chars.Count == 0)
                {
                    return false;
                }
                if (s[i] == ')')
                {
                    if (chars.Peek() == '(')
                    {
                        chars.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                if (s[i] == ']')
                {
                    if (chars.Peek() == '[')
                    {
                        chars.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                if (s[i] == '}')
                {
                    if (chars.Peek() == '{')
                    {
                        chars.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return chars.Count == 0;
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> nodes = new();
        Stack<TreeNode> treeNodes = new();

        GoDeeper(root);

        var currentNode = root;

        if (currentNode == null)
        {
            return nodes;
        }

        if (currentNode.left != null)
        {
            currentNode = currentNode.left;
        }

        return nodes;
    }

    public void GoDeeper(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        GoDeeper(node.left);



        GoDeeper(node.right);
    }

    public IList<int> InorderTraversall(TreeNode root)
    {
        List<int> nodes = new();
        Stack<TreeNode> treeNodes = new();

        var currentNode = root;

        if (currentNode == null)
        {
            return nodes;
        }

        while (currentNode != null || treeNodes.Count > 0)
        {
            while (currentNode != null)
            {
                treeNodes.Push(currentNode);
                currentNode = currentNode.left;
            }

            currentNode = treeNodes.Pop();
            nodes.Add(currentNode.val);
            currentNode = currentNode.right;
        }
        return nodes;
    }

    //public int GetLucky(string s, int k)
    //{
    //    StringBuilder sb = new();
    //    int final = 0;

    //    foreach (char ch in s)
    //    {
    //        sb.Append(ch - 'a' + 1);
    //    }

    //    if (!long.TryParse(sb.ToString(), out long result))
    //    {
    //        return 0;
    //    }

    //    int[] digits = result.ToString().Select(d => d - '0').ToArray();

    //    for(int i = 0; i < k; i++)
    //    {
    //        for(int j = 0; j < digits.Length; j++)
    //        {
    //            final += digits[j];

    //        }
    //        digits = int.Parse(final.ToString());
    //    }

    //    return final;

    //}
    //public string ClearDigits(string s)
    //{
    //    Stack<char> stck = new();

    //    for(int i = 1; i < s.Length; i++)
    //    {
    //        if (int.TryParse(s[i].ToString(), out int result))
    //        {
    //            stck.Push(s[i-1])
    //        }
    //    }
    //}
    public int MostWordsFound(string[] sentences)
    {
        int words = 0;

        foreach (var sentence in sentences)
        {
            int temp = sentence.Split().Count();

            if (temp > words)
            {
                words = temp;
            }
        }
        return words;
    }

    //"alice and  bob are playing stone-game10"
    //public int CountValidWords(string sentence)
    //{
    //    HashSet<char> puncts = new HashSet<char> { '.', '!', ',' };

    //    int validWordCount = 0;

    //    var words = sentence.Split();

    //    foreach(string str in words)
    //    {
    //        if (!string.IsNullOrEmpty(str))
    //        {
    //            if (str[0] != '-' && str[str.Length - 1] != '-')
    //            {
    //                StringBuilder stringBuilder = new(str);

    //                for (int i = 0; i < stringBuilder.Length; i++)
    //                {
    //                    if (!int.TryParse(stringBuilder[i].ToString(), out int result))
    //                    {
    //                        if (stringBuilder[i] != '.' &&)
    //                        {
    //                            if (str.IndexOf(str[i]) == str.Length - 1)
    //                            {
    //                                validWordCount++;
    //                            }
    //                        }
    //                        else
    //                        {
    //                            validWordCount++;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    return validWordCount;
    //}

    //["a", "ab"], ["a", "a", "a", "ab"]
    //["leetcode","is","leetcode","is","amazing","and","fantastic"]["leetcode","is","leetcode","is","fantastic"]



#endregion

    #region 6.3.2025

    public int CountWords(string[] words1, string[] words2)
    {
        Dictionary<string, int> dict1 = new();

        foreach (var str in words1)
        {
            if (!dict1.ContainsKey(str))
            {
                dict1.Add(str, 1);
            }
            else
            {
                dict1[str]++;
            }
        }

        foreach (var str in words2)
        {
            if (dict1.ContainsKey(str) && dict1[str] <= 1)
            {
                dict1[str]--;
            }
        }

        return dict1.Count(x => x.Value == 0);
    }

    public bool AreNumbersAscending(string s)
    {
        string[] words = s.Split();

        int currNum = 0;

        foreach (var str in words)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (int.TryParse(str, out int result))
                {
                    if (currNum <= result)
                    {
                        currNum = result;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    //public int Fib(int n)
    //{
    //    int result = 0;
    //    if (n == 0)
    //    {
    //        r
    //    }
    //    if (n <= 2)
    //    {
    //        result = 1;
    //    }
    //    else
    //    {
    //        result = Fib(n - 1) + Fib(n - 2);
    //    }
    //    return result;
    //}
    ////"B0B6G0R6R0R6G9"
    //public int CountPoints(string rings)
    //{

    //}

    #endregion

    #region 8.3.2025

    //Input: s = "abcdefghij", k = 3, fill = "x"
    //Output: ["abc", "def", "ghi", "jxx"]
    public string[] DivideString(string s, int k, char fill)
    {
        List<string> strings = new();
        StringBuilder sb = new(s);

        while(sb.Length > 0)
        {
            StringBuilder dividedString = new();
            if(sb.Length < k)
            {
                dividedString.Append(sb);
                for(int i = 0; i < k - sb.Length; i++)
                {
                    dividedString.Append(fill);
                }
                strings.Add(dividedString.ToString());
                sb.Clear();
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    dividedString.Append(sb[i]);
                }
                sb.Remove(0, k);

                strings.Add(dividedString.ToString());
            }
        }

        return strings.ToArray();
    }

    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        var dict1 = word1.GroupBy(ch => ch).ToDictionary(pf => pf.Key, pf => pf.Count());
        var dict2 = word2.GroupBy(ch => ch).ToDictionary(pf => pf.Key, pf => pf.Count());

        foreach (var kvp in dict1)
        {
            if (!dict2.ContainsKey(kvp.Key))
            {
                if (kvp.Value > 3)
                {
                    return false;
                }
            }
            else
            {
                var ss = Math.Abs(dict2[kvp.Key] - kvp.Value);
                if (ss > 3)
                {
                    return false;
                }
            }
        }
        foreach (var kvp in dict2)
        {
            if (!dict1.ContainsKey(kvp.Key))
            {
                if (kvp.Value > 3)
                {
                    return false;
                }
            }
        }

        return true;
    }
    public bool CheckAlmostEquivalentt(string word1, string word2)
    {
        var dict1 = word1.GroupBy(ch => ch).ToDictionary(pf => pf.Key, pf => pf.Count());

        Dictionary<char, int> dict3 = new();

        for (int i = 0; i < word1.Length; i++)
        {
            if (!dict3.TryAdd(word1[i], 1))
            {
                dict3[word1[i]]++;
            }
        }

        foreach (var ch in word2)
        {
            if (dict1.ContainsKey(ch))
            {
                dict1[ch]--;
            }
            else
            {
                dict1[ch] = -1;
            }
        }

        return dict1.Any(ss => Math.Abs(ss.Value) > 3);
    }

    public int CountSeniors(string[] details)
    {
        int count = 0;

        foreach(var str in details)
        {
            var newstr = str.Substring(11, 2);

            int.TryParse(newstr, out int result);

            if(result > 60)
            {
                count++;
            }
        }

        return count;
    }

    public bool ThreeConsecutiveOdds(int[] arr)
    {
        int count = 0;

        List<int> ints = new(arr);

        while(ints.Count() >= 3)
        {
            for(int i = 0; i < 3; i++)
            {
                if (ints[i] % 2 == 0)
                {
                    ints.RemoveRange(0, i + 1);
                    count = 0;
                    break;
                }
                else
                {
                    count++;
                }
                if(count == 3)
                {
                    return true;
                }
            }
        }
        return false;

    }

    public char FindTheDifference(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
        {
            return t[0];
        }

        //var dict1 = t.GroupBy(ch => ch).ToDictionary(pf => pf.Key, pf => pf.Count());

        Dictionary<char, int> dict2 = new();

        for(int i = 0; i < t.Length; i++)
        {
            if (!dict2.TryAdd(t[i], 1))
            {
                dict2[t[i]]++;
            }
        }

        foreach(var ch in s)
        {
            if (dict2.ContainsKey(ch))
            {
                dict2[ch]--;
            }
        }
        return dict2.FirstOrDefault(x => x.Value == 1).Key;
    }
    #endregion

    #region 9.3.2025

    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }

        //string cleaned = Regex.Replace(s, "[^a-zA-Z0-9]", "").ToLower();
        string cleaned = new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLower();

        int l = 0;
        int r = cleaned.Length - 1;

        while(l <= r)
        {
            if (cleaned[l] == cleaned[r])
            {
                l++;
                r--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    public bool IsIsomorphic(string s, string t)
    {
        var dict1 = s.GroupBy(ch => ch).ToDictionary(pf => pf.Key, pf => pf.Count());
        var dict2 = t.GroupBy(ch => ch).ToDictionary(pf => pf.Key, pf => pf.Count());

        foreach(var kvp in dict1)
        {
            if (dict2.ContainsValue(kvp.Value))
            {
                dict1[kvp.Key] = 0;
            }
        }

        return dict1.All(x => x.Value == 0);
    }

    public int PrefixCount(string[] words, string pref)
    {
        int counter = 0;

        foreach(var word in words)
        {
            if(word.Length < pref.Length)
            {
                continue;
            }
            var nw = word.Substring(0, pref.Length);

            if(nw == pref)
            {
                counter++;
            }
        }

        return counter;
    }

    public void ReverseString(char[] s)
    {
        int l = 0;
        int r = s.Length - 1;
        
        while(l > r)
        {
            char temp = s[r];
            s[r] = s[l];
            s[l] = temp;
        }
    }

    public int SecondHighest(string s)
    {
        List<int> ints = new();

        foreach(char ch in s)
        {
            if (char.IsDigit(ch))
            {
                if(ints.Count() == 0)
                {
                    ints.Add(ch - '0');
                }
                else
                {
                    if (ch - '0' > ints.FirstOrDefault())
                    {
                        ints.Add(ch - '0');
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        if(ints.Count() == 0)
        {
            return -1;
        }
        else if (ints.All(x => x == ints[0]))
        {
            return -1;
        }
        else
        {
            ints.Sort();
        }
        return ints[1];
    }

    #endregion

    #region 11.3.2025

    public bool CheckString(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }

        var li = s.LastIndexOf('a');

        for (int i = 0; i < li; i++)
        {
            if (s[i] == 'b')
            {
                return false;
            }
        }

        return true;
    }

    //public string MakeFancyString(string s)
    //{

    //}

    #endregion

    #region 12.3.2025

    public string[] FindWords(string[] words)
    {
        List<string> strings = new();

        HashSet<char> row1 = new("qwertyuiop");
        HashSet<char> row2 = new("asdfghjkl");
        HashSet<char> row3 = new("zxcvbnm");

        foreach(var word in words)
        {
            var lowerw = word.ToLower();

            bool allContainedRow1 = lowerw.All(row1.Contains);
            bool allContainedRow2 = lowerw.All(row2.Contains);
            bool allContainedRow3 = lowerw.All(row3.Contains);

            if (allContainedRow1 || allContainedRow2 || allContainedRow3)
            {
                strings.Add(word);
            }
        }

        return strings.ToArray();
    }

    public int[] TwoSum(int[] nums, int target)
    {
        List<int> indices = new();

        HashSet<int> ints = new(nums);

        for(int i = 0; i< nums.Length; i++)
        {
            if(ints.Contains(target - nums[i]))
            {
                indices.Add(i);
            }
        }
        return indices.ToArray();
    }

    #endregion

    #region 16.3.2025

    public bool DetectCapitalUse(string word)
    {
        return char.IsUpper(word.FirstOrDefault()) && word.Substring(1).All(ch => char.IsLower(ch)) || word.All(ch => char.IsUpper(ch)) || word.All(c => char.IsLower(c));
    }

    //public bool ValidPalindrome(string s)
    //{
    //    var dict = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

    //    for(int i = 0; i < s.Length; i++)
    //    {
    //        if (dict[s[i]] % 2 != 0)
    //    }

    //    int odd = dict.Count(x => x.Value % 2 != 0);



    //    return odd <= 2 && s.IndexOf()
    //}

    public string ToLowerCase(string s)
    {
        return s.ToUpper();
    }

    #endregion

    #region 17.3.2025

    public bool DivideArray(int[] nums)
    {
        //solution 1 = more readable but slower
        var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        //sol2  = faster, less readable
        var dict1 = new Dictionary<int, int>();

        foreach(var num in nums)
        {
            if(!dict1.TryAdd(num, 1))
            {
                dict1[num]++;
            }
        }

        return (dict1.All(x => x.Value % 2 == 0));

    }

    public int MostFrequentEven(int[] nums)
    {
        List<int> ints = new();

        var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        foreach(var kvp in dict)
        {
            if(kvp.Value % 2 == 0)
            {
                ints.Add(kvp.Key);
            }
        }

        if(ints.Count > 0)
        {
            return ints.Max();
        }

        return -1;
    }


    #endregion

    #region 19.3.2025

    //["eat","tea","tan","ate","nat","bat"]
    //public IList<IList<string>> GroupAnagrams(string[] strs)
    //{
    //    IList<IList<string>> groupedAnangrams = new List<IList<string>>();

    //    if (strs.Length == 0)
    //    {
    //        return groupedAnangrams;
    //    }

    //    HashSet<char> chars = new(strs[0]);

    //    foreach(var word in strs)
    //    {
    //        if (word.All(chars.Contains))
    //        {
    //            groupedAnangrams.Add()
    //        }
    //    }

    //    return groupedAnangrams;
    //}
    #endregion

    #region 20.3.2025

    //Input: words = ["bella","label","roller"]
    //Output: ["e", "l", "l"]
    public IList<string> CommonChars(string[] words)
    {
        Dictionary<char, int> dict0 = new();

        foreach(char ch in words[0])
        {
            if(!dict0.TryAdd(ch, 1))
            {
                dict0[ch]++;
            }
        }
        for(int i = 1; i < words.Length; i++)
        {
            Dictionary<char, int> tempDict = new();

            for(int j = 0; j < words[i].Length; j++)
            {
                if (!tempDict.TryAdd(words[i][j], 1))
                {
                    tempDict[words[i][j]]++;
                }
            }
        }
        return new List<string>();
    }

    #endregion

    #region 22.3.2025

    //Input: s = "loveleetcode", c = "e"
    //Output: [3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0]
    public int[] ShortestToChar(string s, char c)
    {
        List<int> resultIndices = new();

        int indexOfLastOccurenceOfc = s.IndexOf(c);

        for(int i = 0; i < s.Length; i++)
        {
            if (s[i] == c)
            {
                resultIndices.Add(0);
                indexOfLastOccurenceOfc = i;
            }
            else
            {

                if (Math.Abs(i - indexOfLastOccurenceOfc) > Math.Abs(i - s.IndexOf(c, i)))
                {
                    indexOfLastOccurenceOfc = Math.Abs(s.IndexOf(c, i));
                }
                resultIndices.Add(Math.Abs(i - indexOfLastOccurenceOfc));
            }
        }
        return resultIndices.ToArray();
    }


    // 485. Max Consecutive Ones
    // Input: nums = [1,1,0,1,1,1]
    // Output: 3

    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int actualCount = 0;
        int resultCount = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                actualCount++;
            }
            else
            {
                actualCount = 0;
            }
            if (resultCount < actualCount)
            {
                resultCount = actualCount;
            }
        }

        return resultCount;
    }

    // 1394. Find Lucky Integer in an Array
    // Input: arr = [2,2,3,4]
    // Output: 2

    //Beats 9%
    public int FindLucky(int[] arr)
    {
        int lucky = -1;

        var dict = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        foreach (var kvp in dict)
        {
            if (kvp.Key == kvp.Value)
            {
                var potentionalLucky = kvp.Key;

                if (lucky < potentionalLucky)
                {
                    lucky = kvp.Key;
                }
            }
        }

        return lucky;
    }

    // Input: arr = [2,2,3,4,4,4,4]

    // Beats 83%
    public int FindLucky2(int[] arr)
    {
        int lucky = -1;

        var dict = new Dictionary<int, int>();

        foreach(var num in arr)
        {
            if(!dict.TryAdd(num, 1))
            {
                dict[num]++;
            }
        }

        foreach (var kvp in dict)
        {
            if (kvp.Key == kvp.Value)
            {
                var potentionalLucky = kvp.Key;

                if (lucky < potentionalLucky)
                {
                    lucky = kvp.Key;
                }
            }
        }

        return lucky;
    }

    // LinkedIN Learning excercise
    // Input: [1, 2, 3, 4, 5, 6]
    // Output: [2, 3, 4, 5, 6, 1]

    public int[] RotateArray(int[] numbers)
    {
        int first = numbers[0];

        for(int i = 0; i < numbers.Length - 1; i++)
        {
            numbers[i] = numbers[i + 1];
        }

        numbers[numbers.Length - 1] = first;

        return numbers;
    }

    #endregion

    #region 23.3.2025

    // 1470. Shuffle the Array
    // Input: nums = [2,5,1,3,4,7], n = 3
    // Output: [2, 3, 5, 4, 1, 7]

    //public int[] Shuffle(int[] nums, int n)
    //{
    //    for(int i = 0; i < nums.Length; i++)
    //    {

    //    }
    //}

    // 2706. Buy Two Chocolates
    // Input: prices = [1, 2, 2], money = 3
    // Output: 0
    public int BuyChoco(int[] prices, int money)
    {
        int actualMoneyCount = money;

        Array.Sort(prices);

        for(int i = 0; i < 2; i++)
        {
            actualMoneyCount -= prices[i];
        }

        if(actualMoneyCount >= 0)
        {
            return actualMoneyCount;
        }
        else
        {
            return money;
        }
    }

    // 495. Teemo Attacking
    // Input: timeSeries = [1, 4], duration = 2
    // Output: 4
    //  [t, t + duration - 1]
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        if(timeSeries.Length == 1)
        {
            return duration;
        }

        int[][] intervals = new int[timeSeries.Length][];

        for(int i = 0; i < timeSeries.Length; i++)
        {
            intervals[i] = new int[2] { timeSeries[i], timeSeries[i] + duration - 1 };
        }

        var resultIntervals = new List<int[]>();

        var current = intervals[0];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= current[1])
            {
                if (resultIntervals.Count > 0)
                {
                    resultIntervals.Remove(resultIntervals.LastOrDefault());
                    resultIntervals.Add([int.Min(current[0], intervals[i][0]), int.Max(current[1], intervals[i][1])]);
                }
                else
                {
                    resultIntervals.Add([int.Min(current[0], intervals[i][0]), int.Max(current[1], intervals[i][1])]);
                }
            }
            else
            {
                if (resultIntervals.Count == 0)
                {
                    resultIntervals.Add(intervals[i - 1]);
                    resultIntervals.Add(intervals[i]);
                }
                else
                {
                    resultIntervals.Add(intervals[i]);
                }
            }

            current = resultIntervals.LastOrDefault();
        }

        int result = 0;

        foreach(var interval in resultIntervals)
        {
            result += interval[1] - interval[0] + 1;
        }

        return result;
    }

    #endregion

    #region 24.3.2025

    // 56. Merge Intervals
    // Medium, Beats 39%, 51%
    // Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
    // Output: [[1, 6],[8, 10],[15, 18]]

    //[[1,4],[0,4]]
    //[[0,4]]

    //[[1,4],[0,2],[3,5]] -- [0, 2], [1, 4], [3, 5]
    //[[0,5]]
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Count() <= 1)
        {
            return intervals;
        }
        List<int[]> result = new List<int[]>();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var current = intervals[0];

        for(int i = 1; i < intervals.Length; i++)
        {

            if (intervals[i][0] <= current[1])
            {
                if(result.Count > 0)
                {
                    result.Remove(result.LastOrDefault());

                    result.Add([int.Min(current[0], intervals[i][0]), int.Max(current[1], intervals[i][1])]);
                }
                else
                {
                    result.Add([int.Min(current[0], intervals[i][0]), int.Max(current[1], intervals[i][1])]);
                }
            }
            else 
            { 
                if(result.Count == 0)
                {
                    result.Add(intervals[i - 1]);
                    result.Add(intervals[i]);
                }
                else
                {
                    result.Add(intervals[i]);
                }
            }

            current = result.LastOrDefault();
        }

        return result.ToArray();
    }

    #endregion

    #region 25.3.2025

    // 414. Third Maximum Number
    // Input: nums = [2,2,3,1]
    // Output: 1

    //[1,2,2,5,3,5]
    //[2]

    public int ThirdMax(int[] nums)
    {
        Array.Sort(nums);
        Array.Reverse(nums);

        int countDistinct = 1;
        int currentDistinct = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == currentDistinct)
            {
                continue;
            }
            else
            {
                currentDistinct = nums[i];
                countDistinct++;
            }

            if (countDistinct == 3)
            {
                return nums[i];
            }
        }

        return nums.Max();
    }

    // 748. Shortest Completing Word
    // Input: licensePlate = "1s3 PSt", words = ["step","steps","stripe","stepple"]
    // Output: "steps"
    //public string ShortestCompletingWord(string licensePlate, string[] words)
    //{
    //    var dict = new Dictionary<char, int>();

    //    var lP = licensePlate.ToLower();

    //    foreach(var ch in lP)
    //    {
    //        if (char.IsLetter(ch))
    //        {
    //            if(!dict.TryAdd(ch, 1))
    //            {
    //                dict[ch]++;
    //            }
    //        }
    //    }


    //    foreach(var word in words)
    //    {

    //    }

    //    return words[0];
    //}


    #endregion

    #region 26.3.2025

    // 206. Reverse Linked List
    // Input: head = [1,2,3,4,5]
    // Output: [5, 4, 3, 2, 1]

    public ListNode ReverseList(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        bool newHeadSetted = false;

        var newHead = head;
        var curr2 = head;
        var curr = head;

        while (head.next != null)
        {
            if (curr.next.next == null)
            {
                if (!newHeadSetted)
                {
                    newHead = curr.next;
                    newHeadSetted = true;

                    curr2 = curr.next;
                    curr2.next = curr;
                    curr.next = null;
                    curr = head;
                }
                else
                {
                    curr2 = curr.next;
                    curr2.next = curr;
                    curr.next = null;
                    curr = head;
                }
            }
            else
            {
                curr = curr.next;
            }
        }
        return newHead;
    }

    //LinkedIN question
    public int Sum(ListNode head)
    {
        int counter = 0;

        var curr = head;

        while(curr != null)
        {
            counter += curr.val;

            curr = curr.next;
        }
        return counter;
    }


    #endregion

    #region 27.3.2025

    // 203. Remove Linked List Elements
    // Input: head = [7,7,7,7], val = 7
    // Output: []

    //Unfinished
    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head == null)
        {
            return null;
        }

        if (head.next == null)
        {
            if(head.val == val)
            {
                return null;
            }
            else
            {
                return head;
            }
        }

        var curr = head;

        while (curr != null)
        {
            if(head.val == val)
            {
                head = head.next;
                curr = head;
                continue;
            }

            if (curr.next.val == val)
            {
                if (curr.next.next == null)
                {
                    curr.next = null;
                    return head;
                }
                else
                {
                    curr.next = curr.next.next;
                }
            }

            curr = curr.next;
        }

        return head;
    }

    #endregion

    #region 29.3.2025

    // 876. Middle of the Linked List
    // Easy, Beats 100%, 60%
    // Input: head = [1,2,3,4,5]
    // Output: [3, 4, 5]
    public ListNode MiddleNode(ListNode head)
    {
        int nodeCount = 0;
        int midNode = 0;
        var curr = head;
        var mid = curr;

        while(curr != null)
        {
            nodeCount++;

            curr = curr.next;
        }

        midNode = (nodeCount / 2);
        curr = head;

        while(midNode != 0)
        {
            midNode--;

            curr = curr.next;
        }

        return curr;
    }

    // 1290. Convert Binary Number in a Linked List to Integer
    // Easy, Beats 30%, 7%
    // Input: head = [1,0,1]
    // Output: 5

    public int GetDecimalValue(ListNode head)
    {
        var curr = head;
        StringBuilder sb = new();

        while(curr != null)
        {
            sb.Append(curr.val);

            curr = curr.next;
        }

        return Convert.ToInt32(sb.ToString(), 2);
    }

    // 21. Merge Two Sorted Lists

    // Input: list1 = [1,2,4], list2 = [1,3,4]
    // Output: [1, 1, 2, 3, 4, 4]

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var curr1 = list1;
        var curr2 = list2;


    }

    #endregion
}



