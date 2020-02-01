﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models
{
	public class UserRegistrationModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Surname { get; set; }
		[Required]
		public string PhoneNumber { get; set; }

	}
}