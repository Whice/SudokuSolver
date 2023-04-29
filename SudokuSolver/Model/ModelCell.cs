
namespace SudokuSolver.Model
{
    /// <summary>
    /// Ячека.
    /// </summary>
    internal class ModelCell
    {
        /// <summary>
        /// Адрес ячейки во всем поле.
        /// </summary>
        public CellAddress address { get; private set; }
        public ModelCell(int value, int x, int y)
        {
            if (value > -1 && value < 10)
            {
                this.valuePrivate = value;
                this.address = new CellAddress(x, y);
            }
            else
            {
                throw new Exception("Value is validate!");
            }
        }
        /// <summary>
        /// Ячейка изменилась.
        /// </summary>
        public bool isChanged { get; private set; }
        /// <summary>
        /// Сделать неизмененной.
        /// </summary>
        public void ClearIsChange()
        {
            this.isChanged = false;
        }
        /// <summary>
        /// Значение.
        /// </br> Если 0, то пустая.
        /// </summary>
        private int valuePrivate = 0;
        /// <summary>
        /// Значение с 1 по 9.
        /// </summary>
        public int value
        {
            get
            { 
                return valuePrivate;
            }
            set
            {
                if (value > 0 && value < 10 && value != this.valuePrivate)
                {
                    this.isChanged = true;
                    this.valuePrivate = value;
                }
                else
                {
                    throw new Exception("Value is no valide!");
                }
            }
        }
        /// <summary>
        /// Ячека пуста.
        /// </summary>
        public bool isEmpty
        {
            get => valuePrivate == 0;
        }
        /// <summary>
        /// Очистить ячейку.
        /// </summary>
        public void Clear()
        {
            valuePrivate = 0;
        }

        /// <summary>
        /// Проверить ячейки на равенство.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsEqual(ModelCell other)
        {
            if (other == null)
                return false;

            if (this.valuePrivate == 0 && other.valuePrivate == 0)
            {
                return false;
            }

            return this.valuePrivate == other.valuePrivate;
        }
        /// <summary>
        /// Равны ли по адресам ячейки?
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsAddressEqual(ModelCell other)
        {
            if(other ==null) return false;

            return this.address.IsEqual(other.address);
        }
    }
}
