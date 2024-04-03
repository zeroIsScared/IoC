using BusinessLayer;

internal class Program
{
    private static void Main(string[] args)
    {
        Session session1 = new Session("New one", "I have a new session Cobol");
        Speaker speaker1 = new Speaker("Ana", "Tau", "atau@hotmail.com", 3, new WebBrowser("CH", 10));
        speaker1.Sessions.Add(session1);
        Console.WriteLine(speaker1.Sessions.Count);
        RegisterSpeakerService  registrationsService = new RegisterSpeakerService();
    }
}