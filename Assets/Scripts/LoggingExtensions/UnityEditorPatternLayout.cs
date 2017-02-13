using log4net.Layout;
using log4net.Util;

namespace Assets.Scripts.LoggingExtensions
{
    public class UnityEditorPatternLayout : PatternLayout
    {
        public UnityEditorPatternLayout() { }

        public UnityEditorPatternLayout(string pattern) : base(pattern) { }

        public override void ActivateOptions()
        {
            base.ActivateOptions();

            AddConverter(new ConverterInfo { Name = "shade", Type = typeof(ColorPatternConverter) });
        }
    }
}