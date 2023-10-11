using System;

public class Solution {
    public int solution(int[] array, int n) {
        int count =0;
        
        for(int i=0; i<array.Length; i++)
            if(array[i] == n) count++;
        
        return count;
    }
}