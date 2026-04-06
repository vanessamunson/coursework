namespace CS.Assignment1;

public class SwapperChecker
{
    public static int[] Swap(int[] argArr)
    {
        int[] returnArray = [argArr[1], argArr[0]];
        return returnArray;
    }

    public static bool Opposites(int a, int b)
    {
        if ((a < 0 && b >= 0) || (a >= 0 && b < 0))
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public static bool Equals(int a, int b)
    {
        if (a == b)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

