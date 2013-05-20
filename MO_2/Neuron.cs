
namespace MO_2
{
    /// <summary>
    /// Один единственный персептрон, расчитанный на работу с 2д входными данными.
    /// </summary>
    class Neuron
    {
        /// <summary>
        /// Результат работы нейрона.
        /// </summary>
        private float sum;

        /// <summary>
        /// Входные значения нейрона.
        /// </summary>
        private int[] input;

        /// <summary>
        /// Веса нейрона.
        /// </summary>
        private float[] weights;

        /// <summary>
        /// Промежуточные значения нейрона.
        /// </summary>
        private float[] values;

        /// <summary>
        /// Пороговое значение для активации нейрона.
        /// </summary>
        private float porog;

        /// <summary>
        /// Количество входов.
        /// </summary>
        private int sizeX;

        /// <summary>
        /// Возвращает массив весов.
        /// </summary>
        /// <returns>Массив весов.</returns>
        public float[] GetWeights()
        {
            return this.weights;
        }

        /// <summary>
        /// Определяет веса нейрона на основе информации из файла
        /// </summary>
        /// <param name="line">строка текста из файла</param>
        public void SetWeights(string line)
        {
            for (int i = 0; i < this.sizeX; i++)
            {
                string s = line.Substring(0, line.IndexOf(" "));
                line = line.Remove(0, line.IndexOf(" ") + 1);
                this.weights[i] = float.Parse(s);
            }
        }


        /// <summary>
        /// Задаёт значение на определённом синапсе нейрона.
        /// </summary>
        /// <param name="value">Принимаемое значение</param>
        /// <param name="X">Инднекс синапса</param>
        public void SetInputAtX(int value, int X)
        {
            if (X < this.sizeX)
                this.input[X] = value;
        }


        /// <summary>
        /// Отчищает входы нейрона от информации.
        /// </summary>
        public void Reset()
        {
            this.sum = 0;
            for (int i = 0; i < this.sizeX; i++)
                this.input[i] = 0;
        }


        public Neuron(int sizeX)
        {
            this.sizeX = sizeX;
            this.values = new float[this.sizeX];
            this.weights = new float[this.sizeX];
            this.input = new int[this.sizeX];
        }

        public float Sigma()
        {
            int sum = 0;
            for (int i = 0; i < this.sizeX; i++)
                sum += this.input[i] * (int)this.weights[i];
            return (1/(1+(float)System.Math.Exp(-sum)));
        }
    }
}
