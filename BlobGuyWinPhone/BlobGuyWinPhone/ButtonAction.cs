using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroclasticStudios
{
    [Flags]
    public enum ButtonAction : int
    {
        None = 0x0,
        Left = 0x1,
        Right = 0x2,
        Up = 0x4
    };

    public static class ButtonActionExt
    {
        public static bool IsRight(this ButtonAction act)
        {
            return (act & ButtonAction.Right) == ButtonAction.Right;
        }
        public static bool IsLeft(this ButtonAction act)
        {
            return (act & ButtonAction.Left) == ButtonAction.Left;
        }
        public static bool IsUp(this ButtonAction act)
        {
            return (act & ButtonAction.Up) == ButtonAction.Up;
        }
    }

}
