namespace KursovoyZash
{
    public static class StringExtensionsBase
    {
        public static IEnumerable<string> Split(this string s, int chunkSize)
        {
            int chunkCount = s.Length / chunkSize;
            for (int i = 0; i < chunkCount; i++)
                yield return s.Substring(i * chunkSize, chunkSize);

            if (chunkSize * chunkCount < s.Length)
                yield return s.Substring(chunkSize * chunkCount);
        }
    }
}