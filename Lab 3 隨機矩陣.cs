namespace Lab_3_隨機矩陣
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 步驟一:輸入矩陣的行數與列數
            Console.Write("輸入矩陣行數: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("輸入矩陣列數: ");
            int cols = int.Parse(Console.ReadLine());

            // 步驟二:宣告矩陣
            int[,] matrix = new int[rows, cols]; // 宣告一個二維陣列matrix，大小為rows x cols
            Random random = new Random();

            // 步驟三:填充矩陣隨機值 (0-99)
            Console.WriteLine("\n隨機數字矩陣:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(100); // 生成隨機數字0~99並填入矩陣
                    Console.Write(matrix[i, j].ToString().PadLeft(4)); // PadLeft(4)使輸出對齊（每個數字占 4 格）
                }
                Console.WriteLine();
            }

            // 步驟四:根據第一列的值對矩陣的行進行排序
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (matrix[i, 0] > matrix[j, 0])
                    {
                        // 交換兩行
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[i, k];
                            matrix[i, k] = matrix[j, k];
                            matrix[j, k] = temp;
                        }
                    }
                }
            }

            // 步驟五:排序後的矩陣
            Console.WriteLine("\n排序後的矩陣:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}
