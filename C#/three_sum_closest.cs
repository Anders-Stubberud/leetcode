public class three_sum_closest {
    public static int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        int smallestDifference = 0;
        int closest = 0;
        bool first = true;
        for (int i=0; i<nums.Length-2; i++) {
            if (i!=0 && nums[i]==nums[i-1]) {
                continue;
            }
            int cur = nums[i];
            int left = i+1;
            int right = nums.Length-1;
            if (first) {
                closest = cur+nums[left]+nums[right];
                smallestDifference = difference(target,cur,nums[left],nums[right]);
                first=false;
            }
            while (left<right) {
                Console.WriteLine(cur+"-"+nums[left]+"-"+nums[right]);
                int dif = difference(target,cur,nums[left],nums[right]);
                if (dif<smallestDifference) {
                    smallestDifference = dif;
                    closest = cur+nums[left]+nums[right];
                }
                while(left+1<right && nums[left] == nums[left+2]) {
                    left++;
                }
                while(left+1<right && nums[right] == nums[right-2]) {
                    right--;
                }
                if (closest==target) {
                    return closest;
                }
                else if (cur+nums[left]+nums[right]<target) {
                    left++;
                }
                else {
                    right--;
                }
            }
        }
        return closest;
    }
    public static int difference(int target, int a, int b, int c) {
        return Math.Max(a+b+c, target) - Math.Min(a+b+c, target);
    }
}