using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Moq;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.XUnitTest.Wrappers.Interfaces;

namespace SchoolProject.XUnitTest.ServicesTest
{
	public class ExtentionMethodTest
	{
		private readonly Mock<IPaginatedService<Student>> _paginatedServiceMock;
		public ExtentionMethodTest()
		{
			_paginatedServiceMock = new();
		}
		[Theory]
		[InlineData(1, 10)]
		public async Task ToPaginatedListAsync_Should_Return_List(int pageNumber, int pageSize)
		{
			//Arrange

			var department = new Department() { Id = 1, NameAr = "هندسة البرمجيات", Name = "SE" };

			var studentList = new AsyncEnumerable<Student>(new List<Student>
			{
				new Student(){ Id=1, Address="Alex", DId=1, NameAr="محمد",Name="mohamed",Department=department}
			});
			var paginatedResult = new PaginatedResult<Student>(studentList.ToList());
			_paginatedServiceMock.Setup(x => x.ReturnPaginatedResult(studentList, pageNumber, pageSize)).Returns(Task.FromResult(paginatedResult));
			//Act
			var result = await _paginatedServiceMock.Object.ReturnPaginatedResult(studentList, pageNumber, pageSize);
			//Assert
			result.Data.Should().NotBeNullOrEmpty();
		}
	}
}

