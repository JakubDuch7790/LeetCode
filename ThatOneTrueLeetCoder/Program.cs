using ConsoleApp1;
using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Leetcode leetcode = new Leetcode();

        ListNode n6 = new(6);
        ListNode n5 = new(5, n6);
        ListNode n4 = new(4, n5);
        ListNode n3 = new(3, n4);
        ListNode n2 = new(2, n3);
        ListNode n1 = new(1, n2);

        leetcode.Sum(n1);
        leetcode.ReverseList(n1);

        //leetcode.ShortestCompletingWord("1s3 PSt", ["step", "steps", "stripe", "stepple"]);

        leetcode.ThirdMax([1, 2, 2, 5, 3, 5]);
        leetcode.ThirdMax([2, 2, 3, 1]);

        leetcode.FindPoisonedDuration([1, 2], 2);
        leetcode.FindPoisonedDuration([1, 4], 2);

        leetcode.Merge([[1, 4], [0, 2], [3, 5]]);
        leetcode.Merge([[1, 3], [0, 2], [2, 6], [8, 10], [5, 12], [15, 18]]);
        leetcode.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]);

        leetcode.BuyChoco([1, 2, 2], 3);

        leetcode.RotateArray([1, 2, 3, 4, 5, 6]);

        leetcode.FindLucky2([2, 2, 3, 4, 4, 4, 4, 5, 5, 5, 5]);

        leetcode.FindMaxConsecutiveOnes([1, 1, 0, 1, 1, 1]);

        leetcode.ShortestToChar("loveleetcode", 'e');

        leetcode.CommonChars(["bella", "label", "roller"]);

        //leetcode.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);

        leetcode.MostFrequentEven([0, 1, 2, 2, 4, 4, 1]);

        //leetcode.ValidPalindrome("tebbem");

        leetcode.TwoSum([2, 7, 11, 15], 9);

        leetcode.FindWords(["Hello", "Alaska", "Dad", "Peace"]);

        leetcode.CheckString("aaabbb");

        leetcode.SecondHighest("dfa12321afd");

        leetcode.ReverseString(['a', 'b', 'c', 'd', 'e']);

        leetcode.PrefixCount(["pay", "attention", "practice", "attend"], "at");

        leetcode.IsIsomorphic("add", "egg");

        leetcode.IsPalindrome("A man, a plan, a canal: Panama");

        leetcode.FindTheDifference("abcd", "abcde");

        leetcode.ThreeConsecutiveOdds([1, 2, 34, 3, 4, 5, 7, 23, 12]);

        leetcode.CountSeniors(["7868190130M7522", "5303914400F9211", "9273338290F4010"]);

        leetcode.CheckAlmostEquivalentt("zzzyyy", "iiiiii");

        leetcode.DivideString("abcdefghij", 3, 'x');

        //leetcode.Fib(0);

        leetcode.CountWords(["leetcode", "is", "leetcode", "is", "amazing", "and", "fantastic"],["leetcode", "is", "leetcode", "is", "fantastic"]);

        leetcode.CountWords(["leetcode", "is", "amazing", "as", "is"], ["amazing", "leetcode", "is"]);
        //leetcode.CountValidWords("alice and  bob. are play stone-game10");
        leetcode.MostWordsFound(["alice and bob love leetcode", "i think so too", "this is great thanks very much"]);

        Leetcode.TreeNode node4 = new(2);
        Leetcode.TreeNode node3 = new(5, node4);
        Leetcode.TreeNode node1 = new(6, node3);
        Leetcode.TreeNode node2 = new(4);
        Leetcode.TreeNode node = new(10, node1, node2);

        leetcode.InorderTraversall(node);

        //Input: head = [1,2,6,3,4,5,6], val = 6

        ListNode listNode6 = new ListNode(6);
        ListNode listNode5 = new ListNode(5, listNode6);
        ListNode listNode4 = new ListNode(4, listNode5);
        ListNode listNode3 = new ListNode(3, listNode4);
        ListNode listNode2 = new ListNode(6, listNode3);
        ListNode listNode1 = new ListNode(2, listNode2);
        ListNode listNode = new ListNode(1, listNode1);

        //leetcode.RemoveElements(listNode, 6);

        //leetcode.MaximumCount([-8, -7, -5, -4, -2, -1, -1, 1, 2, 3, 4, 5, 8, 9]);

        leetcode.MaximumCount([-2, -1, 1,0,0, 2, 3, 4, 5, 6]);

        leetcode.MaximumCount([-2, -1, -1, 1, 2, 3]);

        leetcode.CapitalizeTitle("capiTalIze tHe titLe");

        leetcode.Search([2, 5], 5);
        leetcode.Search([5], 5);
        leetcode.Search([-1, 0, 3, 5, 9, 12], 2);

        leetcode.IsAnagram("anagram", "nagaram");

        leetcode.RotateString("abcde", "cdeab");

        leetcode.Solution([-1, -3]);
        leetcode.Solution([1, 2 ,3]);
        leetcode.Solution([1, 3, 6, 4, 1, 2]);


        leetcode.StrStr("mississippi", "issip");

        leetcode.LengthOfLastWord("a");

        leetcode.IsSubsequence("abc", "ahbgdc");

        leetcode.IsHappy(19);

        leetcode.CanConstruct("aa", "aab");

        leetcode.RemoveDuplicates([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]);

        //leetcode.CoinChange([2], 3);
        leetcode.CalPoints(["5", "-2", "4", "C", "D", "9", "+", "+"]);
        leetcode.CalPoints(["5", "2", "C", "D", "+"]);

        leetcode.FizzBuzz(3);

        leetcode.ReverseWords("a good   example");

        //leetcode.MergeTwoLists()

        leetcode.MaxArea([1, 8, 6, 2, 5, 4, 8, 3, 7]);

        leetcode.TwoSum([2, 7, 11, 15], 9);

        leetcode.CoinChange([186, 419, 83, 408], 6249);
    }
}