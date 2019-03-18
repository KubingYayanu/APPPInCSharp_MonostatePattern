using APPPInCSharp_MonostatePattern.Console;
using NUnit.Framework;

namespace APPPInCSharp_MonostatePattern.UnitTests
{
    [TestFixture]
    public class TurnstileTests
    {
        private Turnstile t;

        [SetUp]
        public void SetUp()
        {
            t = new Turnstile();
            t.Reset();
        }

        #region Init

        [Test]
        public void Init_IsLocked_ReturnTrue()
        {
            Assert.That(t.Locked(), Is.True);
        }

        [Test]
        public void Init_IsAlarm_ReturnFalse()
        {
            Assert.That(t.Alarm(), Is.False);
        }

        #endregion Init

        #region Coin

        [Test]
        public void Coin_OtherInstanceIsLocked_ReturnFalse()
        {
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Locked(), Is.False);
        }

        [Test]
        public void Coin_OtherInstanceIsAlarm_ReturnFalse()
        {
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Alarm(), Is.False);
        }

        [Test]
        public void Coin_OtherInstanceCoins_Get1Coin()
        {
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(1, Is.EqualTo(t1.Coins));
        }

        #endregion Coin

        #region CoinAndPass

        [Test]
        public void CoinAndPass_OtherInstanceIsLocked_ReturnTrue()
        {
            t.Coin();
            t.Pass();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Locked(), Is.True);
        }

        [Test]
        public void CoinAndPass_OtherInstanceIsAlarm_ReturnFalse()
        {
            t.Coin();
            t.Pass();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Alarm(), Is.False);
        }

        [Test]
        public void CoinAndPass_OtherInstanceCoins_Get1Coin()
        {
            t.Coin();
            t.Pass();
            Turnstile t1 = new Turnstile();

            Assert.That(1, Is.EqualTo(t1.Coins), "coins");
        }

        #endregion CoinAndPass

        #region TwoCoins

        [Test]
        public void TwoCoins_OtherInstanceIsLocked_ReturnFalse()
        {
            t.Coin();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Locked(), Is.False, "unlocked");
        }

        [Test]
        public void TwoCoins_OtherInstanceIsAlarm_ReturnFalse()
        {
            t.Coin();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Alarm(), Is.False);
        }

        [Test]
        public void TwoCoins_OtherInstanceCoins_Get1Coin()
        {
            t.Coin();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(1, Is.EqualTo(t1.Coins), "coins");
        }

        [Test]
        public void TwoCoins_OtherInstanceRefunds_Get1Refund()
        {
            t.Coin();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(1, Is.EqualTo(t1.Refunds), "refunds");
        }

        #endregion TwoCoins

        #region Pass

        [Test]
        public void Pass_OtherInstanceIsAlarm_ReturnTrue()
        {
            t.Pass();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Alarm(), Is.True);
        }

        [Test]
        public void Pass_OtherInstanceIsLocked_ReturnTrue()
        {
            t.Pass();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Locked(), Is.True);
        }

        #endregion Pass

        #region CancelAlarm

        [Test]
        public void CancelAlarm_OtherInstanceIsAlarm_ReturnFalse()
        {
            t.Pass();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Alarm(), Is.False, "alarm");
        }

        [Test]
        public void CancelAlarm_OtherInstanceIsLocked_ReturnFalse()
        {
            t.Pass();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(t1.Alarm(), Is.False, "locked");
        }

        [Test]
        public void CancelAlarm_OtherInstanceCoins_Get1Coin()
        {
            t.Pass();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(1, Is.EqualTo(t1.Coins), "coins");
        }

        [Test]
        public void CancelAlarm_OtherInstanceRefunds_NoRefund()
        {
            t.Pass();
            t.Coin();
            Turnstile t1 = new Turnstile();

            Assert.That(0, Is.EqualTo(t1.Refunds), "refunds");
        }

        #endregion CancelAlarm
    }
}