public class longest_valid_parentheses {
    public static int LongestValidParenthsis(string s) {
        int rc = 0;
        int lc = 0;
        int record = 0;
        foreach (char c in s) {
            if (c == '(') {
                lc++;
            }
            else {
                rc++;
            }
            if (rc > lc) {
                rc = 0; 
                lc = 0;
            }
            else {
                record = Math.Min(rc, lc);
            }
        }
        return 2 * record;
    }

}