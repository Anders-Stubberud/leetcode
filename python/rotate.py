def rotate(matrix):
    copy = [row[:] for row in matrix]
    n = len(matrix)
    for i in range(n):
        inserts = copy[i]
        for j in range(n):
            matrix[j][n-1-i] = inserts[j]
    print(copy)

matrix = [[1,2,3],[4,5,6],[7,8,9]]
rotate(matrix)
print(matrix)