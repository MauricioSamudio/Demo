using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Block_Green : Block
    {
        #region Constructor
        public Block_Green(Image image, Size size) : base(image, size)
        {
            base.Matrices = new List<int[,]>()
            {
                new int[,]
                {
                    { 0, 3, 3},
                    { 3, 3, 0}
                },
                new int[,]
                {
                    { 3, 0},
                    { 3, 3},
                    { 0, 3}
                },
             };
        }
        #endregion
    }
}
