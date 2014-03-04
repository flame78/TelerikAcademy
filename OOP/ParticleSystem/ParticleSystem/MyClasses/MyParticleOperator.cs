using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class MyParticleOperator : AdvancedParticleOperator
    {
        private List<Particle> particles = new List<Particle>();
        private List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        
        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var repellerCandidate = p as ParticleRepeller;
            if (repellerCandidate != null) repellers.Add(repellerCandidate);
            else particles.Add(p);
			
            return base.OperateOn(p);
        }
        public override void TickEnded()
        {
            foreach (var item in this.repellers)
            {
                for (int i = 0; i < this.particles.Count(); i++)
                {
                    if (item.Position.Equals(this.particles[i].Position))
                    {
                        this.particles[i].Speed = item.Speed;
                        item.Speed = new MatrixCoords(0, 0) - item.Speed;
                    }
                }
            }

            this.repellers.Clear();
            this.particles.Clear();
            base.TickEnded();
        }
        
    }
}
