namespace CWM.StoreManager.Application.Constants.CacheKeys
{
    public static class BrandCacheKeys
    {
        public static string ListKey => "BrandList";

        public static string GetKey(int typeId) => $"Brand-{typeId}";
    }
}