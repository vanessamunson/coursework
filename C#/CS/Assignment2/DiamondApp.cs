namespace CS.Assignment2;

public class DiamondApp
{

    public static void SumAverage()
    {
        double total = 0;

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter an integer ({i+1}/10): ");
            int inputNum = int.Parse(Console.ReadLine());
            total += inputNum;
        }

        Console.WriteLine($"The sum of your numbers is {total}");
        Console.WriteLine($"The average of your numbers is {Math.Round(total/10, 2)}");
    }

    #region Diamonds
        public static void VariantOne(int userNum)
        {
            string row = "";

            for(int i = 1; i <= userNum; i++)
            {
                // Add userNum - i blank spaces to front
                for(int front = 0; front < userNum - i; front++)
                {
                    row += " ";
                }

                // Insert numbers with spaces between
                for(int num = 1; num <= i; num++)
                {
                    row += "*";

                    if(num < i)
                    {
                        row += " ";
                    }
                }

                // Add userNum - i blank spaces to back
                for(int back = 0; back <= userNum - i; back++)
                {
                    row += " ";
                }

                Console.WriteLine(row);
                row = "";
            }
        }

        public static void VariantTwo(int userNum)
        {
            string row = "";

            for(int i = 1; i <= userNum; i++)
            {
                // Add userNum - i blank spaces to front
                for(int front = 0; front < userNum - i; front++)
                {
                    row += " ";
                }

                // Insert numbers with spaces between
                for(int num = 1; num <= i; num++)
                {
                    row += num;

                    if(num < i)
                    {
                        row += " ";
                    }
                }

                // Add userNum - i blank spaces to back
                for(int back = 0; back <= userNum - i; back++)
                {
                    row += " ";
                }

                Console.WriteLine(row);
                row = "";
            }
        }

        public static void VariantThree(int userNum)
    {
        string row = "";
        int currentNum = 1;

        for(int i = 1; i <= userNum; i++)
        {
            // Add userNum - i blank spaces to front
            for(int front = 0; front < userNum - i; front++)
            {
                row += " ";
            }

            // Insert numbers with spaces between
            for(int j = 1; j <= i; j++)
            {
                row += currentNum;
                currentNum += 1;

                if(j < i)
                {
                    row += " ";
                }

            }

            // Add userNum - i blank spaces to back
            for(int back = 0; back <= userNum - i; back++)
            {
                row += " ";
            }

            Console.WriteLine(row);
            row = "";
        }
    }
    #endregion
}