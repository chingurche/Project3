using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Scripts.Core
{
    internal static class AxisInput
    {
        public static int GetAxisX(KeyboardState state)
        {
            int axis = 0;
            if (state.IsKeyDown(Keys.D)) { axis++; }
            if (state.IsKeyDown(Keys.A)) { axis--; }
            return axis;
        }
        public static int GetAxisY(KeyboardState state)
        {
            int axis = 0;
            if (state.IsKeyDown(Keys.S)) { axis++; }
            if (state.IsKeyDown(Keys.W)) { axis--; }
            return axis;
        }
    }
}
