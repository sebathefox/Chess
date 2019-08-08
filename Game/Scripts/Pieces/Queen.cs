using System;
 using Microsoft.Xna.Framework;
 using Microsoft.Xna.Framework.Graphics;
 
 namespace Game.Scripts.Pieces
 {
     public class Queen : Piece
     {
         public Queen(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(id, position, pixelPosition, texture, color)
         {
         }
 
         public override void GetMoveableFields()
         {
             for (int x = (int)_position.X; x < 8; x++)
             {
                 if(x == _position.X)
                     continue;
 
                 Field currentField = ResourceManager.Instance.Fields[x, (int)_position.Y];
                 
                 if(currentField == null)
                     throw new Exception("currentField Is Null!");
 
                 if (currentField.Piece != null)
                 {
                     if(currentField.Piece.Color == _color)
                         break;
                 }
 
                 AddMoveableField(currentField.Id.ToPoint());
             }
             
             for (int x = (int)_position.X; x >= 0; x--)
             {
                 if(x == _position.X)
                     continue;
 
                 Field currentField = ResourceManager.Instance.Fields[x, (int)_position.Y];
                 
                 if(currentField == null)
                     throw new Exception("currentField Is Null!");
 
                 if (currentField.Piece != null)
                 {
                     if(currentField.Piece.Color == _color)
                         break;
                 }
 
                 AddMoveableField(currentField.Id.ToPoint());
             }
             
             for (int y = (int)_position.Y; y < 8; y++)
             {
                 if(y == _position.Y)
                     continue;
 
                 Field currentField = ResourceManager.Instance.Fields[(int)_position.X, y];
                 
                 if(currentField == null)
                     throw new Exception("currentField Is Null!");
 
                 if (currentField.Piece != null)
                 {
                     if(currentField.Piece.Color == _color)
                         break;
                 }
 
                 AddMoveableField(currentField.Id.ToPoint());
             }
             
             for (int y = (int)_position.Y; y >= 0; y--)
             {
                 if(y == _position.Y)
                     continue;
 
                 Field currentField = ResourceManager.Instance.Fields[(int)_position.X, y];
                 
                 if(currentField == null)
                     throw new Exception("currentField Is Null!");
 
                 if (currentField.Piece != null)
                 {
                     if(currentField.Piece.Color == _color)
                         break;
                 }
 
                 AddMoveableField(currentField.Id.ToPoint());
             }
             
             for (int x = (int)_position.X, y = (int)_position.Y; x < 8 && y < 8; x++, y++)
             {
                     Field currentField = ResourceManager.Instance.Fields[x, y];
                     
                     if(currentField == null)
                         throw new Exception("currentField Is Null!");
 
                     if (currentField.Piece != null)
                     {
                         if (currentField.Piece.Color == _color)
                             continue;
                     }
 
                     AddMoveableField(currentField.Id.ToPoint());
             }
             
             for (int x = (int)_position.X, y = (int)_position.Y; x >= 0 && y >= 0; x--, y--)
             {
                 Field currentField = ResourceManager.Instance.Fields[x, y];
                     
                 if(currentField == null)
                     throw new Exception("currentField Is Null!");
 
                 if (currentField.Piece != null)
                 {
                     if (currentField.Piece.Color == _color)
                         continue;
                 }
 
                 AddMoveableField(currentField.Id.ToPoint());
             }
             
             for (int x = (int)_position.X, y = (int)_position.Y; x < 8 && y >= 0; x++, y--)
             {
                 Field currentField = ResourceManager.Instance.Fields[x, y];
                     
                 if(currentField == null)
                     throw new Exception("currentField Is Null!");
 
                 if (currentField.Piece != null)
                 {
                     if (currentField.Piece.Color == _color)
                         continue;
                 }
 
                 AddMoveableField(currentField.Id.ToPoint());
             }
             
             for (int x = (int)_position.X, y = (int)_position.Y; x >= 0 && y < 8; x--, y++)
             {
                 Field currentField = ResourceManager.Instance.Fields[x, y];
                     
                 if(currentField == null)
                     throw new Exception("currentField Is Null!");
 
                 if (currentField.Piece != null)
                 {
                     if (currentField.Piece.Color == _color)
                         continue;
                 }
 
                 AddMoveableField(currentField.Id.ToPoint());
             }
         }
     }
 }