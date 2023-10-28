using System;
using System.Collections.Generic;

namespace Project3.Scripts.Core
{
    internal class Hierarchy
    {
        private static float unitInPixels;

        private List<GameObject> objects = new List<GameObject>();

        private static Hierarchy _instance;

        public float UnitInPixels => unitInPixels;

        public List<GameObject> Objects => objects;

        private Hierarchy() { }

        public static Hierarchy GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Hierarchy();
            }
            return _instance;
        }

        public void AddObject(GameObject gameObject)
        {
            objects.Add(gameObject);
        }

        public void SetUnitsInPixels(int pixels)
        {
            if (pixels < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            unitInPixels = pixels;
        }
    }
}
