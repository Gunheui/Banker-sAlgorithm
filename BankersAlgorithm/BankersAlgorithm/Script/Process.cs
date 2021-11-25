using System.Collections.Generic;
using System.Linq;

namespace BankersAlgorithm.Script
{
    public class Process
    {
        /// <summary>
        /// Process의 Index를 생성할 때 사용
        /// </summary>
        public static int Idx = 0;
        
        public List<int> Max;
        
        public List<int> Allocation;
        
        public int ID;
        /// <summary>
        /// 해당 프로세스가 종료되었는지 확인하는 변수
        /// </summary>
        public bool IsDone;

        public Process(List<int> max, List<int> allocation)
        {
            Max = max;
            Allocation = allocation;
            ID = Idx;
            IsDone = false;
            Idx++;
        }

        /// <summary>
        /// Needs를 알아내는 함수
        /// </summary>
        /// <returns>Needs</returns>
        public List<int> GetNeeds()
        {
            var result = Max.Select((maxVal, idx) =>
                maxVal - Allocation[idx]
            ).ToList();
            return result;
        }

        /// <summary>
        /// Process를 완료할 수 있는지 확인 후 완료가 가능하면 완료시킨다.
        /// </summary>
        /// <param name="available"></param>
        /// <returns>Process를 완료히면 true, 실패하면 false를 반환</returns>
        public bool ProcessClear(ref List<int> available)
        {
            var needs = GetNeeds();
            var isSafe = true;
            for (int i = 0; i < needs.Count; i++)
            {
                if (available[i] - needs[i] >= 0) continue;
                isSafe = false;
                break;
            }

            if (!isSafe) return false;
            {
                for (int i = 0; i < available.Count; i++)
                {
                    available[i] += Allocation[i];
                }
                IsDone = true;
            }
            return true;
        }

    }
}