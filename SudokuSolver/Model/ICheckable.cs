namespace SudokuSolver.Model
{
    internal interface ICheckable
    {
        /// <summary>
        /// Можно ли установить указанное значение?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsCanSet(int value);
        /// <summary>
        /// Получить массив пустых ячеек.
        /// </summary>
        /// <returns></returns>
        ModelCell[] GetAllEmptyCells();
    }
}
