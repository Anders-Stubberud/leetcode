from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def swapPairs(self, head: Optional[ListNode]) -> Optional[ListNode]:

        if not (head and head.next) : return head

        left, right, res, prev = head, head.next, head.next, None

        while left and right:

            if prev : prev.next = right

            left.next = right.next
            right.next = left

            prev = left
            left = left.next
            right = left.next if left else None

        return res
