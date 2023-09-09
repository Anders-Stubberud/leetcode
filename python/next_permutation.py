def nextPermutation(nums):
    """
    Do not return anything, modify nums in-place instead.
    """

    index_candidate = len(nums) - 1
    index_swapper = len(nums) - 2
    while nums[index_candidate] < nums[index_swapper] and index_swapper >= 0:
        index_swapper -= 1
        #finne minste som er større enn swapper
    if index_swapper >= 0:
        nums[index_swapper], nums[index_candidate] = nums[index_candidate], nums[index_swapper]

    for i in range(index_swapper + 2, len(nums)):
        key = nums[i]
        j = i - 1
        while j >= index_swapper + 1 and key < nums[j]:
            nums[ j + 1 ] = nums[ j ]
            j -= 1
        nums[ j + 1 ] = key

    print(nums)

nextPermutation([2,3,1])