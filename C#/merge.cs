public class _merge_ {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int index = 0;
        for (int i=m; i<m+n; i++) {
            nums1[i] = nums2[index++];
        }
        bool sorted = false;
        while(!sorted) {
            sorted = true;
            for (int i=0; i<m+n-1; i++) {
                if (nums1[i]>nums2[i+1]) {
                   int temp = nums1[i];
                   nums1[i] = nums2[i+1];
                   nums2[i+1] = temp;
                   sorted = false;
                }
            }
        }
    }

}