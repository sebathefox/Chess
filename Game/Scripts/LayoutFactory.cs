using Game.Scripts.Pieces;
using Microsoft.Xna.Framework;

namespace Game.Scripts
{
    public static class LayoutFactory
    {
        public static Piece[] GenerateBlack()
        {
            Piece[] pieces = new Piece[16];

            Piece[] pawns = GeneratePawns(GameColor.Black);
            Piece[] pawnz = GeneratePawns(GameColor.Black);

            for (int i = 0; i < 8; i++)
            {
                pieces[i] = pawns[i];
            }
            
            for (int i = 8; i < 16; i++)
            {
                pieces[i] = pawns[i - 8];
            }
            
            return pieces;
        }

        private static Piece[] GeneratePawns(GameColor color)
        {
            int yOffset = 64;
            
            if(color == GameColor.White)
                yOffset = 448;
            
            Piece[] pieces = new Piece[8];

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = new Pawn(9 + i, new Vector2(i, 1), new Vector2(64 * i, yOffset), ResourceManager.Instance.Textures[color.ToString().ToLower() + "_pawn"], color);
            }
            
            return pieces;
        }
    }
}