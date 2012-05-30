using System.Drawing;
using NUnit.Framework;

namespace code_kata.MagnetoEffect.Test
{
    [TestFixture]
    public class MagnetoEffectTest
    {
        //http://sites.google.com/site/tddproblems/all-problems-1/magneto-effect

        [Test]
        public void ShouldCheckHasMagnetPoint()
        {
            var magnetoEffect = new MagnetoEffect(5);
            magnetoEffect.AddMagnetPoint(new Point(50, 50));

            Assert.IsTrue(magnetoEffect.HasMagnetPoint(new Point(50, 51)));
            Assert.IsTrue(magnetoEffect.HasMagnetPoint(new Point(50, 55)));
            Assert.IsFalse(magnetoEffect.HasMagnetPoint(new Point(50, 56)));
            Assert.IsFalse(magnetoEffect.HasMagnetPoint(new Point(54, 54)));
            Assert.IsTrue(magnetoEffect.HasMagnetPoint(new Point(53, 54)));
        }

        [Test] 
        public void FindBestAvailableMagnetPoint_ShouldReturnItself_WhenNoMagnetPointIsInRadius()
        {

            var magnetoEffect = new MagnetoEffect(5);
            magnetoEffect.AddMagnetPoint(new Point(50, 50));

            var point = new Point(100, 50);
            Assert.AreEqual(point, magnetoEffect.FindBestAvailableMagnetPoint(point));
            
        }
        
        [Test] 
        public void FindBestAvailableMagnetPoint_ShouldReturnShortestDistance_WhenOneMagnetPointsIsInRadius()
        {

            var magnetoEffect = new MagnetoEffect(5);
            magnetoEffect.AddMagnetPoint(new Point(50, 50));
            magnetoEffect.AddMagnetPoint(new Point(100, 50));

            var point = new Point(101, 48);
            Assert.AreEqual(new Point(100, 50), magnetoEffect.FindBestAvailableMagnetPoint(point));
            
        }        
        
        [Test] 
        public void FindBestAvailableMagnetPoint_ShouldReturnShortestDistance_WhenMoreThanOneMagnetPointsAreInRadius()
        {

            var magnetoEffect = new MagnetoEffect(5);
            magnetoEffect.AddMagnetPoint(new Point(50, 50));
            magnetoEffect.AddMagnetPoint(new Point(51, 51));

            var point = new Point(51, 52);
            Assert.AreEqual(new Point(51, 51), magnetoEffect.FindBestAvailableMagnetPoint(point));
            
        }

    }
}