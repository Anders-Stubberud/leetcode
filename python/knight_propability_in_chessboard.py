

def knightProbability_recursive_top_down(n, k, row, column):

    memo = {}
    moves = {(2, 1), (2, -1), (1, -2), (1, 2), (-2, -1), (-2, 1), (-1, 2), (-1, -1)}
    
    def valid_positions(position):
        current_row, current_column = position[0], position[1]
        valid_positions = set()
        for r, c in moves:
            new_row, new_column = current_row + r, current_column + c
            if 0 <= new_row < n and 0 <= new_column < n : valid_positions.add((new_row, new_column))
        return valid_positions
    
    def probability(position, k):
        if k == 0 : return 1
        if position not in memo:
            memo[position] = (1/8) * (sum([probability(pos, k - 1) for pos in valid_positions(position)]))
        return memo[position]
    
    return probability((row, column), k)

def knightProbability_iterative_bottom_up(n, k, row, column):
    moves = ((2, 1), (2, -1), (1, -2), (1, 2), (-2, -1), (-2, 1), (-1, 2), (-1, -2))
    
    dp = [[[0.0 for _ in range(n)] for _ in range(n)] for _ in range(k + 1)]
    
    dp[0][row][column] = 1.0 # indikerer at etter 0 trekk, så er det 1 for å være på org, 0 alle andre steder
    
    for step in range(1, k + 1):
        for r in range(n):
            for c in range(n):
                for dr, dc in moves:
                    nr, nc = r + dr, c + dc
                    if 0 <= nr < n and 0 <= nc < n:
                        dp[step][nr][nc] += dp[step - 1][r][c] / 8.0
    
    # samlet sannsynlighet for hver enkelt posisjon på brettet tilsvarer sannsynlighet for å befinne seg på brettet
    result = sum(sum(dp[k][i][j] for i in range(n)) for j in range(n))
    
    return result