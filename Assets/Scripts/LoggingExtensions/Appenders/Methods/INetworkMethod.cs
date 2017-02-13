using System;

namespace Assets.Scripts.LoggingExtensions.Appenders.Methods
{
	internal interface INetworkMethod : IDisposable
	{
		void Commit();
	}
}