using System;

namespace Lab_4_猜數字物件導向
{
    // 定義玩家行為的介面
    interface IPlayer
    {
        string Name { get; }
        int Guess();
    }

    // 實現人類玩家的類別
    class HumanPlayer : IPlayer
    {
        public string Name { get; private set; }

        public HumanPlayer(string name)
        {
            Name = name;
        }

        public int Guess()
        {
            while (true) // 確保玩家輸入有效數字
            {
                Console.Write($"{Name}，請猜你想要猜的數字（1~100）: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int guess) && guess >= 1 && guess <= 100)
                {
                    return guess; // 如果輸入正確，返回猜測值
                }
                Console.WriteLine("無效輸入，請輸入1到100之間的數字。");
            }
        }
    }

    // 負責管理遊戲邏輯的類別
    class Game
    {
        private int Target { get; set; }
        private IPlayer Player { get; set; }
        private int MaxAttempts { get; set; }

        public Game(IPlayer player, int maxAttempts = 5)
        {
            Player = player;
            MaxAttempts = maxAttempts;
        }

        public void Play()
        {
            // 生成隨機目標數字
            Random rng = new Random();
            Target = rng.Next(1, 101); // 目標數字在 1~100 之間
            Console.WriteLine("歡迎來到猜數字遊戲");
            Console.WriteLine($"你有 {MaxAttempts} 次機會來猜1~100之間的數字");

            // 遊戲流程
            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.WriteLine($"\n第 {attempt}/{MaxAttempts} 次猜測:");
                int guess = Player.Guess();

                if (guess == Target)
                {
                    Console.WriteLine($"恭喜，{Player.Name}！你猜對了！正確答案是 {Target}！");
                    return;
                }
                else if (guess < Target)
                {
                    Console.WriteLine("數字太低，再試一次！");
                }
                else
                {
                    Console.WriteLine("數字太高，再試一次！");
                }
            }

            Console.WriteLine($"\n抱歉，{Player.Name}。你已使用完 {MaxAttempts} 次機會。正確答案是 {Target}。");
        }
    }

    // 主程式執行入口
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入你的名字: ");
            string name = Console.ReadLine();

            IPlayer player = new HumanPlayer(name); // 使用人類玩家
            Game game = new Game(player); // 初始化遊戲
            game.Play(); // 啟動遊戲

            // 停止控制台關閉
            Console.WriteLine("\n按任意鍵退出...");
            Console.ReadKey();
        }
    }
}
