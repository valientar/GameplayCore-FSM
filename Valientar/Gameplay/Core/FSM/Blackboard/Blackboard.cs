using System;
using System.Collections.Generic;

namespace Valientar.Gameplay.Core.FSM
{
    public sealed partial class Blackboard
    {
        public event Action<Type, string, object> OnDataChanged;
        private readonly Dictionary<Key, object> _data;


        public Blackboard() => _data = new Dictionary<Key, object>();


        public void AddOrSet<T>(T value, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            var key = new Key(typeof(T), name);
            _data[key] = value;

            OnDataChanged?.Invoke(typeof(T), name, value);
        }

        public void Remove<T>(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            var key = new Key(typeof(T), name);

            if (_data.Remove(key))
                OnDataChanged?.Invoke(typeof(T), name, null);
        }

        public T Get<T>(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            var key = new Key(typeof(T), name);

            if (_data.TryGetValue(key, out var value) && value is T typedValue)
                return typedValue;

            return default;
        }
    }
}