using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project3.Scripts.Core;
using Project3.Scripts.Objects.Apophises;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;

namespace Project3
{
    public class Game1 : Game
    {
        private Hierarchy hierarchy;
        private Camera camera;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1920,
                PreferredBackBufferHeight = 1080
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            hierarchy = Hierarchy.GetInstance();
            hierarchy.SetUnitsInPixels(100);
            camera = Camera.GetInstance(new Transform(new Vector2(10, 10)));
            /*var objects = JsonPacker.DeserializeJson<List<GameObject>>(@"C:\Users\USER\source\repos\Project3\Project3\Data\Hierarchy.json");
            foreach (GameObject obj in objects)
            {
                hierarchy.AddObject(obj);
                var length = hierarchy.objects.Count;
                hierarchy.objects[length - 1].renderer.LoadContent();
            
            var data = new ApophisData("Ilya loh", 56, 78, 911);
            JsonPacker.SerializeJson<ApophisData>(data, @"C:\Users\USER\source\repos\Project3\Project3\Data\Test.Json");*/
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mouse = Mouse.GetState();
            var keyboard = Keyboard.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                var obj = new GameObject();
                obj.BuildTransform(new Transform(Transform.GetPositionInUnits(new Vector2(mouse.X, mouse.Y) + Camera.Transform.Position), 2));
                obj.BuildRenderer(new Renderer(Content, "Towers2"));
                hierarchy.AddObject(obj);
            }

            Camera.Transform.MovePosition(Vector2.UnitX * AxisInput.GetAxisX(keyboard) * 500f * gameTime.ElapsedGameTime.Milliseconds / 1000);
            Camera.Transform.MovePosition(Vector2.UnitY * AxisInput.GetAxisY(keyboard) * 500f * gameTime.ElapsedGameTime.Milliseconds / 1000);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(0, null, SamplerState.PointClamp);
            foreach (var obj in hierarchy.Objects)
            {
                var rendererPosition = camera.GetRelativePosition(obj.Transform.GetPositionInPixels());
                Rectangle rct = new Rectangle(
                    (int) rendererPosition.X, (int) rendererPosition.Y,
                    (int) obj.GetScaleInPixels().X, (int) obj.GetScaleInPixels().Y);
                _spriteBatch.Draw(obj.Renderer.Texture[0], rct, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}