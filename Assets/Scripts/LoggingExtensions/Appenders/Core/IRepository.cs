using System.Collections.Generic;

namespace Assets.Scripts.LoggingExtensions.Appenders.Core
{
	internal interface IRepository<TChank> : IEnumerable<TChank>
	{
		void Enqueue(TChank buffer);
	}
}
