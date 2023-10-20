namespace GeeksProject02.Models
{
    public class GenerateId
    {
        private static int nextId = 1;

        public static int GenerateUniqueId()
        {
            return nextId++;
        }
    }
}

