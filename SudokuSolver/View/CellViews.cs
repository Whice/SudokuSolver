namespace SudokuSolver.View
{
    /// <summary>
    /// Набор представлений ячеек.
    /// </summary>
    internal class CellViews
    {
        /// <summary>
        /// Элемент, внутри которого будут создаваться ячейки
        /// </summary>
        private Control? parent;
        /// <summary>
        /// Расстояние между ячейками.
        /// </summary>
        private int spacing = 5;
        /// <summary>
        /// Размер ячейки.
        /// </summary>
        private int cellSize = 40;
        /// <summary>
        /// Размер ячейки.
        /// </summary>
        private int width = 9;
        /// <summary>
        /// Размер ячейки.
        /// </summary>
        private int height = 9;
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public CellViews(Control? parent, int width, int height, int cellSize, int cellSpacing)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        { 
            this.parent = parent;
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.spacing = cellSpacing;
            CreateAllViews();
        }

        /// <summary>
        /// Все представления ячеек.
        /// </summary>
        private RichTextBox[,] cellViews;
        /// <summary>
        /// Создать все представления.
        /// </summary>
        private void CreateAllViews()
        {
            int width = this.width;
            int height = this.height;
            this.cellViews = new RichTextBox[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.cellViews[i, j] = CreateCellView(i, j);
                }
            }
        }
        /// <summary>
        /// Создать одну ячеку в указанной позиции.
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <returns></returns>
        private RichTextBox CreateCellView(int xPos, int yPos)
        {
            xPos = xPos * (this.cellSize + this.spacing);
            yPos = yPos * (this.cellSize + this.spacing);
            RichTextBox newRichTextBox = new RichTextBox();
            newRichTextBox.Location = new Point(xPos, yPos);
            newRichTextBox.Name = $"Cell view {xPos}; {yPos};";
            newRichTextBox.Size = new Size(this.cellSize, this.cellSize);
            newRichTextBox.TabIndex = 1;
            newRichTextBox.Text = "";
            newRichTextBox.Parent = this.parent;

            return newRichTextBox;
        }
        private bool IsNumberFrom1To9(string number)
        {
            bool result = false;
            result |= number == "1";
            result |= number == "2";
            result |= number == "3";
            result |= number == "4";
            result |= number == "5";
            result |= number == "6";
            result |= number == "7";
            result |= number == "8";
            result |= number == "9";
            return result;
        }
        /// <summary>
        /// Получить числовые значения из ячеек.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int[,] GetCellsValues()
        {
            int width = this.width;
            int height = this.height;
            int[,] values = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    string value = this.cellViews[i, j].Text;
                    if (IsNumberFrom1To9(value))
                    {
                        values[i, j] = Convert.ToInt32(this.cellViews[i, j].Text);
                    }
                    else
                    {
                        throw new Exception($"Ой! Не однозначное число! В {i};{j};");
                    }
                }
            }

            return values;
        }
    }
}
