namespace APPPInCSharp_MonostatePattern.Console
{
    public class Monostate
    {
        private static int itsX;

        public int X
        {
            get { return itsX; }
            set { itsX = value; }
        }
    }
}