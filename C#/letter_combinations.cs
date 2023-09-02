public class letter_combinations {
    public static IList<string> LetterCombinations(string digits) {
        IDictionary<char, IList<string>> dic = new Dictionary<char, IList<string>> {
            { '2', new string[] { "a", "b", "c" }},
            { '3', new string[] { "d", "e", "f" }},
            { '4', new string[] { "g", "h", "i" }},
            { '5', new string[] { "j", "k", "l" }},
            { '6', new string[] { "m", "n", "o" }},
            { '7', new string[] { "p", "q", "r", "s" }},
            { '8', new string[] { "t", "u", "v" }},
            { '9', new string[] { "w", "x", "y", "z" }}
        };
        IList<string> list = new List<string>();
        dfs(dic, "", digits, 0, list);
        return list;
    }

    public static void dfs(IDictionary<char, IList<string>> dic, string path, string digits, int level, IList<string> list) {
        if (level == digits.Length && level != 0) {
            list.Add(path);
            return;
        }

        foreach (string s in dic[digits[level]]) {
            dfs(dic, path + s, digits, level + 1, list);
        }
    }
    
}