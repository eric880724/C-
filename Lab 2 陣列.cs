using System;
using System.Collections.Generic;

namespace VirusTransmission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 步驟1: 輸入公民的數量
            Console.Write("輸入公民ID: ");
            int N = int.Parse(Console.ReadLine()); // 用int.Parse將Console.ReadLine()的值轉為整數

            // 步驟2: 定義接觸者資料
            int[] contactees = new int[N]; // 形成陣列contactees，N為先前輸入的公民數量，也是陣列長度
            Random rng = new Random();

            // 步驟3: 生成隨機接觸者的數據
            List<int> ids = new List<int>();
            for (int i = 0; i < N; i++)
            {
                ids.Add(i);
            }
            ids = Shuffle(ids, rng); // 打亂ID順序

            for (int i = 0; i < N; i++)
            {
                contactees[i] = ids[i]; // 將洗牌後的列表ids複製到contactees陣列中，模擬每位公民接觸的對象
            }

            // 步驟4: 顯示每位公民的接觸者資料
            Console.WriteLine("\nId\t" + string.Join(" ", Enumerable.Range(0, N))); // Enumerable.Range(0, N)生成從0到N-1的數字列
            Console.WriteLine("Contactee\t" + string.Join(" ", contactees)); // string.Join(" ", contactees)是將序列中的數字用空格連接

            Console.WriteLine("\n----------------");

            // 步驟5: 輸入被感染的初始公民ID
            Console.Write("輸入被感染的公民ID: ");
            int infectedId = int.Parse(Console.ReadLine());

            // 步驟6: 追踪傳染鏈，列出需要隔離的公民
            List<int> isolationList = new List<int>(); // 建立隔離名單，存放需要隔離的公民ID
            while (!isolationList.Contains(infectedId))
            {
                isolationList.Add(infectedId);
                infectedId = contactees[infectedId];
            } // 建立while迴圈，如果infectedID不在名單中，添加到名單中。當傳播回到已隔離的公民時，迴圈結束

            // 步驟7: 顯示隔離名單
            Console.WriteLine("\n這些公民接下來14天要自我隔離:");
            Console.WriteLine(string.Join(" ", isolationList));
        }

        // 洗牌算法，用於生成隨機的接觸者數據
        static List<int> Shuffle(List<int> list, Random rng)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
            return list;
        }
    }
}
