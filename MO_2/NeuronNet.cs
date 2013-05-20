
namespace MO_2
{
    /// <summary>
    /// Сеть из N простых персептронов.
    /// </summary>
    class NeuronNet
    {
        /// <summary>
        /// Сеть из нейронов.
        /// </summary>
        private Neuron[] levelOne;
        private Neuron levelTwo;

        /// <summary>
        /// Количество нейронов.
        /// </summary>
        private int size;

        /// <summary>
        ///  Количетво входов.
        /// </summary>
        private int sizeX;

        /// <summary>
        /// Результат работы нейронной сети в виде массива.
        /// </summary>
        private bool[] results;


        /// <summary>
        /// Подготавливает настройки сети для записи в файл
        /// </summary>
        /// <returns>Возвращает строковое представление информации хранимой в сети</returns>
        public string[] SetReadyToWrite()
        {
            string[] lines = new string[3 + this.levelOne.Length];
            lines[0] = this.size.ToString();
            lines[1] = this.sizeX.ToString();
            for (int i = 3; i < lines.Length; i++)
            {
                lines[i] = "";
                float[] tmp = this.levelOne[i - 3].GetWeights();
                for (int j = 0; j < this.sizeX; j++)
                        lines[i] += tmp[j].ToString() + " ";
            }
            return lines;
        }


        public NeuronNet(int sizeX, int size)
        {
            this.sizeX = sizeX;
            this.size = size;
            this.levelOne = new Neuron[this.sizeX];
            for (int i = 0; i < this.sizeX; i++)
                this.levelOne[i] = new Neuron();
            this.levelTwo = new Neuron(this.sizeX);
        }

        /// <summary>
        /// Вводт информацию о изображении в сеть
        /// </summary>
        /// <param name="image">Информация о изображении</param>
        public void SetInputData(int[] image)
        {
            for (int k = 0; k < this.size; k++)
                for (int i = 0; i < this.sizeX; i++)
                        this.levelOne[k].SetInputAtX(image[i], i);
        }

        /// <summary>
        /// Сбрасывает все входы и результаты. Веса не меняются.
        /// </summary>
        public void Reset()
        {
            for (int k = 0; k < this.size; k++)
            {
                this.levelOne[k].Reset();
                this.results[k] = false;
            }
        }
    }
}
