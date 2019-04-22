#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("T2ffZhMGhrLgD6nRfTDpm9AS9QX3XoIxrfw4hzK6qK/SPfjhe4YAEfquawMgoi+Bz+o50XJuJgWWX9KiJqWrpJQmpa6mJqWlpBaeWbPn9fAUXcz0ErukO2R94YOq2UiqIJCd9FWBvln7hULqlEfHTmgVcBxMO8EmaeymUirNIgvO3+5DQQGpOxOId8KZAfNLoMBwaL0HNl4+9W7c4hzgTdY6zoXVawASIW5uCigRNNO/UOrbEcAWNEg83jpmFLpGJ4Uf0yg3fq7BikXzAVCr4Iz2sEtr6TA5ZD8w1HozO3CPNezbJ9YX7r2AxrwFWNO6D93vurEXpUDO0GNQzCBAAh3PaHaUJqWGlKmirY4i7CJTqaWlpaGkp0GyRyEfo1lYO6anpaSl");
        private static int[] order = new int[] { 12,13,9,13,4,9,7,11,10,10,11,11,13,13,14 };
        private static int key = 164;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
