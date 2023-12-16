from typing import List


class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        memo = {}
        for word in strs:
            s = ''.join(sorted(list(word)))
            if s in memo : memo[s].append(word)
            else : memo[s] = [word]
        return [memo[key] for key in memo.keys()]


solution = Solution()
strs = ["eat" ,"tea" ,"tan" ,"ate" ,"nat" ,"bat"]
res = solution.groupAnagrams(strs)
print(res)