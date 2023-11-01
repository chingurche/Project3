using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project3.Scripts.Core
{
    internal sealed class GameObject
    {
        private Transform transform;
        private Renderer renderer;
        private List<Component> components;

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

        public void TryGetComponent(Type type, out Component component)
        {
            component = components.Find(Component => Component.GetType() == type);
        }

        public Vector2 GetScaleInPixels()
        {
            return transform.Scale * renderer.TextureSize;
        }
    }
}
