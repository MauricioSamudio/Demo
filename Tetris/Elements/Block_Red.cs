using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Block_Red : Block
    {
        #region Constructor
        public Block_Red(Image image, Size size) : base(image, size)
        {
            base.Matrices = new List<int[,]>()
            {
                new int[,]
                {
                    { 5, 5, 0},
                    { 0, 5, 5}
                },
                new int[,]
                {
                    { 0, 5},
                    { 5, 5},
                    { 5, 0}
                },
             };
        }
        #endregion
    }
}
