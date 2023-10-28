using Microsoft.Xna.Framework;
using System.Runtime.ConstrainedExecution;

namespace Project3.Scripts.Core
{
    internal class Transform
    {
        private Vector2 position = Vector2.Zero;
        private Vector2 scale = Vector2.One;
        private double rotation;

        public Vector2 Position => position;
        public Vector2 Scale => scale;

        public Transform() { }
        public Transform(Vector2 position)
        {
            this.position = position;
        }
        public Transform(Vector2 position, float scale)
        {
            this.position = position;
            this.scale = new Vector2(scale);
        }
        public Transform(Vector2 position, float scaleX, float scaleY)
        {
            this.position = position;
            this.scale = new Vector2(scaleX, scaleY);
        }

        public Vector2 GetPositionInPixels()
        {
            var hierarchy = Hierarchy.GetInstance();
            return Vector2.Multiply(position, hierarchy.UnitInPixels);
        }

        public static Vector2 GetPositionInUnits(Vector2 position)
        {
            var hierarchy = Hierarchy.GetInstance();
            return Vector2.Divide(position, hierarchy.UnitInPixels);
        }

        public void MovePosition(float positionX, float positionY)
        {
            this.position += new Vector2(positionX, positionY);
        }
        public void MovePosition(Vector2 position)
        {
            this.position += position;
        }
        public void SetPosition(float positionX, float positionY)
        {
            this.position = new Vector2(positionX, positionY);
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
    }
}
