

class Solution:
    def longestValidParentheses(self, s: str) -> int:

        stack, maximum = [-1], 0

        for i, c in enumerate(s):
            if c is '(' : stack.append(i)
            else:
                stack.pop()
                if not stack : stack.append(i)
                maximum = max(maximum, i - stack[-1])

        return maximum

    # for treg
    def longest_valid_parentheses_recursive_memoization(self, s: str) -> int: # type: ignore

        n = len(s)
        memo = {} # key: (start, end), value: (value, boolean)

        def pair(interval) : return (interval[0] - interval[1]) % 2 == 1

        def backtrack(start, end):

            def memoize(value, boolean) : memo[(start, end)] = (value, boolean)

            interval = (start, end)

            if interval not in memo:

                if start >= end : memoize(0, False)
                elif start + 1 == end : memoize(2, True) if s[start] == '(' and s[end] == ')' else memoize(0, False)
                elif pair(interval) and s[start] == '(' and s[end] == ')' and backtrack(start + 1, end - 1)[1] : memoize(memo[(start + 1, end - 1)][0] + 2, True)
                else:
                    for i in range(start, end):
                        left, right = backtrack(start, i), backtrack(i + 1, end)
                        if left[1] and right[1] : memoize(left[0] + right[0], True)
                        max_left_right = max(left[0], right[0])
                        if interval not in memo or max_left_right > memo[interval][0] : memo[interval] = (max_left_right, False)

            return memo[interval]

        return backtrack(0, n - 1)[0]
