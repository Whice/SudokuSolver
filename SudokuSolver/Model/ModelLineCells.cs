namespace SudokuSolver.Model
{
    /// <summary>
    /// Класс для упрощенной работы с линией.
    /// </summary>
    internal class ModelLineCells : ICheckable
    {
        /// <summary>
        /// Маленькие ячейки.
        /// </summary>
        private ModelCell[,] modelCells = new ModelCell[9, 9];
        /// <summary>
        /// Индекс линии.
        /// </summary>
        public int lineIndex { get; set; }
        /// <summary>
        /// Линия направлена вертикально?
        /// </summary>
        public bool isVertical { get; set; }
        /// <summary>
        /// Объект для упрощенной работы с линией.
        /// </summary>
        public ModelLineCells(ModelCell[,] modelCells)
        {
            this.modelCells = modelCells;
        }
        /// <summary>
        /// Получить ячейку по индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private ModelCell GetByIndex(int index)
        {
            if (this.isVertical)
            {
                return this.modelCells[index, this.lineIndex];
            }
            else
            {
                return this.modelCells[this.lineIndex, index];
            }
        }

        /// <summary>
        /// В линии все заполнено.
        /// </summary>
        public bool IsFullLine()
        {
            int index = this.lineIndex;
            for (int i = 0; i < 9; i++)
            {
                if (GetByIndex(i).isEmpty)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Получить количество пустых ячеек.
        /// </summary>
        /// <returns></returns>
        public int GetEmptyCellsCount()
        {
            int count = 0;
            int index = this.lineIndex;
            for (int i = 0; i < 9; i++)
            {
                if (GetByIndex(i).isEmpty)
                    ++count;
            }

            return count;
        }
        public ModelCell[] GetAllEmptyCells()
        {
            List<ModelCell> cells = new List<ModelCell>();
            for (int i = 0; i < 9; i++)
            {
                ModelCell cell = GetByIndex(i);
                if (cell.isEmpty)
                {
                    cells.Add(cell);
                }
            }
            return cells.ToArray();
        }
        public bool IsCanSet(int value)
        {
            for (int i = 0; i < 9; i++)
            {
                if (GetByIndex(i).value == value)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Попытаться задать последнюю пустую ячейку.
        /// </summary>
        /// <returns>Ячейка не будет задана, если она не последнаяя, и вернется false.</returns>
        /// <exception cref="Exception"></exception>
        public bool TrySetLastCell()
        {
            int count = GetEmptyCellsCount();
            if (count > 1)
            {
                return false;
            }

            int lastNumber = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9;
            ModelCell lastCell = null;
            if (!IsFullLine())
            {
                for (int i = 0; i < 9; i++)
                {
                    ModelCell modelCell = GetByIndex(i);
                    if (modelCell.isEmpty)
                        lastCell = modelCell;
                    else
                        lastNumber -= modelCell.value;
                }
            }

            if (lastCell != null)
                lastCell.value = lastNumber;
            else
                throw new Exception("Не нашел последнюю ячейку!");

            return true;
        }

        #region Проверка правильности линии.

        private List<int> possibleValuesPrivate = new List<int>();
        public List<int> possibleValues
        {
            get
            {
                this.possibleValuesPrivate.Clear();
                for (int i = 1; i < 10; i++)
                {
                    if(IsCanSet(i))
                        this.possibleValuesPrivate.Add(i);
                }
                return this.possibleValuesPrivate;
            }
        }

        /// <summary>
        /// Набор значений, который может быть в линии.
        /// </summary>
        private HashSet<int> valuesInLine = new HashSet<int>(9);
        /// <summary>
        /// В линии нет повторяющихся значений.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            this.valuesInLine.Clear();
            ModelCell cell = null;
            int value = 0;
            for (int i = 0; i < 9; i++)
            {
                cell = GetByIndex(i);
                if (!cell.isEmpty)
                {
                    value = cell.value;
                    if (this.valuesInLine.Contains(value))
                    {
                        return false;
                    }
                    else
                    {
                        this.valuesInLine.Add(value);
                    }
                }
            }
            return true;
        }

        #endregion Проверка правильности линии.

    }
}