using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Mission09_BookStore.Infrastructure
{
	public static class SessionExtensions
	{

		// This is for the session that allows it to work by getting the session id and allowing the user to navigate pages while maintaing it
		public static void SetJSON( this ISession session, string key, object value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}

		public static T GetJson<T> (this ISession session, string key)
		{
			var sessionData = session.GetString(key);

			return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
		}
	}
}

