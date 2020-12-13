namespace FigureStorage.API.Models
{
    public class BadRequestMsgResponse
    {
        public BadRequestMsgResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}