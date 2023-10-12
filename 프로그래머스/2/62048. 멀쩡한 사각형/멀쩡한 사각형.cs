using System;

public class Solution {
    public long solution(int w, int h) {
        long answer  = 0;
        
        for(int i=0; i<w; i++){
            int n = h-(int)Math.Ceiling((double)h/w*(i+1));
            
            answer+=n;
        }
        
        return answer*2;
    }
}