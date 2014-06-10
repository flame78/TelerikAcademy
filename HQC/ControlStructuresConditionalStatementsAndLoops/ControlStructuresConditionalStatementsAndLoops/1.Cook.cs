namespace ControlStructuresConditionalStatementsAndLoops
{
    using System;

    public interface IVegetable
    {
        // ......
        bool IsGood { get; set; }

        bool IsPeeled { get; set; }
    }

    public class Chef
    {
        public void Cook(Potato potato = null)
        {
            if (potato == null)
            {
                potato = this.GetPotato();
            }

            Carrot carrot = this.GetCarrot();
            Bowl bowl;

            this.Peel(potato);
            this.Peel(carrot);
            bowl = this.GetBowl();
            this.Cut(potato);
            this.Cut(carrot);
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private void Peel(IVegetable product)
        {
            throw new NotImplementedException();
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            // ...
            return new Carrot();
        }

        private void Cut(IVegetable product)
        {
            // ...
        }

        private Potato GetPotato()
        {
            // ...
            return new Potato();
        }
    }

    public class Bowl
    {
        internal void Add(IVegetable product)
        {
            // .....
        }
    }

    public class Carrot : IVegetable
    {
        // ......
        public bool IsGood
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsPeeled
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Potato : IVegetable
    {
        // ......
        public bool IsGood
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsPeeled
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}