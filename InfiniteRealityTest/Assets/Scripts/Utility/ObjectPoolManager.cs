using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest.Utility
{
    /// <summary>
    /// This is the source of the game's object pools to reduce memory usage.
    /// Probably should have used stacks instead of generic lists.
    /// </summary>
    public sealed class ObjectPoolManager
    {
        private Dictionary<string, GameObject> _objectBaseDictionary;
        private Dictionary<string, IList<GameObject>> _objectPoolAvailableDictionary;
        private Dictionary<string, IList<GameObject>> _objectPoolInUseDictionary;

        public ObjectPoolManager()
        {
            _objectBaseDictionary = new Dictionary<string, GameObject>();
            _objectPoolAvailableDictionary = new Dictionary<string, IList<GameObject>>();
            _objectPoolInUseDictionary = new Dictionary<string, IList<GameObject>>();
        }

        /// <summary>
        /// Adds an object that can be replicated with its own object pool.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void AddObject(string key, GameObject obj)
        {
            if (!_objectBaseDictionary.ContainsKey(key))
            {
                _objectBaseDictionary.Add(key, obj);
                _objectPoolAvailableDictionary.Add(key, new List<GameObject>());
                _objectPoolInUseDictionary.Add(key, new List<GameObject>());
            }
        }

        /// <summary>
        /// Gets an object if an available one is within the pool already.
        /// Creates a new object is there is not.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public GameObject GetObject(string key)
        {
            if (!_objectBaseDictionary.ContainsKey(key))
            {
                return null;
            }

            IList<GameObject> objectAvailableList = _objectPoolAvailableDictionary[key];
            
            if (objectAvailableList.Count == 0)
            {
                GameObject newObject = GameObject.Instantiate(_objectBaseDictionary[key]);
                _objectPoolInUseDictionary[key].Add(newObject);
                newObject.SetActive(true);
                return newObject;
            }
            else
            {
                GameObject oldObject = objectAvailableList[0];
                objectAvailableList.Remove(oldObject);
                _objectPoolInUseDictionary[key].Add(oldObject);
                oldObject.SetActive(true);
                return oldObject;
            }
        }

        /// <summary>
        /// Returns an object back to the object pool. This assumes that the object
        /// being returned is one created from the pool.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="gm"></param>
        public void ReturnObject(string key, GameObject gm)
        {
            if (!_objectBaseDictionary.ContainsKey(key))
            {
                return;
            }

            if (_objectPoolInUseDictionary[key].Contains(gm))
            {
                _objectPoolAvailableDictionary[key].Add(gm);
                _objectPoolInUseDictionary[key].Remove(gm);

                gm.SetActive(false);
            }
        }

        /// <summary>
        /// Return all of the objects of a specific key and sets them ready to use.
        /// </summary>
        /// <param name="key"></param>
        public void ReturnAll(string key)
        {
            if (!_objectBaseDictionary.ContainsKey(key))
            {
                return;
            }

            IList<GameObject> objects = _objectPoolInUseDictionary[key];
            int objCount = objects.Count;

            for (int i = 0; i < objCount; ++i)
            {
                _objectPoolAvailableDictionary[key].Add(objects[0]);
                objects[0].SetActive(false);
                _objectPoolInUseDictionary[key].RemoveAt(0);
            }
        }
    }
}
