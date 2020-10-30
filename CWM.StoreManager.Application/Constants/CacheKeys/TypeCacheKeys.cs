namespace CWM.StoreManager.Application.Constants.CacheKeys
{
    public static class TypeCacheKeys
    {
        public static string ListKey => "TypeList";

        public static string GetKey(int typeId) => $"Type-{typeId}";
    }
}