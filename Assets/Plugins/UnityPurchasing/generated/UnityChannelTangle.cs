#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class UnityChannelTangle
    {
        private static byte[] data = System.Convert.FromBase64String("2GmGuksLGtDif5I1Yh1x+BfkRpfJSkRLe8lKQUnJSkpL58nHlGOoN7fUZDi847JalXiZHXYw/rBXZd/rcehYkDSqE7nO1uQwpgA3m/HS+HyDekHF0JB+yEqi2cVsEjuKNTs8/6nNTSEfYtlI/dYUjNMAKvrzRKLu6idmgyibUnPQmRaXABilRLnLz8Z8kXsDpgu0uDccjBKMFETJWoTqIAlfiaDj6mRiH8jMf0E5FSgsEowAbiQIJuaopXeSgkBq3UJOZk9tnhPtDpr8DE4vTCaHUKnIXlhFU9a8nibRHqD5dzzPOhnyVwmhvl/Oi8ule8lKaXtGTUJhzQPNvEZKSkpOS0gE90/80W5SNQMQS0dwOUOjdX+tR9/2nbxhnsM+zElISktK");
        private static int[] order = new int[] { 11,1,2,7,9,7,6,10,10,12,13,12,12,13,14 };
        private static int key = 75;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
