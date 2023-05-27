using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Block_Yellow : Block
    {
        #region Constructor
        public Block_Yellow(Image image, Size size) : base(image, size)
        {
            base.Matrices = new List<int[,]>()
            {
                new int[,]
                {
                    { 7, 7 },
                    { 7, 7 }
                },
             };
        }
        #endregion
    }
}
