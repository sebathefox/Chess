using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game.Scripts
{
    public class KeyboardEventArgs : EventArgs
    {
        public KeyboardEventArgs(Keys key, bool capsLock = false, bool numLock = false)
        {
            Key = key;
            CapsLock = capsLock;
            NumLock = numLock;
        }
        
        public Keys Key;

        public bool CapsLock;

        public bool NumLock;
    }
    
    
    public static class Input
    {
        public static event EventHandler<KeyboardEventArgs> KeyPressed;
        
        public static event EventHandler<KeyboardEventArgs> KeyReleased;


        public static void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.GetPressedKeys() != null && keyState.GetPressedKeys().Length > 0)
            {
                foreach (Keys key in keyState.GetPressedKeys())
                {
                    KeyPressed?.Invoke(keyState, new KeyboardEventArgs(key));
                }
            }
        }
    }
}