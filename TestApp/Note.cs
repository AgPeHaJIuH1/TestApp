namespace TestApp
{
    public class Note
    {
        public Note(int baseValue)
        {
            BaseValue = baseValue;
            Value = 1 / (decimal)baseValue;
        }
        public int BaseValue { get; }
        public decimal Value { get; }
    }
}