using SudokuSolver.Model;
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
        private CellViews solvedCellViews;
        private ModelField modelField;
        private int[,] values = new[,]
        {
            { 2, 9, 3, 4, 5, 7, 6, 8, 1},
            { 4, 7, 5, 1, 8, 6, 3, 9, 2 },
            { 1, 6, 8, 3, 9, 2, 7, 4, 5},
            { 9, 4, 2, 5, 7, 1, 8, 6, 3 },
            { 3, 8, 1, 6, 2, 9, 5, 7, 4},
            { 6, 5, 7, 8, 3, 4, 1, 2, 9},
            { 7, 2, 6, 9, 1, 3, 4, 5, 8},
            { 5, 1, 4, 2, 6, 8, 9, 3, 7},
            { 8, 3, 9, 7, 4, 5, 2, 1, 6}
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cellViews = new CellViews(this.panel1, 9, 9, 40, 5, 15);
            this.cellViews.SetCellsValues(this.values);
            this.solvedCellViews = new CellViews(this.panel2, 9, 9, 40, 5, 15);
            Update();
        }

        private void Go_Click(object sender, EventArgs e)
        {
            this.modelField = new ModelField(this.cellViews.GetCellsValues());
            this.modelField.Culculate();
            this.solvedCellViews.Clear();
            this.solvedCellViews.SetCellsValues(this.modelField.GetResults());
        }
    }
}