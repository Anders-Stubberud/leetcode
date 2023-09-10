import math
def nextPermutation(nums):
    """
    Do not return anything, modify nums in-place instead.
    """
    index_swap = len(nums) - 2
    while nums[index_swap + 1] <= nums[index_swap] and index_swap >= 0:
        index_swap -= 1
    if index_swap >= 0:
        smallest_largest_index = index_swap + 1
        for i in range(index_swap+2, len(nums)):
            if nums[i] < nums[smallest_largest_index] and nums[i] > nums[index_swap]:
                smallest_largest_index = i
        nums[index_swap], nums[smallest_largest_index] = nums[smallest_largest_index], nums[index_swap]
    for i in range(index_swap + 2, len(nums)):
        key = nums[i]
        j = i-1
        while j >= index_swap + 1 and key < nums[j]:
            nums[j + 1] = nums[j]
            j -= 1
        nums[j+1] = key
        
    print(index_swap)
    print(nums)

nextPermutation([5,1,1])