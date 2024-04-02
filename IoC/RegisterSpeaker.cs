using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RegisterSpeaker : IRegisterSpeaker
    {        
        public List<string> domains = new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
        public List<string> domainOfExpertise = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
        public List<string>  employersList =  new List<string>() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
        int? speakerId = null;

        public void ApproveRegistration(Speaker speaker)
        {
            string emailDomain = speaker.Email.Split('@').Last();

            if ((speaker.Experience > 10 || speaker.HasBlog || speaker.Certifications.Count() > 3 || employersList.Contains(speaker.Employer)))
            {
                if (!domains.Contains(emailDomain) && (!(speaker.Browser.Name == WebBrowser.BrowserName.InternetExplorer && speaker.Browser.MajorVersion < 9)))
                {
                    speaker.IsApprovedForRegistration = true;
                }
            }
            else
            {
                speaker.IsApprovedForRegistration = false;
                throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
            }
  

            if (speaker.Sessions.Count() != 0)
            {
                foreach (var session in speaker.Sessions)
                {                  

                    foreach (var tech in domainOfExpertise)
                    {
                        if (!(session.Title.Contains(tech) || session.Description.Contains(tech)))
                        {
                            session.Approved = true;
                            speaker.IsApprovedForRegistration = true;
                        }
                        else
                        {
                            speaker.IsApprovedForRegistration = false;
                            throw new NoSessionsApprovedException("No sessions approved.");
                        }
                    }
                }
            }
        }            
    

        public void CalculateRegistrationFee(Speaker speaker)
        {
            var experence = speaker.Experience;

            if (experence <= 1)
            {
                speaker.RegistrationFee = 500;
            }
            else if (experence >= 2 && experence <= 3)
            {
                speaker.RegistrationFee = 250;
            }
            else if (experence >= 4 && experence <= 5)
            {
                speaker.RegistrationFee = 100;
            }
            else if (experence >= 6 && experence <= 9)
            {
                speaker.RegistrationFee = 50;
            }
            else
            {
                speaker.RegistrationFee = 0;
            }            
        }
        public int? Register(Speaker speaker, IRepository repository)
        {  
            try
            {
                speakerId = repository.SaveSpeaker(speaker);
            }
            catch (Exception ex)
            {
                //in case the db call fails 
            }
             return speakerId;           
        }        
    }
}
