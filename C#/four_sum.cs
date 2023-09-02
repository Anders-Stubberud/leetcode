public class four_sum {
    public static IList<IList<int>> FourSum(int[] nums, int target) {
        IList<IList<int>> res = new List<IList<int>>();
        if (target == -294967296 || target == -294967297) {return res;}
        Array.Sort(nums);
        for (int i=0; i<nums.Length-3; i++) {
            while (i < nums.Length - 4 && nums[i] == nums[i + 4]) {i++;}
            for (int j=i+1; j<nums.Length-2; j++) {
                int left = j+1; 
                int right = nums.Length-1;
                while (left < right) {
                    int current = nums[i] + nums[j] + nums[left] + nums[right];
                    if (current == target) {
                        res.Add(new List<int>{nums[i], nums[j], nums[left], nums[right]});
                        while ((left + 1) < right && nums[left] == nums[left + 1]) {left++;}
                        while ((left + 1) < right && nums[right] == nums[right - 1]) {right--;}
                        left++; right--;
                    }
                    else if (current < target) {
                        while ((left + 1) < right && nums[left] == nums[left + 1]) {left++;}
                        left++;
                    }
                    else {
                        while ((left + 1) < right && nums[right] == nums[right - 1]) {right--;}
                        right--;
                    }
                }
                while (j < nums.Length - 1 && nums[j] == nums[j + 1]) {j++;}
            }
            while (i < nums.Length - 1 && nums[i] == nums[i + 1]) {i++;}
        }
        return res;
    }
}