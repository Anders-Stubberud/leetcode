public class _single_ {
    public static int Single(int[] array) {
        int ans = 0;
        foreach (int i in array) {
            ans ^= i;
        }
        return ans;
    }

}