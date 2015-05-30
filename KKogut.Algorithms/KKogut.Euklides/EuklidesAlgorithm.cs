namespace KKogut.Euklides
{
    public static class EuklidesAlgorithm
    {
        public static long GCD(long a, long b)
        {
            if (a == 0) return b;

            while (b != 0)
            {
                var c = a % b;
                a = b;
                b = c;
            }

            return a;
        }
    }
}
