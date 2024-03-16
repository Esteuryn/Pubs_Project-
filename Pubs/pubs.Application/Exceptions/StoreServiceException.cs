using pubs.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Application.Exceptions
{
    public class StoreServiceException : Exception
    {
        public StoreServiceException()
        {
        }

        public void ValidateNullable(string? value, string? message, bool status)
        {
            if (string.IsNullOrEmpty(value)) 
            {
                throw new ArgumentNullException(message);
            }
        }

        public void ValidateLenght(string? message, string? value, int maxLenght, bool status) 
        {
            if(value.Length > maxLenght) 
            {
                throw new ArgumentException(message);
            }
        }
    }
}

