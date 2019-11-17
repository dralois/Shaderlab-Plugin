namespace ShaderlabVS
{
    public class ShaderlabVSContext
    {
        private static ShaderlabVSContext sContext;

        public static ShaderlabVSContext Context { get { return sContext; } }

        public static ShaderlabVSContext Push()
        {
            return sContext;
        }

        public static void Pop()
        {
            sContext = null;
        }
    }
}
