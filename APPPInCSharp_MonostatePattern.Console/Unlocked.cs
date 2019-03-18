namespace APPPInCSharp_MonostatePattern.Console
{
    internal class Unlocked : Turnstile
    {
        public override void Coin()
        {
            Refund();
        }

        public override void Pass()
        {
            Lock(true);
            itsState = LOCKED;
        }
    }
}