namespace LeetCodeNet.G0201_0300.S0295_find_median_from_data_stream {

// #Hard #Top_100_Liked_Questions #Sorting #Two_Pointers #Design #Heap_Priority_Queue #Data_Stream
// #Top_Interview_150_Heap #Big_O_Time_O(n*log_n)_Space_O(n)
// #2025_06_16_Time_191_ms_(41.28%)_Space_111.30_MB_(45.74%)

using System;
using System.Collections.Generic;

public class MedianFinder {
    private PriorityQueue<int, int> left = new();
    private PriorityQueue<int, int> right = new();
    private bool odd = false;

    public void AddNum(int n) {
        odd = !odd;
        int m = right.EnqueueDequeue(n, -n);
        left.Enqueue(m, m);     
        if (left.Count - 1 > right.Count) {
            m = left.Dequeue();
            right.Enqueue(m, -m);
        }
    }
    
    public double FindMedian() =>
        odd ? left.Peek() : (left.Peek() + right.Peek()) / 2.0;
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
}
