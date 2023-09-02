public class climb_stairs {
    public static int ClimbStairs(int n) {
        if (n==1) {
            return 1;
        }
        else if (n==2) {
            return 2;
        }
        return ClimbStairs(n-1) + ClimbStairs(n-2);
    }

    public static int ClimbStairs2(int n) {
        int cur = 1;
        int pre1 = 1;
        int pre2 = 0;
        for (int i=0; i<n; i++) {
            cur = pre1 + pre2;
            pre2 = pre1;
            pre1 = cur;
        }
        return cur;
    }
    
}