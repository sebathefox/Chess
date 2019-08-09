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
            
            pieces[0] = new Castle(1,new Vector2(0), new Vector2(0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_castle"], GameColor.Black);
            pieces[1] = new Knight(2,new Vector2(1, 0), new Vector2(64, 0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_knight"], GameColor.Black);
            pieces[2] = new Bishop(3,new Vector2(2, 0), new Vector2(128, 0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_bishop"], GameColor.Black);
            pieces[3] = new King(4,new Vector2(3, 0), new Vector2(64 * 3, 0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_king"], GameColor.Black);
            pieces[4] = new Queen(5,new Vector2(4, 0), new Vector2(64 * 4, 0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_queen"], GameColor.Black);
            pieces[5] = new Bishop(6,new Vector2(5, 0), new Vector2(64 * 5, 0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_bishop"], GameColor.Black);
            pieces[6] = new Knight(7,new Vector2(6, 0), new Vector2(64 * 6, 0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_knight"], GameColor.Black);
            pieces[7] = new Castle(8,new Vector2(7, 0), new Vector2(64 * 7, 0), ResourceManager.Instance.Textures[GameColor.Black.ToString().ToLower() + "_castle"], GameColor.Black);
            
            for (int i = 8; i < 16; i++)
            {
                pieces[i] = pawns[i - 8];
            }

            for (int y = 0, i = 0; y < 2; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    ResourceManager.Instance.Fields[(int) pieces[i].Position.X, (int) pieces[i].Position.Y].Piece =
                        pieces[i];
                    i++;
                }
            }
            
            return pieces;
        }

        public static Piece[] GenerateWhite()
        {
            Piece[] pieces = new Piece[16];

            Piece[] pawns = GeneratePawns(GameColor.White);
            
            pieces[0] = new Castle(1,new Vector2(0, 7), new Vector2(0, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_castle"], GameColor.White);
            pieces[1] = new Knight(2,new Vector2(1, 7), new Vector2(64, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_knight"], GameColor.White);
            pieces[2] = new Bishop(3,new Vector2(2, 7), new Vector2(128, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_bishop"], GameColor.White);
            pieces[3] = new King(4,new Vector2(3, 7), new Vector2(64 * 3, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_king"], GameColor.White);
            pieces[4] = new Queen(5,new Vector2(4, 7), new Vector2(64 * 4, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_queen"], GameColor.White);
            pieces[5] = new Bishop(6,new Vector2(5, 7), new Vector2(64 * 5, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_bishop"], GameColor.White);
            pieces[6] = new Knight(7,new Vector2(6, 7), new Vector2(64 * 6, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_knight"], GameColor.White);
            pieces[7] = new Castle(8,new Vector2(7, 7), new Vector2(64 * 7, 448), ResourceManager.Instance.Textures[GameColor.White.ToString().ToLower() + "_castle"], GameColor.White);
            
            for (int i = 8; i < 16; i++)
            {
                pieces[i] = pawns[i - 8];
            }
            
            for (int y = 6, i = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    ResourceManager.Instance.Fields[(int) pieces[i].Position.X, (int) pieces[i].Position.Y].Piece =
                        pieces[i];
                    i++;
                }
            }
            
            return pieces;
        }

        private static Piece[] GeneratePawns(GameColor color)
        {
            int yOffset = 64;
            
            if(color == GameColor.White)
                yOffset = 384;
            
            Piece[] pieces = new Piece[8];

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = new Pawn(9 + i, new Vector2(i, yOffset / 64), new Vector2(64 * i, yOffset), ResourceManager.Instance.Textures[color.ToString().ToLower() + "_pawn"], color);
            }
            
            return pieces;
        }
    }
}