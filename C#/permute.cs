public class _permute_ {
    public static IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> SL = new List<IList<int>>();
        DFS(new List<int>(), SL, nums);
        return distinct(SL);
    }

    public static IList<IList<int>> distinct(IList<IList<int>> original) {
        IList<IList<int>> res = new List<IList<int>>();
        foreach (IList<int> s in original) {
            bool sim = false;
            foreach (IList<int> ints in res) {
                if (similar(ints, s)) {
                    sim = true;
                    break;
                }
            }
            if (! sim) {
                res.Add(s);
            }
        }
        return res;
    }

    public static bool similar(IList<int> original, IList<int> res) {
        for (int i=0; i<res.Count; i++) {
            if (original[i] != res[i]) {
                return false;
            }
        }
        return true;
    }

    public static void DFS(IList<int> LL, IList<IList<int>> SL, int[] nums) {
        foreach (int i in nums) {
            var newLL = new List<int>(LL);
            newLL.Add(i);
            if (nums.Length == 1) {
                SL.Add(newLL);
                return;
            }
            else {
                DFS(newLL, SL, newIntArray(nums, i));
            }
        }
    }

    public static int[] newIntArray(int[] nums, int remove) {
        int[] result = new int[nums.Length - 1];
        bool removed = false;
        int index = 0;
        foreach (int i in nums) {
            if (! removed && i==remove) {
                removed = true;
                continue;
            }
            result[index++] = i;
        }
        return result;
    }
}