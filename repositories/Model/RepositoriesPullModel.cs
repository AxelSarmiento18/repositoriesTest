using System;
using System.Collections.Generic;

namespace repositories.Model
{
	public class RepositoriesPullModel
	{
		
			
			public int Id { get; set; }
	    	public string Html_url { get; set; }
		    public string Title { get; set; }
	    	public DateTime Created_at { get; set; }
	    	public string Avatar_url { get; set; }
		    public IList<Users> User { get; set; }    

		public class Users{
			public string Login { get; set; }
		}
	

	}



	}

