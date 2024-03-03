
namespace pubs.Infrastructure.Exceptions
{
    public class CountriesException : Exception
    {
        public CountriesException(string message) : base(message)
        {
            SaveLog(message);
        }
        void SaveLog(string message)
        {
            //Logica de guardar exception//
        }
    }
}