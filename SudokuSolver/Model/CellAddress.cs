namespace SudokuSolver.Model
{
    /// <summary>
    /// Адрес ячейки на всем поле.
    /// </summary>
    internal class CellAddress
    {
        public CellAddress(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Адрес по горизонтали.
        /// </summary>
        public int x { get; }
        /// <summary>
        /// Адрес по вертикали.
        /// </summary>
        public int y { get; }
        /// <summary>
        /// Адреса равны?
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsEqual(CellAddress other)
        {
            if(other == null) return false;
            return this.x == other.x && this.y == other.y;
        }
    }
}
