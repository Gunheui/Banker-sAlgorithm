using System;
using BankersAlgorithm.Script;

namespace BankersAlgorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //1번 문제
            var bankersP1 = new Bankers();
            bankersP1.InitAvailable(new[] {3, 2, 1, 1});
            bankersP1.InitProcess(new[] {6, 0, 1, 2}, new[] {4, 0, 0, 1});
            bankersP1.InitProcess(new[] {1, 7, 5, 0}, new[] {1, 1, 0, 0});
            bankersP1.InitProcess(new[] {2, 3, 5, 6}, new[] {1, 2, 5, 4});
            bankersP1.InitProcess(new[] {1, 6, 5, 3}, new[] {0, 6, 3, 3});
            bankersP1.InitProcess(new[] {1, 6, 5, 6}, new[] {0, 2, 1, 2});
            
            Console.WriteLine("Problem 1.");
            bankersP1.Running();

            //2번문제 
            var bankersP2 = new Bankers();
            Process.Idx = 0;
            bankersP2.InitAvailable(new[] {3, 2, 1, 1});
            bankersP2.InitProcess(new[] {6, 0, 1, 2}, new[] {4, 0, 0, 1});
            bankersP2.InitProcess(new[] {1, 7, 5, 0}, new[] {1, 1, 0, 0});
            bankersP2.InitProcess(new[] {2, 3, 5, 6}, new[] {1, 2, 5, 4});
            bankersP2.InitProcess(new[] {1, 6, 5, 3}, new[] {0, 6, 3, 3});
            bankersP2.InitProcess(new[] {1, 6, 5, 6}, new[] {0, 2, 1, 2});
            
            //Allocation 추가
            bankersP2.AddAllocation(4, new[] {1, 2, 0, 0});
            
            Console.WriteLine("Problem 2.");
            bankersP2.Running();
            
        }
    }
}