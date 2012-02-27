namespace Komodo.DatabaseBuilder
{
    public class StringCollection : System.Collections.Specialized.StringCollection
    {
        public string[] ToArray()
        {
            var result = new string[Count];
            CopyTo(result,0);
            return result;
        }
    }
}
