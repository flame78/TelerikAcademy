using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleRepeller : Particle
    {
        private int repellerRadius;

        private static int Cols = ParticleSystem.Program.Cols;
        private static int Rows = ParticleSystem.Program.Rows;

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed)
            : base(position, speed) { }

        protected override void Move()
        {
            var result = this.Position + this.Speed;
            if (result.Col > Cols) this.Speed = new MatrixCoords(this.Speed.Row, -this.Speed.Col);
            if (result.Row > Rows) this.Speed = new MatrixCoords(-this.Speed.Row, this.Speed.Col);
            if (result.Col < 0) this.Speed = new MatrixCoords(this.Speed.Row, -this.Speed.Col);
            if (result.Row < 0) this.Speed = new MatrixCoords(-this.Speed.Row, this.Speed.Col);
            this.Position = result;

        }
        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }
    }
}
