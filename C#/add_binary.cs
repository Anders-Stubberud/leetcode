public class add_binary {
    public string AddBinary(string a, string b) {
        int IndexA = a.Length-1;
        int IndexB = b.Length-1;
        bool carry = false;
        String res = "";
        for (int i=Math.Min(IndexA, IndexB); i>=0; i--) {
            if (a[IndexA] == '1' && b[IndexB] == '1') {
                if (carry) {
                    res = "1" + res;
                } 
                else {
                    res = "0" + res;
                }
                carry = true;
            }
            else {
                if (carry) {
                    if (a[IndexA] == '1' || b[IndexB] == '1') {
                        res = "0" + res;
                    }
                    else {
                        res = "1" + res;
                        carry = false;
                    }
                }
                else {
                    if (a[IndexA] == '1' || b[IndexB] == '1') {
                        res = "1" + res;
                    }
                    else {
                        res = "0" + res;
                    }
                }
            }
            IndexA--;
            IndexB--;
        }
        if (!  (IndexA == IndexB)) {
            String s = "";
            int rem = 0;
            if (IndexA>IndexB) {
                rem = IndexA;
                s = a;
            } 
            else {
                rem = IndexB;
                s = b;
            }
            for (int i=rem; i>=0; i--) {
                if (carry) {
                    if (s[rem] == '1') {
                        res = "0" + res;
                    }
                    else {
                        res = "1" + res;
                        carry = false;
                    }
                }
                else {
                    res = Convert.ToString(s[rem]) + res;
                }
                rem--;
            }
        }
        if (carry) {
            res = "1" + res;
        }
        return res;
    }
}