public class is_anagram {
    public static bool IsAnagram(string s, string t) {
        List<char> Hs = new List<char>();
        List<char> Ht = new List<char>();
        if (s.Length != t.Length) {
            return false;
        }
        for (int i=0; i<s.Length; i++) {
            Hs.Add(s[i]);
        }
        for (int i=0; i<s.Length; i++) {
            if (Hs.Contains(t[i])) {
                Hs.Remove(t[i]);
            }
            else {
                return false;
            }
        }
        return true;
    }
}