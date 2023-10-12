using System;
using System.Collections.Generic;

    class Solution
    {
        public class Node
        {
            public int id;
            Dictionary<int, int> graph;

            public Node(int id)
            {
                this.id = id;
                this.graph = new Dictionary<int, int>();
            }
            public void AddGraph(int id, int distance)
            {
                if (!this.graph.ContainsKey(id) || this.graph[id] > distance)
                {
                    this.graph[id] = distance;
                }
            }
            public Dictionary<int, int> GetGraph()
            {
                return this.graph;
            }
        }
        public int solution(int N, int[,] road, int K)
        {
            Dictionary<int, Node> nodeDict = new Dictionary<int, Node>();
            for (int i = 0; i < N; i++)
            {
                Node node = new Node(i + 1);
                nodeDict[i + 1] = node;
            }

            for (int i = 0; i < road.GetLength(0); i++)
            {
                int a = road[i, 0];
                int b = road[i, 1];
                int n = road[i, 2];

                nodeDict[a].AddGraph(b, n);
                nodeDict[b].AddGraph(a, n);
            }

            int[] time = new int[N+1];
            for (int i = 2; i < N+1; i++)
                time[i] = 500001;


            // nodeId, dist
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();

            Node start = nodeDict[1];

            foreach (var item in start.GetGraph())
            {
                if (time[item.Key] > item.Value)
                    time[item.Key] = item.Value;

                queue.Enqueue(new KeyValuePair<int, int>(item.Key, item.Value));
            }

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                foreach(var nextItem in nodeDict[item.Key].GetGraph())
                {
                    var newTime = item.Value + nextItem.Value;
                    

                    if (time[nextItem.Key] > newTime)
                    {
                        time[nextItem.Key] = newTime;

                        queue.Enqueue(new KeyValuePair<int, int>(nextItem.Key, newTime));
                    }
                }
            }

            int result = 0;
            for(int i=2; i<N+1; i++)
            {
                if (time[i] <= K)
                    result++;
            }

            return result+1;
        }
    }
