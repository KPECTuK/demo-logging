using System.Collections;
using log4net.Core;
using UnityEngine;

namespace Assets.Scripts
{
    public class Activity : MonoBehaviour
    {
        private Level[] _levels;
        private int _index;

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            _levels = new[]
            {
                Level.Warn,
                Level.Debug,
                Level.Alert,
                Level.All,
                Level.Critical,
                Level.Emergency,
                Level.Error,
                Level.Fatal,
                Level.Verbose,
                Level.Fine,
                Level.Finer,
                Level.Finest,
                Level.Notice,
                Level.Info,
                Level.Trace,
                Level.Severe,
            };
            StartCoroutine(Emit());
        }

        private IEnumerator Emit()
        {
            while(gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(1f);
                Debug.Log(this, _levels[_index], "emit");
                _index = ++_index < _levels.Length ? _index : 0;
            }
        }
    }
}
