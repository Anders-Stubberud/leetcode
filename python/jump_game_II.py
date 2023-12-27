from math import inf


def jump_iterative_bottom_up(nums):
        n = len(nums)
        arr = [None for _ in range(n)]
        arr[n - 1] = 0
        for i in range(n - 2, -1, -1):
            fewest_from_reachable = inf
            for j in range(i + 1, min(i + 1 + nums[i], n)):
                if fewest_from_reachable > arr[j]:
                    fewest_from_reachable = arr[j]
            arr[i] = fewest_from_reachable + 1
        return arr[0]


def jump_recursive_top_down(nums):
    n = len(nums)
    arr = [None for _ in range(n)]
    arr[n - 1] = 0
    def get_val(index):
        if arr[index] == None:
            fewest_from_reachable = inf
            for i in range(index + 1, min(index + 1 + nums[index], n)):
                val = get_val(i)
                if fewest_from_reachable > val : fewest_from_reachable = val
            arr[index] = fewest_from_reachable + 1
        return arr[index]
    return get_val(0)
