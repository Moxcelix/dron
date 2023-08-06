namespace Core.Utilities
{
    [System.Serializable]
    public class ArrayWrapper<T>
    {
        public T[] array;

        public ArrayWrapper(T[] array)
        {
            this.array = array;
        }
    }
}