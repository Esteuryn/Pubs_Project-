

namespace pubs.Infrastructure.Exceptions
{
    public class JobsException : Exception
    {
        public JobsException(string message) : base(message)
        {
            SaveLog(message);
        }
        void SaveLog(string message)
        {
            //Logica de guardar exception//
        }
    }
}