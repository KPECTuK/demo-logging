using log4net.Appender;
using log4net.Core;

namespace Assets.Scripts.LoggingExtensions.Appenders
{
    public class UnityConsoleAppender : AppenderSkeleton
    {
        protected override bool RequiresLayout { get { return true; } }

        public override void ActivateOptions()
        {
            base.ActivateOptions();

            //Layout = new UnityEditorPatternLayout("<color=teal>%-5timestamp</color> <color=%shade><b>[%-5level]</b></color> <color=#88134a><i>%logger</i></color>:%newline %message");
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var rendered = RenderLoggingEvent(loggingEvent);
            if (Level.Error.CompareTo(loggingEvent.Level) <= 0)
            {
                UnityEngine.Debug.LogError(rendered);
                return;
            }

            if (Level.Warn.CompareTo(loggingEvent.Level) <= 0)
            {
                UnityEngine.Debug.LogWarning(rendered);
                return;
            }

            if (Level.Debug.CompareTo(loggingEvent.Level) <= 0)
            {
                UnityEngine.Debug.Log(rendered);
            }
        }
    }
}
