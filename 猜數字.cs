using System;

namespace 猜數字
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 建立亂數生成器並生成要猜的數字範圍
            Random rng = new Random();
            int secretNumber = rng.Next(0, 101); // 範圍是0~100
            int lowerBound = 0;
            int upperBound = 100;
            int guess = -1;

            Console.WriteLine("歡迎來到 0~100 猜數字遊戲！");
            Console.WriteLine("系統已隨機生成一個數字，請在此範圍內進行猜測。");

            while (lowerBound < upperBound) // 使用了while迴圈
            {
                // 提示玩家輸入要猜測的數字
                Console.WriteLine($"請猜一個介於 {lowerBound} 和 {upperBound} 之間的數字："); // $字號表示讓數字被猜對範圍後lowerBound和upperBound變數會被替換為它們當前的值
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    // 檢查猜測是否在範圍內
                    if (guess < lowerBound || guess > upperBound) // 如果小於最小數字或大於最大數字
                    {
                        Console.WriteLine("輸入的數字不在範圍內，請重新輸入！");
                        continue; // 重複上方字串並重新猜數字
                    }

                    // 檢查猜測是否正確
                    if (guess == secretNumber)
                    {
                        Console.WriteLine("猜中了！");
                        return; // 終止終端，結束遊戲
                    }
                    if (guess < secretNumber)
                    {
                        Console.WriteLine("猜的數字太小了！");
                        lowerBound = guess + 1; // 如果玩家猜的數字比秘密數字小，將lowerBound更新為guess + 1
                    }
                    else
                    {
                        Console.WriteLine("猜的數字太大了！");
                        upperBound = guess - 1; // 如果玩家猜的數字比秘密數字大，將upperBound更新為guess - 1
                    }
                }
                else
                {
                    Console.WriteLine("無效的輸入，請輸入一個數字！");
                }
            }

            // 當範圍縮小到只剩一個數字時，$字號表示猜到剩最後一個數字後將值顯示為secretNumber
            Console.WriteLine($"遊戲結束！正確答案是 {secretNumber}。");
        }
    }
}