public class _subsets_ {
    public static IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        for (int i=0; i<Math.Pow(2, nums.Length); i++) {
            String binary = Convert.ToString(i, 2);
            for (int k=binary.Length; k<nums.Length; k++) {
                binary = "0" + binary;
            }
            IList<int> liste = new List<int>();
            for (int j=binary.Length-1; j>=0; j--) {
                if (Convert.ToInt32(Convert.ToString(binary[j])) == 1) {
                    liste.Add(nums[j]);
                }
            }
            res.Add(liste);
        }
        return res;
    }
    
}