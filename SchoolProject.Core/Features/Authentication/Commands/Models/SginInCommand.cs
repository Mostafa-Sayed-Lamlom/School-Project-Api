﻿using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
	public class SginInCommand : IRequest<Response<string>>
	{
		//public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
