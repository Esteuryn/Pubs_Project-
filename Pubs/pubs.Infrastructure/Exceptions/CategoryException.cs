
namespace pubs.Infrastructure.Exceptions
{
    public class CategoryException :  Exception
    {
        public CategoryException(string message) : base(message)
        {
            SaveLog(message);   
        }
        void SaveLog(string message)
        {
            //Logica de guardar exception//
        }
    }
}
