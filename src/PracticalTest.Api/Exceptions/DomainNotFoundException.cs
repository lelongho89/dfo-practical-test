using System;

namespace PracticalTestApi.Exceptions
{
    public class DomainNotFoundException : Exception
    {
        public DomainNotFoundException(string id, Type type)
            : base(FormatMessage(id, type))
        {
        }

        private static string FormatMessage(string id, Type type)
        {
            return $"Domain object \'{id}\' (type {type}) is not found.";
        }
    }
}
