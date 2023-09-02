public class min_path_sum {
    public static int MinPathSum(int[][] grid) {

        //Global variabel som populeres av Dijkstra
        IDictionary<IList<int>, int> dic = new Dictionary<IList<int>, int>();

        //Legger til alle noder som ubesøkte (definerer ubesøkt som at ikke samtlige veier videre er utforsket)
        ISet<IList<int>> unVisited = new HashSet<IList<int>>();
        for (int i=0; i<grid.Length; i++) {
            for (int j=0; j<grid[i].Length; j++) {
                IList<int> node = new List<int>{i, j};
                unVisited.Add(node);
                if (i==0 && j== 0) {
                    dic[node] = grid[i][j];
                }
                else {
                    dic[node] = int.MaxValue-1;
                }
            } 
        }

        //Finner minste ubesøkte node
        IList<int> smallest() {
            int smallest = int.MaxValue;
            IList<int> res = new List<int>();
            foreach (IList<int> s in unVisited) {
                if (dic[s] < smallest) {
                    smallest = dic[s];
                    res = s;
                }
            }
            return res;
        }

        bool eq(IList<int> a, IList<int> b) {
            return (a[0] == b[0] && a[1] == b[1]);
        }

        bool Has(int y, int x) {
            foreach (IList<int> ints in dic.Keys) {
                if (y==ints[0] && x== ints[1]) {
                    return true;
                }
            }
            return false;
        }

        int getValue(int y, int x) {
            foreach(IList<int> ints in dic.Keys) {
                if (y==ints[0] && x== ints[1]) {
                    return dic[ints];
                }
            }
            return int.MaxValue-1;
        }

        IList<int> getList(int y, int x) {
            foreach (IList<int> ints in dic.Keys) {
                if (y==ints[0] && x==ints[1]) {
                    return ints;
                }
            }
            return new List<int>();
        }
        
        //Dijkstra's algoritme (small = smallest()).Equals((grid.Length - 1) + "" + (grid[grid.Length - 1].Length - 1)))
        IList<int> small;
        while (unVisited.Count>0 && !(eq((small=smallest()), new List<int>{grid.Length-1, grid[grid.Length-1].Length}))) {
            unVisited.Remove(small);
            int y = small[0];
            int x = small[1];
            
            //Oppdatere avstand under
            //(Ikke nederste && allerede i dic && mindre) || (ikke nederste && ikke i dic)
            if ((y<grid.Length-1 && Has(y+1, x) && getValue(y+1, x) > dic[small] + grid[y+1][x])
            || (y<grid.Length-1 && !Has(y+1, x))) {
                dic[getList(y+1, x)] = dic[getList(y, x)] + grid[y+1][x];
            }

            //Oppdatere avstand Høyre
            //(Ikke lengst høyre && allerede i dic && mindre) || (ikke lengst høyre && ikke i dic)
            if (x <grid[y].Length - 1 && Has(y, x+1) && getValue(y, x+1) > getValue(y, x) + grid[y][x+1]
            || (x <grid[y].Length - 1 && !Has(y, x+1))) {
                dic[getList(y, x+1)] = dic[getList(y, x)] + grid[y][x+1];
            }
        }

        return dic[getList(grid.Length-1, grid[grid.Length-1].Length-1)];
    }
}