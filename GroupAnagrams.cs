public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        // To find an anagram, you must check if the other string contains
        // an equivalent set of characters
        var map = new Dictionary<string, List<string>>();

        //  For each string in strs
        //      Sort characters ASC, then form a new sorted string
        //      Check if the sorted string exists in the Dictionary
        //          If not, add the string profile to the Dictionary <sortedString, originalString>
        //          If matched, add the original string to Dictionary[sortedString]
        for (int i = 0; i < strs.Length; i++)
        {
            var charArray = strs[i].ToCharArray();
            Array.Sort(charArray);
            var sortedString = new String(charArray);

            if (map.ContainsKey(sortedString))
            {
                map[sortedString].Add(strs[i]);
            }
            else
            {
                map.Add(sortedString, new List<string> { strs[i] });
            }
        }

        // return Dictionary as string of strings
        IList<IList<string>> output = new List<IList<string>>();

        foreach (var set in map)
        {
            output.Add(set.Value);
        }

        return output;
    }
}