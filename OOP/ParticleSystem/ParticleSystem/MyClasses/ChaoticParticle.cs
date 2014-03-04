using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ChaoticParticle : Particle
    {
        private const int MaxAcceleration = 1;
        protected static Random MyRandom = new Random();
        private static int Cols = ParticleSystem.Program.Cols;
        private static int Rows = ParticleSystem.Program.Rows;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed) { }


        override public IEnumerable<Particle> Update()
        {
            base.Speed = this.RandomSpeed();
            Move();

            return new List<Particle>();
        }

        protected override void Move()
        {
            var result = this.Position + this.Speed;
            if (result.Col > Cols) result.Col= Cols-1;
            if (result.Row > Rows) result.Row = Rows-1;
            if (result.Col < 0) result.Col = 1;
            if (result.Row < 0) result.Row = 1;
            this.Position = result;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'H' } };
        }
       
        protected virtual MatrixCoords RandomSpeed()
        {
            MatrixCoords result = new MatrixCoords();
            result.Col = MyRandom.Next(-MaxAcceleration, MaxAcceleration+1);
            result.Row = MyRandom.Next(-MaxAcceleration, MaxAcceleration+1);

            return result;
        }
    }
}
