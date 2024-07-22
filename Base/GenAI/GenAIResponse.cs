namespace GenAI
{
    public class GenAIResponse<T>
    {
        public T Data { get; set; }
    }
    public class DynamicResponse
    {
        public virtual dynamic GetSampleInstance()
        {
            return null;
        }
    }
}
