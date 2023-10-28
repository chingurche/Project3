using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

namespace Project3.Scripts.Core
{
    internal class Renderer
    {
        private List<Texture2D> texture = new List<Texture2D>();

        private Animator? animator;

        public List<Texture2D> Texture => texture;

        public Renderer()
        {

        }

        public Renderer(ContentManager content, string texture)
        {
            this.LoadTexture(content, texture);
        }

        public Renderer(ContentManager content, List<string> texture)
        {
            if (texture.Count < 2)
            {
                throw new ArgumentException("Try other Renderer initializer");
            }

            texture.ForEach(Texture2D => this.LoadTexture(content, Texture2D));
        }

        private void LoadTexture(ContentManager content, string name)
        {
            texture.Add(content.Load<Texture2D>(name));
        }
    }
}
