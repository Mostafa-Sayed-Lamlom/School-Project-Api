using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Bases
{
	public class ResponseHandler
	{
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		public ResponseHandler(IStringLocalizer<SharResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
		}
		public Response<T> Deleted<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = Message == null ? _stringLocalizer[SharedResourcesKey.Deleted] : Message
			};
		}
		public Response<T> Success<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKey.Success],
				Meta = Meta
			};
		}
		public Response<T> Unauthorized<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = true,
				Message = Message == null ? _stringLocalizer[SharedResourcesKey.UnAuthorized] : Message
			};
		}
		public Response<T> BadRequest<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = Message == null ? _stringLocalizer[SharedResourcesKey.BadRequest] : Message
			};
		}

		public Response<T> UnprocessableEntity<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = Message == null ? _stringLocalizer[SharedResourcesKey.UnprocessableEntity] : Message
			};
		}

		public Response<T> NotFound<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? _stringLocalizer[SharedResourcesKey.NotFound] : message
			};
		}

		public Response<T> Created<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKey.Created],
				Meta = Meta
			};
		}
	}
}
