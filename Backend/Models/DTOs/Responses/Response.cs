namespace BlogOnline.Models.DTOs.Responses
{
    public class Response
    {
        public string? Status { get; set; }
        public string? Meassage { get; set; }

        public Response(string? status, string? meassage)
        {
            Status = status;
            Meassage = meassage;
        }
    }
}
