
namespace pubs.Infrastructure.Exceptions
{
    public class StoresException :  Exception
    {
        public StoresException(string message) : base(message)
        {
            SaveLog(message);   
        }
        void SaveLog(string message)
        {
            //Logica de guardar exception//
        }
    }
}
