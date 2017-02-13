using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LoggerRenderer : MonoBehaviour
    {
        private const int MAX_MESSAGES_I = 30;

        [SerializeField] private Text text;

        private readonly Queue<string> _strings = new Queue<string>();

        public void Add(string message)
        {
            if(text == null)
                return;
            
            _strings.Enqueue(message);
            if(_strings.Count > MAX_MESSAGES_I)
                _strings.Dequeue();
            var builder = new StringBuilder();
            foreach(var item in _strings)
                builder.AppendLine(item);
            text.text = builder.ToString();
        }
    }
}
