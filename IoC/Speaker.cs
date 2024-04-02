using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using BusinessLayer.Exceptions;

namespace BusinessLayer
{
	public class Speaker
	{
		private string _firstName {  get; set; }     
		private string _lastName {  get; set; }
		private string _email { get; set; }
		public int? Experience { get; set; }
		public bool HasBlog { get; set; }
		public string BlogURL { get; set; }
		public WebBrowser Browser { get; set; }
		public List<string> Certifications { get; set; }
		public string Employer { get; set; }		
		public List<Session> Sessions { get; set; }
        public bool IsApprovedForRegistration { get; set; }
        public int RegistrationFee { get; set; }
/*
        public string FirstName
		{
			get { return _firstName; }
			set
			{
				if (string.IsNullOrWhiteSpace(_firstName))
				{
					throw new ArgumentNullException("First name is required!");
				}
				_firstName = value;
			}
		}

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(_lastName))
                {
                    throw new ArgumentNullException(" is required!");
                }
                _lastName = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(_email))
                {
                    throw new ArgumentNullException(" is required!");
                }
                _email = value;
            }
        }*/

        public Speaker(string firstName, string lastName, string email, int experience, string employer, WebBrowser webBrowser)
		{
			_firstName = firstName;
			_lastName = lastName;
			_email= email;
			Experience = experience;			
			Employer = employer;
			IsApprovedForRegistration = false;
			Browser = webBrowser;
			HasBlog = false;
		}		
	}
}