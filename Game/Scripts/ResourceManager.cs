using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts
{
    public sealed class ResourceManager
    {
        private static ResourceManager _instance;

        private Dictionary<string, Texture2D> _textures;
        
        private Field[,] _fields;

        private Player[] _players;
        
        private ResourceManager()
        {
            _textures = new Dictionary<string, Texture2D>();
            
            _fields = new Field[ 8, 8];

            
        }

        public void Init()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    _fields[x, y] = new Field(new Vector2(x, y), new Point(x * 64, y * 64));
                }
            }
            
            _players = new Player[2];
        }
        
        static ResourceManager()
        {
            if(_instance == null)
                _instance = new ResourceManager();
        }

        public void LoadTexture(ContentManager content, string name)
        {
            _textures.Add(name, content.Load<Texture2D>(name));
        }
        
        public static ResourceManager Instance => _instance;

        public Dictionary<string, Texture2D> Textures
        {
            get => _textures;
            set => _textures = value;
        }
        
        public Field[,] Fields
        {
            get => _fields;
            set => _fields = value;
        }

        public Player[] Players
        {
            get => _players;
            set => _players = value;
        }
    }
}