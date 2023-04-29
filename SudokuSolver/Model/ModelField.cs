namespace SudokuSolver.Model
{
    internal class ModelField
    {
        /// <summary>
        /// Большие ячейки.
        /// </summary>
        private ModelBigCell[,] modelBigCells = new ModelBigCell[3, 3];
        /// <summary>
        /// Маленькие ячейки.
        /// </summary>
        private ModelCell[,] modelCells = new ModelCell[9, 9];
        private ModelLineCells modelLineCells;
        public ModelField(int[,] intCells)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Создать и задачть знасчение
                    ModelCell newCell = new ModelCell(intCells[i, j], i, j);

                    //Добавить в общий массив
                    this.modelCells[i, j] = newCell;

                    //Добавить в большую ячейку.
                    int bigCellIndexX = i / 3;
                    int bigCellIndexY = j / 3;
                    if (this.modelBigCells[bigCellIndexX, bigCellIndexY] == null)
                    {
                        this.modelBigCells[bigCellIndexX, bigCellIndexY] = new ModelBigCell();
                    }
                    bool result = this.modelBigCells[bigCellIndexX, bigCellIndexY].
                        TrySetCell(newCell, i % 3, j % 3);

                    if (result == false)
                    {
                        throw new Exception("Ячейка не добавилась!");
                    }
                }
            }
            this.modelLineCells = new ModelLineCells(this.modelCells);
        }

        #region Проверки

        /// <summary>
        /// Все поле заполнено.
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            foreach (ModelBigCell bigCell in this.modelBigCells)
            {
                if(!bigCell.IsFull())
                    return false;
            }

            this.modelLineCells.isVertical = true;
            for (int i = 0; i < 9; i++)
            {
                this.modelLineCells.lineIndex = i;
                if (!this.modelLineCells.IsFullLine())
                    return false;
            }

            return true;
        }

        #endregion Проверки


        /// <summary>
        /// Ячейки неизменные делаются
        /// </summary>
        private void ClearIsChange()
        {
            foreach(ModelCell cell in this.modelCells)
                {
                cell.ClearIsChange();
            }
        }
        /// <summary>
        /// Проверить, изменилось ли что-то
        /// </summary>
        /// <returns></returns>
        private bool IsAnyChange()
        {
            foreach (ModelCell cell in this.modelCells)
            {
                if (cell.isChanged)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Выполнит расчет, куда можно какие числа положить.
        /// </summary>
        public void Culculate()
        {
            while (!IsFull())
            {
                //Ячейки неизменные делаются
                ClearIsChange();

                //Проверка больших ячеек
                foreach (ModelBigCell bigCell in this.modelBigCells)
                {
                    if (!bigCell.IsFull())
                    {
                        if (bigCell.GetEmptyCellsCount() == 1)
                        {
                            bigCell.TrySetLastCell();
                        }
                    }
                }
                //Проверка линий
                for (int i = 0; i < 9; i++)
                {
                    this.modelLineCells.isVertical = true;
                    this.modelLineCells.lineIndex = i;
                    if (!modelLineCells.IsFullLine())
                        this.modelLineCells.TrySetLastCell();

                    this.modelLineCells.isVertical = false;
                    if (!modelLineCells.IsFullLine())
                        this.modelLineCells.TrySetLastCell();
                }

                if (!IsAnyChange())
                {
                    ModelCell cellForNumberSet = null;//Кэшируем тут, чтобы не объявлять заново каждый раз
                    int cellForNumnerSetCount = 0;//Кэшируем тут, чтобы не объявлять заново каждый раз
                    for (int i = 0; i < 9; i++)//Просмотреть все числа
                    {
                        //Просмотреть все большие ячейки
                        foreach (ModelBigCell bigCell in this.modelBigCells)
                        {
                            if (bigCell.IsFull())
                                continue;

                            //Обнулить счетчик и найти, во сколько пустых ячеек можно положить нынешнее число
                            cellForNumnerSetCount = 0;
                            if (bigCell.IsCanSet(i))
                            {
                                ModelCell[] emptyModelCells = bigCell.GetAllEmptyCells();
                                //Проверить, "разрешат ли" линии положить число в эти ячейки
                                foreach(ModelCell cell in emptyModelCells)
                                {
                                    this.modelLineCells.isVertical = true;
                                    this.modelLineCells.lineIndex = cell.address.y;
                                    if (this.modelLineCells.IsCanSet(i))
                                    {
                                        this.modelLineCells.isVertical = false;
                                        this.modelLineCells.lineIndex = cell.address.x;
                                        if (this.modelLineCells.IsCanSet(i))
                                        {
                                            //Запомнить самую ячейку и увеличить счетчик.
                                            cellForNumberSet = cell;
                                            ++cellForNumnerSetCount;
                                        }
                                    }

                                }
                            }

                            if (cellForNumnerSetCount == 1)
                            {
                                //Если счетчик больше 0, то точно не будет null,
                                //а если только одна такая ячейка, то число может быть только в ней,
                                //значит в нее его и положить.
                                cellForNumberSet.value = i;
                            }
                        }
                        for (int j = 0; j < 9; j++)//большие ячейки
                        {
                            //Проверить линии для пустых ячеек
                        }
                    }
                }

                if (!IsAnyChange())
                    break;
            }
        }

        /// <summary>
        /// Получить массив чисел, которые записаны в ячейках.
        /// </summary>
        /// <returns></returns>
        public int[,] GetResults()
        {
            int[,] intCells = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    intCells[i, j] = this.modelCells[i, j].value;
                }
            }
            return intCells;
        }
    }
}
