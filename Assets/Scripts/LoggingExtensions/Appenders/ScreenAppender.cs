using log4net.Appender;
using log4net.Core;
using UnityEngine;

namespace Assets.Scripts.LoggingExtensions.Appenders
{
    public class ScreenAppender : AppenderSkeleton
    {
        private LoggerRenderer _renderer;

        protected override bool RequiresLayout { get { return true; } }

        public override void ActivateOptions()
        {
            base.ActivateOptions();

            _renderer = Object.FindObjectOfType<LoggerRenderer>();
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if(_renderer == null)
                return;

            _renderer.Add(RenderLoggingEvent(loggingEvent));
        }
    }
}
