using SudokuSolver.View;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CellViews cellViews;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cellViews = new CellViews(this.panel1, 9, 9, 40, 5);
        }
    }
}