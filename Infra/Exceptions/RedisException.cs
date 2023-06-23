namespace Infra.Exceptions
{
    public class RedisException : Exception
    {
        public RedisException(string message) : base(message)
        {
        }
    }
}
