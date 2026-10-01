namespace WarehouseLibrary
{
    public class Product
    {
        public event Action<string, int, string, int> CountOfProduct;
        public event Action<string, int, string> Inventerization;

        public string Name { get; set; }
        public int Count { get; private set; }
        public int MinCount { get; set; }

        public Product(string name, int count, int minCount)
        {
            Name = name;
            Count = count;
            MinCount = minCount;
        }

        public void Sell(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                CountOfProduct?.Invoke(Name, count, "Продано", Count);
            }
            else
            {
                CountOfProduct?.Invoke(Name, count - Count, "Не хватает", Count);
            }
            if (Count < MinCount)
            {
                CountOfProduct?.Invoke(Name, MinCount, "Товар заканчивается. Стало меньше", Count);
            }
        }

        public void Add(int count)
        {
            Count += count;
            CountOfProduct?.Invoke(Name, count, "Добавлено", Count);
        }

        public void Remove(int count)
        {
            Count -= count;
            CountOfProduct?.Invoke(Name, count, "Списано", Count);
        }

        public void Invent(int count)
        {
            if (Count == count)
            {
                Inventerization?.Invoke(Name, count, "Всё совпало.");
            }
            else
            {
                Count = count;
                Inventerization?.Invoke(Name, count, "Количество не совпало.");
            }
        }
    }
}