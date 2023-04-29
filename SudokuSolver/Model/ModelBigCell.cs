
namespace SudokuSolver.Model
{
    /// <summary>
    /// Большая ячйка состоит из 9 ячеек.
    /// </summary>
    internal class ModelBigCell : ICheckable
    {
        /// <summary>
        /// Маленькие ячейки.
        /// </summary>
        private ModelCell[,] modelCells = new ModelCell[3, 3];
        /// <summary>
        /// Есть ли такое значение есть в большой ячейке.
        /// </summary>
        /// <param name="cellForCheck"></param>
        /// <returns></returns>
        public bool IsHave(ModelCell cellForCheck)
        {
            if (this.modelCells == null || this.modelCells.Length == 0)
                return false;
            foreach (ModelCell cell in this.modelCells)
            {
                if (cell == null)
                {
                    return false;
                }
                if (cell.IsEqual(cellForCheck))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Попробовать добавить ячейку.
        /// Если с таким значением уже есть, то доабвление не пройдет
        /// и будет возвращен false.
        /// </summary>
        /// <param name="newCell"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool TrySetCell(ModelCell newCell, int x, int y)
        {
            if (IsHave(newCell))
            {
                return false;
            }
            this.modelCells[x, y] = newCell;

            return true;
        }
        /// <summary>
        /// Все значения выставлены.
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            foreach (ModelCell cell in this.modelCells)
            {
                if (cell.isEmpty)
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
            foreach (ModelCell cell in this.modelCells)
            {
                if (cell.isEmpty)
                    count++;
            }
            return count;
        }
        public ModelCell[] GetAllEmptyCells()
        {
            List<ModelCell> cells = new List<ModelCell>();
            foreach(ModelCell cell in this.modelCells)
            {
                if (cell.isEmpty)
                {
                    cells.Add(cell);
                }
            }
            return cells.ToArray();
        }
        public bool IsCanSet(int value)
        {
            foreach (ModelCell cell in this.modelCells)
            {
                if (cell.value == value)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Попытаться задать последнюю пустую ячейку.
        /// </summary>
        /// <returns>Ячейка не будет задана, если она не последнаяя, и вернется false.</returns>
        public bool TrySetLastCell()
        {
            if (GetEmptyCellsCount() > 1)
            {
                return false;
            }

            int lastNumber = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9;
            ModelCell lastCell = null;
            foreach (ModelCell cell in this.modelCells)
            {
                if (!cell.isEmpty)
                    lastNumber -= cell.value;
                else
                    lastCell = cell;
            }

            if (lastCell != null)
                lastCell.value = lastNumber;
            else
                throw new Exception("Не нашел последнюю ячейку!");

            return true;
        }
    }
}
