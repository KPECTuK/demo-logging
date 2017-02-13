namespace Assets.Scripts.LoggingExtensions.Appenders.Filters
{
	internal interface INetworkMethodFilter<TChank>
	{
		byte[] ConvertToBuffer(TChank source);
	}
}