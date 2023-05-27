using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Block_Blue : Block
    {
        #region Constructor
        public Block_Blue(Image image, Size size) : base(image, size)
        {
            base.Matrices = new List<int[,]>()
            {
                new int[,]
                {
                    { 1, 0, 0},
                    { 1, 1, 1}
                },
                new int[,]
                {
                    { 0, 1},
                    { 0, 1},
                    { 1, 1}
                },
                new int[,]
                {
                    { 1, 1, 1},
                    { 0, 0, 1}
                },
                new int[,]
                {
                    { 1, 1},
                    { 1, 0},
                    { 1, 0}
                }
             };
        }
        #endregion
    }
}
