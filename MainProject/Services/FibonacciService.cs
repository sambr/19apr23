using MainProject.Interfaces;

namespace MainProject.Services;

public class FibonacciService : IFibonacciService
{
    public FibonacciService()
    {

    }

    public int FibonacciNumberAtPosition(int position)
    {
        int fiboNumber = 0;
        if (position < 1)
        {
            return 0;
        }
        if (position < 3)
        {
            return position - 1;
        }

        int first = 0, second = 1;
        for (int i = 3; i <= position + 1; i++)
        {
            fiboNumber = first + second;
            first = second;
            second = fiboNumber;
        }

        return fiboNumber;
    }
}