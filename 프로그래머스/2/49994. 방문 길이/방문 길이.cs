using System;
using System.Collections.Generic;
using System.Linq;
    public class Solution
    {
        public class Vector2
        {
            public Vector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int x;
            public int y;
            public int ToHash()
            {
                return (x+5)*100+(y+5);
            }
        }
        public int solution(string dirs)
        {
            Dictionary<string, bool> map = new Dictionary<string, bool>();
            Vector2 pos = new Vector2(0, 0);
            const int limit = 5;
            foreach(char dir in dirs)
            {
                int pre = pos.ToHash();
                switch (dir)
                {
                    case 'U':
                        if(pos.y<limit)
                            pos.y += 1;
                        break;
                    case 'D':
                        if(pos.y>-1*limit)
                            pos.y -= 1;
                        break;
                    case 'L':
                        if(pos.x>-1*limit)
                            pos.x -= 1;
                        break;
                    case 'R':
                        if(pos.x<limit)
                            pos.x += 1;
                        break;
                }
                int post = pos.ToHash();
                
                if(pre==post) continue;
                
                if (pre < post)
                {
                    var tmp = pre;
                    pre = post;
                    post = tmp;
                }

                map[$"{pre}{post}"] = true;
            }

            return map.Keys.Count();
        }
    }
