using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                new FancyRepository().GetCatchErrorGreaterThanZero(Console.ReadLine());
            }
        }
    }

    public class FancyRepository
    {
        public string GetCatchErrorGreaterThanZero(string value)
        {
            try
            {
                return GetInternal(value);
            }
            catch (FancyException fe) when (LogToDatabase(fe.ErrorCode) | fe.ErrorCode > 0)
            {
                throw fe;
            }
        }

        private string GetInternal(string value)
        {
            if (!value.Any())
                throw new FancyException(0);

            throw new FancyException(1);

        }

        private bool LogToDatabase(int errorCode)
        {
            Console.WriteLine($"Exception with code {errorCode} has been logged");
            return false;
        }      
    }


    public class FancyException : Exception
    {
        public int ErrorCode { get; set; }
        
        public FancyException(int errorCode) : base()
        {
            ErrorCode = errorCode;
        }
    }

}
