using System;
using System.Collections.Generic;

    class Solution
    {
        public class Truck
        {
            public int weight;
            public int pos;
        }
        public int solution(int bridge_length, int weight, int[] truck_weights)
        {
            Queue<int> truckQueue = new Queue<int>();
            for(int i=0; i<truck_weights.Length; i++)
            {
                truckQueue.Enqueue(truck_weights[i]);
            }

            int totalWeight = 0;
            Queue<Truck> bridgeQueue = new Queue<Truck>();
            for(int i=0; ; i++)
            {
                // 종료 조건 확인
                if (bridgeQueue.Count == 0 && truckQueue.Count == 0)
                    return i;

                // 위치 갱신
                foreach(var truck in bridgeQueue)
                {
                    truck.pos += 1;
                }

                // 도착한 차량이 있는지 확인
                if(bridgeQueue.Count > 0 && bridgeQueue.Peek().pos > bridge_length)
                {
                    var truck = bridgeQueue.Dequeue();
                    totalWeight -= truck.weight;
                }

                // 차량 투입할지 확인
                if(truckQueue.Count > 0 && totalWeight + truckQueue.Peek() <= weight)
                {
                    Truck truck = new Truck();
                    truck.weight = truckQueue.Dequeue();
                    truck.pos = 1;
                    
                    bridgeQueue.Enqueue(truck);
                    totalWeight += truck.weight;
                }
            }
        }
    }
