using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pseudo_3D_test
{
    public class BuildWorld
    {
        static Rectangle[,] mapRects = new Rectangle[10, 10];

        public static void Build(int[,] gameMap)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    mapRects[i, j] = new Rectangle(100 * i, 100 * j, 100, 100);
                }
            }
        }

        public static void Draw(SpriteBatch _spriteBatch, int[,] gameMap, Texture2D floor, Texture2D shownWall, Texture2D hiddenWall)
        {
            _spriteBatch.Begin();
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (gameMap[j,i] == 0) // j then i as arrays accessed across then downwards
                    {
                        _spriteBatch.Draw(floor, mapRects[i, j], Color.White);
                    } else if (gameMap[j,i] == 1)
                    {
                        _spriteBatch.Draw(shownWall, mapRects[i, j], Color.White);
                    } else if (gameMap[j,i] == 2)
                    {
                        _spriteBatch.Draw(hiddenWall, mapRects[i, j], Color.White);
                    }
                    
                }
            }
            _spriteBatch.End();
        }
    }
}
