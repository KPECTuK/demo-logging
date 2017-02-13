using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.LoggingExtensions.Appenders.Core;
using Assets.Scripts.LoggingExtensions.Appenders.Filters;
using Assets.Scripts.LoggingExtensions.Appenders.Methods;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace Assets.Scripts.LoggingExtensions.Appenders
{
	public class NetworkAppender : AppenderSkeleton
	{
		private static readonly Type _declaringType = typeof(NetworkAppender);

		private IRepository<string> _repository;
		private INetworkMethod _method;

		// ReSharper disable MemberCanBePrivate.Global
		public string ConnectionString { get; set; }
		public Type FilterType { get; set; }
		public Type MethodType { get; set; }
		// ReSharper restore MemberCanBePrivate.Global

		protected override bool RequiresLayout { get { return true; } }

		public override void ActivateOptions()
		{
			base.ActivateOptions();
			_repository = new MessageHeap<string>();
			try
			{
				var constructor =
					MethodType
						.GetConstructor(
							BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
							null,
							new[] {typeof(string), typeof(IEnumerator<string>), typeof(INetworkMethodFilter<string>)},
							null);
				_method =
					constructor
						.Invoke(
							new object[]
							{
								ConnectionString,
								_repository.GetEnumerator(),
								Activator.CreateInstance(FilterType) as INetworkMethodFilter<string> ?? new DefaultTitleFilter()
							}) as INetworkMethod;
			}
			catch(Exception exception)
			{
				LogLog.Error(_declaringType, string.Format("fall to initialize NetworkAppender: {0}", exception.GetType().Name));
			}
		}

		protected override void Append(LoggingEvent loggingEvent)
		{
			_repository.Enqueue(RenderLoggingEvent(loggingEvent));
			_method.Commit();
		}

		protected override void OnClose()
		{
            if(_method != null)
			    _method.Dispose();
			base.OnClose();
		}
	}
}
