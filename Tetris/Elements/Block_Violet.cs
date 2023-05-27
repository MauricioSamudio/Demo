using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Block_Violet : Block
    {
        #region Constructor
        public Block_Violet(Image image, Size size) : base(image, size)
        {
            base.Matrices = new List<int[,]>()
            {
                new int[,]
                {
                    { 0, 6, 0},
                    { 6, 6, 6},
                },
                new int[,]
                {
                    { 0, 6},
                    { 6, 6},
                    { 0, 6}
                },
                new int[,]
                {
                    { 6, 6, 6},
                    { 0, 6, 0}
                },
                new int[,]
                {
                    { 6, 0},
                    { 6, 6},
                    { 6, 0}
                }
             };
        }
        #endregion
    }
}
