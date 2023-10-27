using System;
namespace orderApi.Interfaces
{
	public interface IServiceCallHelper
	{


		Task<string> Post(string uri, HttpMethod httpMethod, string content)
		;
		Task<string> GetAsync(string uri);
		
	}
}

