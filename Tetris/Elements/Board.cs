using Game.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Elements
{
    public class Board : Sprite
    {
        #region Objects
        Image[] _blocks;
        #endregion

        #region Constructor
        public Board(Elements.Resources resources) : base(null, Point.Empty)
        {
            this.Block_Size = new Size(40, 40);
            this.Grid_Size = new Size(10, 15);
            this.Matrix = new int[this.Grid_Size.Width, this.Grid_Size.Height];

            _blocks = new Image[]
            {
                resources.Block_Blue,
                resources.Block_Cyan,
                resources.Block_Green,
                resources.Block_Orange,
                resources.Block_Red,
                resources.Block_Violet,
                resources.Block_Yellow
            };
        }
        #endregion

        #region Properties
        /// <summary>
        /// Tamaño de la grilla
        /// </summary>
        public Size Block_Size { get; private set; }
        /// <summary>
        /// Tamaño de la grilla
        /// </summary>
        public Size Grid_Size { get; private set; }
        /// <summary>
        /// Matriz de celdas en la grilla
        /// </summary>
        private int[,] Matrix { get; set; }
        /// <summary>
        /// Cantidad de lineas realizadas
        /// </summary>
        public int Lines { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Valida si el casillero de la grilla tiene un bloque
        /// </summary>
        /// <param name="location">Ubicacion de la grilla a validar</param>
        /// <returns></returns>
        public bool HasBlock(Point location)
        {
            if (location.Y >= Grid_Size.Height || location.X >= Grid_Size.Width)
                return true;

            return this.Matrix[location.X, location.Y] > 0;
        }
        /// <summary>
        /// Agrega un el bloque a la grilla
        /// </summary>
        /// <param name="block">Bloque a agregar</param>
        public void Add_Block(Block block)
        {
            if (block == null)
                return;

            for (int y = 0; y < block.Matrix_Size.Height; y++)
                for (int x = 0; x < block.Matrix_Size.Width; x++)
                {
                    int value = block.Matrix[y, x];
                    if (value > 0)
                    {
                        Point _location = new Point(x + block.Location.X, y + block.Location.Y);
                        this.Matrix[_location.X, _location.Y] = value;
                    }
                }
        }
        public void Rotate(Block block, int value)
        {
            if (block == null)
                return;

            var _location = block.Location;
            Size _size1 = block.Matrix_Size;
            block.Rotate(value); // giro la pieza
            if (BlockCollition(block, Point.Empty)) // valido que la nueva posicion de la piza no colicione con otras
            {
                Size _size2 = block.Matrix_Size;
                block.Location = new Point(block.Location.X - (_size2.Width - _size1.Width), block.Location.Y); // si ha colicion muevo la pieza 
                if (BlockCollition(block, Point.Empty)) // valido que la nueva posicion de la piza no colicione con otras
                {
                    block.Rotate(value * -1); // si hay colicion nuevamente giro la pieza como estaba originalmente
                    block.Location = _location;
                }
            }
        }
        /// <summary>
        /// Determina si el bloque coliciona con los demas bloques de la grilla
        /// </summary>
        /// <param name="block">Bloque a validar</param>
        /// <returns></returns>
        public bool BlockCollition(Block block, Point locationAdjust)
        {
            if (block == null)
                return true;

            for (int y = 0; y < block.Matrix_Size.Height; y++)
                for (int x = 0; x < block.Matrix_Size.Width; x++)
                {
                    int value = block.Matrix[y, x];
                    if (value > 0)
                    {
                        // valido si algun bloque de la pieza coliciona con los bloques de la grilla
                        var _location = new Point(block.Location.X + x + locationAdjust.X, block.Location.Y + y + locationAdjust.Y);
                        if (HasBlock(_location))
                            return true;
                    }
                }

            return false;
        }
        /// <summary>
        /// Valida si se completo una linea
        /// </summary>
        public void CheckLines()
        {
            for (int y = 0; y < Grid_Size.Height; y++)
            {
                int _lineBlock = 0;
                for (int x = 0; x < Grid_Size.Width; x++)
                {
                    int value = Matrix[x, y];
                    _lineBlock += (value > 0 ? 1 : 0); // cuenta los bloques de la linea
                }

                if (_lineBlock == Grid_Size.Width) // si todos los bloques estas ocuopados se genera una linea
                {
                    Lines++;
                    for (int _y = y; _y >= 0; _y--)
                    {
                        for (int x = 0; x < Grid_Size.Width; x++)
                        {
                            if (_y > 0)
                                Matrix[x, _y] = Matrix[x, _y - 1]; // asignan a la linea actual los bloques de la linea superior
                            else
                                Matrix[x, _y] = 0;
                        }
                    }
                }
            }
        }
        #endregion

        #region Draw
        /// <summary>
        /// Dibuja la grilla
        /// </summary>
        /// <param name="drawHandler"></param>
        public override void Draw(DrawHandler drawHandler)
        {
            for (int x = 0; x < Grid_Size.Width; x++)
                for (int y = 0; y < Grid_Size.Height; y++)
                {
                    int value = Matrix[x, y];
                    if (value > 0)
                    {
                        Point _position = new Point(x * Block_Size.Width, y * Block_Size.Height);
                        var image = _blocks[value - 1];
                        drawHandler.Draw(image, _position);
                    }
                }
        }
        #endregion
    }
}
