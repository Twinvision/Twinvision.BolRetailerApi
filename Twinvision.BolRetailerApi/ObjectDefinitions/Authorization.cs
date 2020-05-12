namespace Twinvision.BolRetailerApi
{
    public class Authorization
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expires_in { get; set; }
        public object Scope { get; set; }
    }
}