using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ChickenParticle : ChaoticParticle
    {
        private const int maxCycle = 30;
        private bool newChicken = false;
        private int stopCycle = MyRandom.Next(maxCycle) + 1;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed) { }
        protected override MatrixCoords RandomSpeed()
        {
            if (this.stopCycle>0) this.stopCycle--;
            if (this.stopCycle == 0) this.stopCycle = MyRandom.Next(maxCycle) - maxCycle-1;
            if (this.stopCycle < 0)
            {
                this.stopCycle++;
                if (this.stopCycle==0)
                {
                    this.stopCycle = MyRandom.Next(maxCycle) + 1;
                    this.newChicken = true;
                }
                return new MatrixCoords(0, 0);
            }
            return base.RandomSpeed();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'C' } };
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.newChicken==true)
            {
                this.newChicken=false;
                return new List<Particle>() { new ChickenParticle(this.Position, this.RandomSpeed()) };
            }
            return base.Update();
        }
    }
}
