namespace Infra.Mediator.Classes
{
    public class ResponseDto
    {
        public bool Sucess { get; set; } = true;
        public object? Data { get; set; }

        public ResponseDto(bool success = true)
        {
            Data = null;
            Sucess = success;
        }

        public ResponseDto(object data, bool success = true)
        {
            Data = data;
            Sucess = success;
        }
    }
}
