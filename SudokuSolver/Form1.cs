using SudokuSolver.Logging;
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
        //Легкий уровень
        /*{
            { 0,2,0,8,0,0,0,4,3},
            { 0,5,0,3,0,9,0,0,0},
            { 4,0,0,0,0,0,1,9,0},
            { 6,8,0,1,3,2,0,0,0 },
            {7,3,0,0,9,8,0,6,0},
            { 0,1,9,0,6,4,0,3,0},
            { 3,4,0,0,0,0,7,8,6},
            {1,0,7,0,8,0,0,5,0},
            {0,0,8,4,0,7,0,0,9}
        };*/

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cellViews = new CellViews(this.panel1, 9, 9, 40, 5, 15);
            this.cellViews.SetCellsValues(this.values);
            this.solvedCellViews = new CellViews(this.panel2, 9, 9, 40, 5, 15);
            Logger.messagesTextBox = this.Messages;
            Update();
        }

        private void Calculate()
        {
            this.modelField = new ModelField(this.cellViews.GetCellsValues());
            if (this.modelField.IsValid())
            {
                this.modelField.Culculate();
                this.solvedCellViews.Clear();
                this.solvedCellViews.SetCellsValues(this.modelField.GetResults());
            }
        }

        private void Go_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void ParseToInts(string[] lines)
        {
            if (lines.Length != 9)
            {
                Logger.Error($"Ошибка чтения из файла! Данные не верны! Не 9 строк.");
                return;
            }
            this.values = new int[9, 9];
            int lineCounter = 0;
            int numberCounter = 0;
            foreach(string line in lines)
            {
                if (line.Length != 9)
                {
                    Logger.Error($"Ошибка чтения из файла! Данные не верны! В строке {lineCounter+1} не 9 цифр!");
                    return;
                }
                numberCounter = 0;
                foreach (char c in line.Replace("\n", "").Replace("\0", ""))
                {
                    bool result = int.TryParse(c.ToString(), out int number);
                    if (result)
                    {
                        values[lineCounter, numberCounter] = number;
                    }
                    else
                    {
                        Logger.Error($"Ошибка чтения из файла! Данные не верны! В строке {lineCounter + 1} есть не цифры!");
                        return;
                    }
                    ++numberCounter;
                }
                ++lineCounter;
            }
            this.cellViews.SetCellsValues(this.values);
        }
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            List<string> lines = new List<string>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(exc.Message);
                }
            }
            ParseToInts(lines.ToArray());
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            int[,] value = this.cellViews.GetCellsValues();
            List<string> lines= new List<string>();
            for (int i = 0; i < 9; i++)
            {
                string line = "";
                for (int j = 0; j < 9; j++)
                {
                    line += value[i, j].ToString();
                }
                lines.Add(line);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}