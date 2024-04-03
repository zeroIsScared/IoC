namespace BusinessLayer
{
    public class Speaker
	{
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int? Experience { get; set; }
		public bool HasBlog { get; set; }
		public string BlogURL { get; set; } = default!;
		public WebBrowser Browser { get; set; }
		public List<string> Certifications { get; set; } = default!;
		public string Employer { get; set; }
		public List<Session> Sessions { get; set; } = default!;
		public bool IsApprovedForRegistration { get; set; }
         

	    public Speaker(string firstName, string lastName, string email, int experience, WebBrowser webBrowser)
	    {
		    FirstName = firstName;
		    LastName = lastName;
		    Email = email;
		    Experience = experience;
			Sessions = new List<Session>();
			Certifications = new List<string>();
	    }
	    public int RegistrationFee => Experience switch
	    {
	    	<= 1 => 500,
	    	<= 3 => 250,
	    	<= 5 => 100,
	    	<= 9 => 50,
	    	_ => 0
	    };
    }    
}