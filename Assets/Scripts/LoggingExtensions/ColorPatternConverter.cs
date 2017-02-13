using System.IO;
using System.Linq;
using log4net.Core;
using log4net.Layout.Pattern;

namespace Assets.Scripts.LoggingExtensions
{
    internal sealed class ColorPatternConverter : PatternLayoutConverter
    {
        private static readonly ILookup<Level, string> _colorList;

        static ColorPatternConverter()
        {
            var map = new LevelMap();
            map.AddBuiltInLevels();
            _colorList = map
                .AllLevels
                .Cast<Level>()
                .ToList()
                .ToLookup(level => level, level =>
                {
                    if(Level.All.CompareTo(level) >= 0)
                        return "#b4b4b4ff";
                    if(Level.Finest.CompareTo(level) >= 0)
                        return "#b4b4b4ff";
                    if(Level.Verbose.CompareTo(level) >= 0)
                        return "#b4b4b4ff";
                    if(Level.Finer.CompareTo(level) >= 0)
                        return "#a0a0a0ff";
                    if(Level.Trace.CompareTo(level) >= 0)
                        return "#a0a0a0ff";
                    if(Level.Fine.CompareTo(level) >= 0)
                        return "#828282ff";
                    if(Level.Debug.CompareTo(level) >= 0)
                        return "#828282ff";
                    if(Level.Info.CompareTo(level) >= 0)
                        return "#ffffffff";
                    if(Level.Notice.CompareTo(level) >= 0)
                        return "#397b39ff";
                    if(Level.Warn.CompareTo(level) >= 0)
                        return "#ff8000ff";
                    if(Level.Error.CompareTo(level) >= 0)
                        return "#ff0000ff";
                    if(Level.Severe.CompareTo(level) >= 0)
                        return "#e3021fff";
                    if(Level.Critical.CompareTo(level) >= 0)
                        return "#ab0e40ff";
                    if(Level.Alert.CompareTo(level) >= 0)
                        return "#ff00ffff";
                    if(Level.Fatal.CompareTo(level) >= 0)
                        return "#8b2899ff";
                    if(Level.Emergency.CompareTo(level) >= 0)
                        return "#76237dff";
                    if(Level.Off.CompareTo(level) >= 0)
                        return "#76237dff";
                    return "#000000ff";
                });
        }

        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            writer.Write(_colorList[loggingEvent.Level].First());
        }
    }
}
