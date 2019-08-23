using System;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game.Scripts.Network
{
    public static class Serializer
    {
        public static PieceState DeSerialize(byte[] raw)
        {
            string stateString = Encoding.UTF8.GetString(raw);


            int indexFirst = stateString.IndexOf(';') + 1;
            int indexSecond = stateString.IndexOf(';', indexFirst) + 1;
            int indexThird = stateString.IndexOf(';', indexSecond) + 1;

            float x = int.Parse(stateString.Substring(indexSecond, 1));
            float y = int.Parse(stateString.Substring(indexThird, 1));


            PieceState state = new PieceState(int.Parse(stateString.Substring(0, stateString.IndexOf(';'))),
                                            Enum.Parse<GameColor>(stateString.Substring(indexFirst, stateString.Length - stateString.IndexOf(';', indexFirst) + 1)),
                                            new Vector2(x, y));
            return state;
        }

        public static byte[] Serialize(PieceState state)
        {
            string raw = state.Id + ";" +
                         state.Color.ToString() + ";" +
                         state.NewPosition.X + ";" +
                         state.NewPosition.Y;

            byte[] bytes = Encoding.UTF8.GetBytes(raw);

            return bytes;
        }
    }
}