using System.Text;

namespace Assets.Scripts.LoggingExtensions.Appenders.Filters
{
	internal class DefaultTitleFilter : INetworkMethodFilter<string>
	{
		public byte[] ConvertToBuffer(string source)
		{
			return Encoding.UTF8.GetBytes(source);
		}
	}
}