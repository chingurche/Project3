using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;
using System;

namespace Project3.Scripts.Core
{
    internal class GameObject
    {
        private Transform transform;
        private Renderer renderer;

        public Transform Transform => transform;
        public Renderer Renderer => renderer;

        public GameObject()
        {
            transform = new Transform();
        }

        public void BuildTransform(Transform transform)
        {
            this.transform = transform;
        }

        public void BuildRenderer(Renderer renderer)
        {
            this.renderer = renderer;
        }

        public Vector2 GetScaleInPixels()
        {
            return transform.Scale * new Vector2(renderer.Texture[0].Width, renderer.Texture[0].Height);
        }
    }
}
