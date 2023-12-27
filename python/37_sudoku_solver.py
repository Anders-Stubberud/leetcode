from typing import List
import time

class Solution:

    def solveSudoku(self, board):

        def sudoku(row, column):

            if row > 8 : return True


    # treg
    def solveSudoku2(self, board: List[List[str]]) -> None:
        """
        Do not return anything, modify board in-place instead.
        """

        n, default, map_dependencies = len(board), '.', {}

        def dependencies(row, column): # set av (row, column) av celler row, column må ta hensyn til
            low_row, low_col = (row // 3) * 3, (column // 3) * 3
            high_row, high_col = low_row + 3, low_col + 3
            return  {(r, column) for r in range(n)} \
                  | {(row, c) for c in range(n)} \
                  | {(r, c) for r in range(low_row, high_row) for c in range(low_col, high_col)} \
                  - {(row, column)}

        def possible_values(row, column): # (row, column) sine mulige verdier, og cellene posisjonen må ta hensyn til
            if board[row][column] is not default: return []
            res, position = [str(value) for value in range(1, 10)], (row, column)
            if position not in map_dependencies : map_dependencies[position] = dependencies(row, column)
            for r, c in map_dependencies[position]:
                if board[r][c] in res: res.remove(board[r][c])
            return res

        def backtrack(row, column):
            if board[row][column] is not default : return False # verdi er allerede definert, trenger ikke undersøke nærmere
            values, dependencies = possible_values(row, column), map_dependencies[(row, column)]
            if not values : return True # problem; verdien er udefinert, men det er ikke mulig å tilegne innenfor regelverket
            for value in values:
                board[row][column], toggle = value, False
                for r, c in dependencies:
                    if backtrack(r, c):
                        toggle = True
                        break
                if not toggle : return False # alle rekursive kall har fungert, da fungerer denne tilordningen
                else : board[row][column] = default # resetter og prøver med annen verdi
            return True # dersom ingen av verdiene har fungert, så er det en øvre tilordning som ikke er kompatibel

        for row in range(n):
            for column in range(n):
                backtrack(row, column)

board = [
         [".", ".", ".", "7", "5", ".", ".", "8", "1"],
         [".", ".", ".", ".", ".", "8", "9", "2", "7"],
         [".", ".", "7", ".", ".", ".", ".", ".", "."],
         [".", "3", "2", ".", ".", "5", ".", ".", "."],
         [".", "1", "6", ".", ".", ".", "2", "9", "."],
         [".", ".", ".", "6", ".", ".", "8", "3", "."],
         [".", ".", ".", ".", ".", ".", "6", ".", "."],
         ["7", "9", "3", "5", ".", ".", ".", ".", "."],
         ["5", "6", ".", ".", "9", "1", ".", ".", "."]
        ]

start = time.time()
Solution().solveSudoku(board)
end = time.time()
for row in board : print(row)
print(f'\n\n\n{end - start}')
