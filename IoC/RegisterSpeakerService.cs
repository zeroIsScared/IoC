using BusinessLayer.Exceptions;

namespace BusinessLayer
{
    public class RegisterSpeakerService : IRegisterSpeakerService
    {
        private List<string> _domains = new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
        private List<string> _domainOfExpertise = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
        private List<string> _employers = new List<string>() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };        

        public int? Register(Speaker speaker, IRepository repository)
        {
            ValidateSpeakerDetails(speaker);

            var approved = ApproveSpeaker(speaker);

            if (!approved)
            {
                throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our arbitrary and capricious standards.");
            }

            if (speaker.Sessions.Count == 0)
            {
                throw new ArgumentException("Can't register speaker with no sessions to present.");
            }

            var sessionApproved = ApproveSession(speaker);

            if (!sessionApproved)
            {
                throw new NoSessionsApprovedException("No sessions approved.");
            }

            int? speakerId = null;

            try
            {
                speakerId = repository.SaveSpeaker(speaker);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't connect to database, an exception accured: {ex}");
            }

            return speakerId;
        }
        private bool ApproveSpeaker(Speaker speaker)
        {
            var approved = speaker.Experience > 10 || speaker.HasBlog || speaker.Certifications.Count() > 3 || _employers.Contains(speaker.Employer);

            if (!approved)
            {
                string emailDomain = speaker.Email.Split('@').Last();

                approved = !_domains.Contains(emailDomain) && (!(speaker.Browser.Name == WebBrowser.BrowserName.InternetExplorer && speaker.Browser.MajorVersion < 9));
            }

            return approved;
        }

        private bool ApproveSession(Speaker speaker)
        {
            var approved = false;
            foreach (var session in speaker.Sessions)
            {
                var expertiseIsPresent = _domainOfExpertise.Any(tech => session.Title.Contains(tech) || session.Description.Contains(tech));
                session.Approved = expertiseIsPresent;
                approved = session.Approved;
            }
            return approved;
        }
        
        private void ValidateSpeakerDetails(Speaker speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker.FirstName))
            {
                throw new ArgumentNullException(nameof(speaker.FirstName), "First Name is required");
            }

            if (string.IsNullOrWhiteSpace(speaker.LastName))
            {
                throw new ArgumentNullException(nameof(speaker.LastName), "Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(speaker.Email))
            {
                throw new ArgumentNullException(nameof(speaker.Email), "Email is required.");
            }
        }
    }
}
