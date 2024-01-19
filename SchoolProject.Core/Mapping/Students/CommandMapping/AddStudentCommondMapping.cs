using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void AddStudentCommondMapping()
		{
			CreateMap<AddStudentCommand, Student>()
			   .ForMember(dest => dest.DId, opt => opt.MapFrom(src => src.DepartmementId));
		}
	}
}
