public class three_sum {
    //Bruke HashSet istedenfor å sjekke manuelt
    //hoppe over sekvenser der forrige tilsvarer nåværende
    public static IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> liste = new List<IList<int>>();
        for (int i = 0; i<nums.Length-2; i++) {
            for (int j=i+1; j<nums.Length-1; j++) {
                if (containsRequiredInt(nums, ((nums[i] + nums[j]) * -1), j+1)) {
                    if (notDup(liste, new int[]{nums[i], nums[j], ((nums[i] + nums[j]) * -1)})) {
                        liste.Add(new List<int>{nums[i], nums[j], ((nums[i] + nums[j]) * -1)});
                    }
                }
            }
        }
        return liste;
    }

    static bool containsRequiredInt(int [] nums, int target, int index) {
        for (int i=index; i<nums.Length; i++) {
            if (nums[i] == target) {
                return true;
            }
        }
        return false;
    }

    static bool notDup(IList<IList<int>> liste, int[] array) {
        foreach (IList<int> sublist in liste) {
            int [] sortedSubList = bubbleSort(sublist.ToArray());
            int [] sortedArray = bubbleSort(array);
            int counter = 0;
            int limit = sortedSubList.Length;
            for (int i=0; i<limit; i++) {
                if (sortedSubList[i] != sortedArray[i]) {
                    break;
                }
                counter++;
            }
            if (counter == limit) {
                return false;
            }
        }
        return true;
    }

    static int[] bubbleSort(int [] array) {
        bool toggle = false;
        for (int i=0; i<array.Length-1; i++) {
            toggle = false;
            for (int j=0; j<array.Length-i-1; j++) {
                if (array[j] > array[j+1]) {
                    int temp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = temp;
                    toggle = true; 
                }
            }
            if (! toggle) {
                break;
            }
        }
        return array;
    }
}