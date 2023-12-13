class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:

        intervals.sort(key = lambda x : x[1])
        
        # grådig aktivitetsutvelgelse basert på slutt.tidspunkter
        for i in range(len(intervals) - 1, 0, -1):
            start, end = intervals[i - 1], intervals[i]
            if start[1] >= end[0]: # merge
                intervals[i - 1] = [min(start[0], end[0]), end[1]]
                intervals.pop(i)

        return intervals