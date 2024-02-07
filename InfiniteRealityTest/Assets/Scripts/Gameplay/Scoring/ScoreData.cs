using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Gameplay.Scoring
{
    /// <summary>
    /// ScoreData is data that determines how the score may change
    /// through a ScoreModifier pipeline. It acts like a JSON in a sense.
    /// </summary>
    public sealed class ScoreData
    {
        private Dictionary<string, int> _intDictionary;
        private Dictionary<string, float> _floatDictionary;
        private Dictionary<string, string> _stringDictionary;

        public ScoreData()
        {
            _intDictionary = new Dictionary<string, int>();
            _floatDictionary = new Dictionary<string, float>();
            _stringDictionary = new Dictionary<string, string>();
        }

        public void SetData(string key, int value)
        {
            if (_intDictionary.ContainsKey(key))
            {
                _intDictionary[key] = value;
            }
            else
            {
                _intDictionary.Add(key, value);
            }
        }

        public void SetData(string key, float value)
        {
            if (_floatDictionary.ContainsKey(key))
            {
                _floatDictionary[key] = value;
            }
            else
            {
                _floatDictionary.Add(key, value);
            }
        }

        public void SetData(string key, string value)
        {
            if (_stringDictionary.ContainsKey(key))
            {
                _stringDictionary[key] = value;
            }
            else
            {
                _stringDictionary.Add(key, value);
            }
        }

        public bool GetData(string key, out int value)
        {
            if ( _intDictionary.ContainsKey(key))
            {
                value = _intDictionary[key];
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool GetData(string key, out float value)
        {
            if (_floatDictionary.ContainsKey(key))
            {
                value = _floatDictionary[key];
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool GetData(string key, out string value)
        {
            if (_stringDictionary.ContainsKey(key))
            {
                value = _stringDictionary[key];
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
    }
}
