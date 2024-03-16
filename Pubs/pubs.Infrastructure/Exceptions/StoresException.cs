
namespace pubs.Infrastructure.Exceptions
{
    public class StoresException :  Exception
    {
        public StoresException(string message) : base(message)
        {
            SaveLog(message);   
        }

        public void SaveLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
