using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace repositories.Model
{
	public class RepositoriesPullModel
	{


		public int Id { get; set; }
		public string Html_url { get; set; }
		public string Title { get; set; }
		public DateTime Created_at { get; set; }
		public string Avatar_url { get; set; }
		public string Body { get; set; }
		public Userx User { get; set; }
		public string State { get; set; }
		public int RepOpen { get; set; }
		public int RepClosed { get; set; }

		public class Userx
        {
			
            public string Login { get; set; }


            public int Id { get; set; }


            public string Avatar_Url { get; set; }
         
        }
        
	}




}

