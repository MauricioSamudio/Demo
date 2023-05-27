using Game.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Demo : Game.Game
    {
        #region Objects
        private int _dalay;
        #endregion

        #region Constructor
        public Demo()
        {
            InitializeComponent();
            Initialize();

            Start_Game();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Recursos graficos del juego
        /// </summary>
        public Elements.Resources Resources { get; set; }
        /// <summary>
        /// Grilla del tetris
        /// </summary>
        public Elements.Board Board { get; set; }
        /// <summary>
        /// Lista de Bloques
        /// </summary>
        public List<Elements.Block> Blocks { get; set; }
        /// <summary>
        /// Bloque actual
        /// </summary>
        public Elements.Block CurrentBlock { get; set; }
        /// <summary>
        /// Indica que el juego esta en curso
        /// </summary>
        public bool Playing { get; set; }
        #endregion

        #region Events+
        private void btnLink_Click(object sender, EventArgs e)
        {
            base.Open_ZeroSoft_URL();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Carga los recursos graficos del juego
        /// </summary>
        private void Initialize()
        {
            string directory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");
            this.Resources = new Elements.Resources()
            {
                Block_Blue = Load_Image($"{directory}/Block_Blue.png"),
                Block_Cyan = Load_Image($"{directory}/Block_Cyan.png"),
                Block_Green = Load_Image($"{directory}/Block_Green.png"),
                Block_Orange = Load_Image($"{directory}/Block_Orange.png"),
                Block_Red = Load_Image($"{directory}/Block_Red.png"),
                Block_Violet = Load_Image($"{directory}/Block_Violet.png"),
                Block_Yellow = Load_Image($"{directory}/Block_Yellow.png"),
            };

            var _block_Size = new Size(40, 40);
            Blocks = new List<Elements.Block>()
            {
                new Elements.Block_Blue(this.Resources.Block_Blue, _block_Size),
                new Elements.Block_Cyan(this.Resources.Block_Cyan, _block_Size),
                new Elements.Block_Green(this.Resources.Block_Green, _block_Size),
                new Elements.Block_Orange(this.Resources.Block_Orange, _block_Size),
                new Elements.Block_Red(this.Resources.Block_Red, _block_Size),
                new Elements.Block_Violet(this.Resources.Block_Violet, _block_Size),
                new Elements.Block_Yellow(this.Resources.Block_Yellow, _block_Size),
            };
        }
        /// <summary>
        /// Inicia una nueva partida
        /// </summary>
        private void Start_Game()
        {
            Board = new Elements.Board(this.Resources);
            this.ClientSize = new Size(this.Width, Board.Grid_Size.Height * Board.Block_Size.Height);
            this.MinimumSize = this.MaximumSize = this.Size;
            this.CurrentBlock = null;
            this.Playing = true;
        }
        /// <summary>
        /// Obtiene un nuevo bloque
        /// </summary>
        private void Next_Block()
        {
            if (CurrentBlock == null)
            {
                Random r = new Random(DateTime.Now.Millisecond);
                CurrentBlock = Blocks[r.Next(0, 7)];
                CurrentBlock.Location = new Point(this.Board.Grid_Size.Width / 2 - CurrentBlock.Matrix_Size.Width / 2, 0); // centro la pieza en la pantalla
                CurrentBlock.SetDefault();

                if (Board.BlockCollition(CurrentBlock, Point.Empty) || Board.BlockCollition(CurrentBlock, new Point(0, 1)))
                {
                    Playing = false;
                    MessageBox.Show("Game Over");
                    Start_Game();
                }
            }
        }
        /// <summary>
        /// Mueve la pieza hacia abajo
        /// </summary>
        private void MoveDown_Piece()
        {
            if (CurrentBlock == null)
                return;

            if (_dalay >= 500)
            {
                _dalay = 0;
                // si el desplazamiento alcanzo al tamaño de una celda, actualizo la cooredenada de la piza y reseteo el desplazamiento
                CurrentBlock.Location = new Point(CurrentBlock.Location.X, CurrentBlock.Location.Y + 1);
                Valid_DownCollition();
            }
        }

        /// <summary>
        /// Desplaza la pieza hacia los laterales
        /// </summary>
        /// <param name="moveValue"></param>
        private void MoveSide_Piece(int moveValue)
        {
            if (CurrentBlock == null)
                return;

            if (CurrentBlock.Location.X + moveValue < 0)
                return;

            if (CurrentBlock.Location.X + CurrentBlock.Matrix_Size.Width + moveValue > this.Board.Grid_Size.Width)
                return;

            var _newLocation = new Point(CurrentBlock.Location.X + moveValue, CurrentBlock.Location.Y);

            for (int y = 0; y < CurrentBlock.Matrix_Size.Height; y++)
                for (int x = 0; x < CurrentBlock.Matrix_Size.Width; x++)
                {
                    int value = CurrentBlock.Matrix[y, x];
                    if (value > 0)
                    {
                        // valido si algun bloque de la pieza coliciona con los bloques de la grilla
                        var _location = new Point(_newLocation.X + x, _newLocation.Y + y);
                        if (this.Board.HasBlock(_location))
                            return;
                    }
                }

            CurrentBlock.Location = _newLocation;
            Valid_DownCollition();
        }
        /// <summary>
        /// Valida si el bloqueo coliciono con las los bloques inferiores de lagrilla
        /// </summary>
        private void Valid_DownCollition()
        {
            if (CurrentBlock != null && this.Board.BlockCollition(CurrentBlock, new Point(0, 1)))
            {
                this.Board.Add_Block(CurrentBlock); // agrega el bloque a la grilla
                this.Board.CheckLines(); // valida la linea generada
                CurrentBlock = null;
                return;
            }
        }
        /// <summary>
        /// Fuerza el desenso de la pieza
        /// </summary>
        private void Force_Down()
        {
            while (CurrentBlock != null)
            {
                CurrentBlock.Location = new Point(CurrentBlock.Location.X, CurrentBlock.Location.Y + 1);
                Valid_DownCollition();
            }
        }
        #endregion

        #region Updates
        /// <summary>
        /// Metodo que donde se escribe la logica del juego
        /// </summary>
        /// <param name="gameTime">Informacion de tiempo de juego transcurrido</param>
        protected override void Update(GameTime gameTime)
        {
            if (!Playing)
                return;

            _dalay += gameTime.FrameMilliseconds;

            if (base.Keyboard.Right)
                MoveSide_Piece(1);
            else if (base.Keyboard.Left)
                MoveSide_Piece(-1);
            else if (base.Keyboard.Up)
            {
                Board.Rotate(CurrentBlock, -1);
                Valid_DownCollition();
            }
            else if (base.Keyboard.Down)
            {
                Board.Rotate(CurrentBlock, 1);
                Valid_DownCollition();
            }
            else if (base.Keyboard.Space)
                Force_Down();

            lblLines.Text = Board.Lines.ToString();

            Next_Block();
            MoveDown_Piece();
        }
        #endregion

        #region Draw
        /// <summary>
        /// Dibuja la grilla
        /// </summary>
        /// <param name="drawHandler"></param>
        public override void Draw(DrawHandler drawHandler)
        {
            this.Board.Draw(drawHandler);
            if (this.CurrentBlock != null)
                this.CurrentBlock.Draw(drawHandler);
        }

        #endregion

        private void Demo_Load(object sender, EventArgs e)
        {

        }
    }
}
