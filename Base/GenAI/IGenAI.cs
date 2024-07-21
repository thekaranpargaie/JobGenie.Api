namespace GenAI
{
    public interface IGenAI
    {
        /// <summary>
        /// GenerateJsonResponse methods takes a request and returns a Object Response for that request.
        /// </summary>
        /// <typeparam name="TResponse">The Kind Of Object You Want As Your Response</typeparam>
        /// <param name="request">Request with proper requirement description that you need.</param>
        /// <returns>An Object Response Corresponding To Your Request</returns>
        public Task<T> GenerateResponseObject<T>(string request) where T : DynamicResponse, new();
    }
}
