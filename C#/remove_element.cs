public class remove_element {
    public static int RemoveElement(int[] nums, int val) {
        IList<int> liste = new List<int>();
        int res = 0;
        foreach (int i in nums) {
            if (i != val) {
                liste.Add(i);
            }
            else {
                res += 1;
            }
        }
        for (int i = 0; i<liste.Count; i-=-1) {
            nums[i] = liste[i];
        }
        for (int i=liste.Count; i<liste.Count+res; i++) {
            nums[i] = 0;
        }
        Console.WriteLine(String.Join(", ", nums));
        return nums.Length - res;
    }

}