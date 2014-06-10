namespace ControlStructuresConditionalStatementsAndLoops
{
    public static class RefactorIf
    {
        public void FirstIf()
        {
            Potato potato = new Potato();
            Chef chef = new Chef();

            // ... 
            if (potato != null && this.IsGoodForCooking(potato))
            {
                chef.Cook(potato);
            }
        }

        public void SecondIf()
        {
            const int MIN_X = int.MinValue;
            const int MAX_X = int.MaxValue;
            const int MIN_Y = int.MinValue;
            const int MAX_Y = int.MaxValue;

            int x = 0;
            int y = 0;

            bool shouldVisitCell = true;

            // ..........
            if (MIN_X <= x && x <= MAX_X &&
                MIN_Y <= y && y <= MAX_Y &&
                shouldVisitCell)
            {
                this.VisitCell();
            }
        }

        private bool IsGoodForCooking(IVegetable product)
        {
            if (product.IsPeeled && product.IsGood)
            {
                return true;
            }

            return false;
        }

        private void VisitCell()
        {
            // ...
        }
    }
}