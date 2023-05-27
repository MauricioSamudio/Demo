using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Block_Orange : Block
    {
        #region Constructor
        public Block_Orange(Image image, Size size) : base(image, size)
        {
            base.Matrices = new List<int[,]>()
            {
                new int[,]
                {
                    { 0, 0, 4},
                    { 4, 4, 4}
                },
                new int[,]
                {
                    { 4, 4},
                    { 0, 4},
                    { 0, 4}
                },
                new int[,]
                {
                    { 4, 4, 4},
                    { 4, 0, 0}
                },
                new int[,]
                {
                    { 4, 0},
                    { 4, 0},
                    { 4, 4}
                }
             };
        }
        #endregion
    }
}
