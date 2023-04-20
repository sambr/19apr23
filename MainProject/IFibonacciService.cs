using DataModel.Models;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces;

public interface IFibonacciService
{
    int FibonacciNumberAtPosition(int position);
}