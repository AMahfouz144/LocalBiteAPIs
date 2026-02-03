namespace Common.Models
{
    public class LookupDto<TKey, TValue>
    {
        public LookupDto() { }
        public LookupDto(TKey key, TValue value) 
        {
            Key = key;
            Value = value;
        }
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}