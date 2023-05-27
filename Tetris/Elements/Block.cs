using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Elements;

namespace Tetris.Elements
{
    public class Block : Game.Elements.Sprite
    {
        #region Constructor
        public Block(Image image, Size size) : base(image, Point.Empty)
        {
            this.Block_Size = size;
            this.MatrixIndex = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Matriz de la pieza que se mostrara
        /// </summary>
        public int[,] Matrix { get { return Matrices[MatrixIndex]; } }
        /// <summary>
        /// 4 matrices que indican la forma de la pieza
        /// </summary>
        protected List<int[,]> Matrices { get; set; }
        private int MatrixIndex { get; set; }
        /// <summary>
        /// Ubicacion de la pieza en la grilla
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// Tamaño de la matriz
        /// </summary>
        public Size Matrix_Size
        {
            get
            {
                return new Size(Matrix.GetLength(1), Matrix.GetLength(0));
            }
        }
        /// <summary>
        /// Tamaño del bloque
        /// </summary>
        public Size Block_Size { get; private set; }
        #endregion

        #region Methods
        public void Rotate(int value)
        {
            int _newIndex = MatrixIndex + value;
            if (_newIndex < 0)
                _newIndex = Matrices.Count - 1;
            if (_newIndex == Matrices.Count)
                _newIndex = 0;

            MatrixIndex = _newIndex;
        }
        /// <summary>
        /// Setea la forma inicial del bloque
        /// </summary>
        public void SetDefault()
        {
            MatrixIndex = 0;
        }
        #endregion

        #region Draw
        public override void Draw(DrawHandler drawHandler)
        {
            for (int y = 0; y < Matrix_Size.Height; y++)
                for (int x = 0; x < Matrix_Size.Width; x++)
                {
                    int value = Matrix[y, x];
                    if (value > 0)
                    {
                        Point _position = new Point((x + Location.X) * Block_Size.Width, (y + Location.Y) * Block_Size.Height);
                        drawHandler.Draw(base.Image, _position);
                    }
                }
        }
        #endregion
    }
}
