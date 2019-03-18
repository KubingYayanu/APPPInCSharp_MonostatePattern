namespace APPPInCSharp_MonostatePattern.Console
{
    internal class Locked : Turnstile
    {
        public override void Coin()
        {
            itsState = UNLOCKED;
            Lock(false);
            Alarm(false);
            Deposit();
        }

        public override void Pass()
        {
            Alarm(true);
        }
    }
}