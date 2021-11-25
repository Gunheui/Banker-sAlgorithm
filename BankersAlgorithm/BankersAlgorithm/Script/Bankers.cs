using System;
using System.Collections.Generic;
using System.Linq;

namespace BankersAlgorithm.Script
{

    public class Bankers
    {
        /// <summary>
        /// Process들
        /// </summary>
        private List<Process> Processes;
        
        /// <summary>
        /// Available
        /// </summary>
        private List<int> Available;

        /// <summary>
        /// Bankers 생성자
        /// </summary>
        public Bankers()
        {
            Processes = new List<Process>();
            Available = new List<int>();
        }

        /// <summary>
        /// Available을 초기화한다.
        /// </summary>
        /// <param name="available">초기화할 Available</param>
        public void InitAvailable(int[] available)
        {
            Available = available.ToList();
        }

        /// <summary>
        /// Process를 추가하는 함수
        /// </summary>
        /// <param name="max">해당 Process Max</param>
        /// <param name="allocation">해당 Process Alloction</param>
        public void InitProcess(int[] max, int[] allocation)
        {
            var process = new Process(max.ToList(), allocation.ToList());
            Processes.Add(process);
        }

        /// <summary>
        /// Allocation을 추가하는 함수
        /// </summary>
        /// <param name="idx">Process의 Idx</param>
        /// <param name="addAllocation">추가할 Allocation</param>
        public void AddAllocation(int idx, int[] addAllocation)
        {
            var selectedProcess = Processes.FirstOrDefault(process => process.ID.Equals(idx));

            if (selectedProcess == null) return;
            for (var i = 0; i < selectedProcess.Allocation.Count; i++)
            {
                selectedProcess.Allocation[i] += addAllocation[i];
                Available[i] -= addAllocation[i];
            }
        }

        /// <summary>
        /// Bankers 알고리즘 실행
        /// </summary>
        public void Running()
        {
            var isSafe = false;
            Console.WriteLine("Sequence(Process / Available)");
            while (true)
            {
                //해당 List를 한번 순회하였을 떄 Process를 처리한 횟수
                var clearCount = 0;
                
                for (var i = 0; i < Processes.Count; i++)
                {
                    var process = Processes[i];
                    if (!process.IsDone)
                    {
                        if (process.ProcessClear(ref Available))
                        {
                            isSafe = true;
                            Console.WriteLine($"Process #{process.ID} {string.Join(",",Available.Select(val => val.ToString()).ToArray())}");
                            clearCount++;
                        }
                    }
                        
                    //모두 순회하였지만, 해결한 프로세스가 없는 경우
                    if (i.Equals(Processes.Count - 1) && clearCount.Equals(0))
                    {
                        var state = isSafe ? "Safe" : "Unsafe";
                        Console.WriteLine($"State : {state}");
                        return;
                    }
                }
            }
        }

    }
}