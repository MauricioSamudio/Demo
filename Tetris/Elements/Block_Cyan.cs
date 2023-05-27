using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Block_Cyan : Block
    {
        #region Constructor
        public Block_Cyan(Image image, Size size) : base(image, size)
        {
            base.Matrices = new List<int[,]>()
            {
                new int[,]
                {
                    { 2, 2, 2, 2}
                },
                new int[,]
                {
                    { 2 },
                    { 2 },
                    { 2 },
                    { 2 }
                },
             };
        }
        #endregion
    }
}
