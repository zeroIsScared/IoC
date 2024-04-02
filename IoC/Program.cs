using BusinessLayer;

internal class Program
{
    private static void Main(string[] args)
    {
        Session session1 = new Session("New one", "I have a new session");
        Speaker speaker1 = new Speaker(" ", "Tau", "atau@hotmail.com", 3, "Google", new WebBrowser("CH", 10));
    }
}