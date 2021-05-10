public class RandomizedSet {
    private List<int> lst;
    private Dictionary<int, int> dic;//num, index in lst
    /** Initialize your data structure here. */
    public RandomizedSet() {
        lst = new List<int>();
        dic = new Dictionary<int, int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(dic.ContainsKey(val)) {
            return false;
        }
        lst.Add(val);
        dic.Add(val, lst.Count - 1);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!dic.ContainsKey(val)) {
            return false;
        }
        int index = dic[val];
        if(index == lst.Count - 1) {
            lst.RemoveAt(index);
        }
        else {
            lst[index] = lst[lst.Count - 1];
            dic[lst[index]] = index;
            lst.RemoveAt(lst.Count - 1);
        }
        dic.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        Random rd = new Random();
        return lst[rd.Next(0, lst.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */