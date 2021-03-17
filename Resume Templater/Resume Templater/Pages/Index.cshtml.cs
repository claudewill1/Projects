// Index.cshtml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ResumeTemplater.Pages
{
	public class IndexModel : PageModel
	{
		public string FullName { get; set; }
		public string LinkedInUsername { get; set; }
		public string GithubUsername { get; set; }
		public int YearsOfExperience { get; set; }
		public List<string> Languages { get; set; }
		public void OnGet()
		{
			FullName = "Claude Will";
			LinkedInUsername = "claudewill";
			GithubUsername = "claudewill1";
			YearsOfExperience = 3;
			Languages = new List<string> {
				"C++",
		"C#",
				"Javascript",
				"Java",
				"Python",
		"Visual Basic",
			};
		}
	}
}
