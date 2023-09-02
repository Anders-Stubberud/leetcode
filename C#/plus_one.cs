public class plus_one {
    public static int[] PlusOne(int[] digits) {
        for (int i=digits.Length-1; i>=0; i--) {
            if (digits[i] != 9) {
                digits[i] += 1;
                for (int j=i+1; j<digits.Length; j++) {
                    digits[j] = 0;
                }
                return digits;
            }
        }
        int[] arr = new int[digits.Length + 1];
        arr[0] = 1;
        for (int i=1; i<arr.Length; i++) {
            arr[i] = 0;
        }
        return arr;
    }

}