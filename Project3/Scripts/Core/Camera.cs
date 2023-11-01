using Microsoft.Xna.Framework;

namespace Project3.Scripts.Core
{
    internal class Camera
    {
        private static Transform transform;

        public static Transform Transform => transform;

        private static Camera instance;

        private Camera() { }

        public static Camera GetInstance()
        { 
            if (instance == null)
            {
                instance = new Camera();
            }
            return instance;
        }

        public static Camera GetInstance(Transform newTransform)
        {
            if (instance == null)
            {
                transform = newTransform;
                instance = new Camera();
            }
            return instance;
        }

        public Vector2 GetRelativePosition(Vector2 position)
        {
            return position - transform.Position;
        }
    }
}
