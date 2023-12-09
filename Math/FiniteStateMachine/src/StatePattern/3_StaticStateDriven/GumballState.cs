namespace Ver3_StaticStateDriven
{
    public interface GumballState {
        public void InsertCoin(GumballMachine gumballMachine);
        public void EjectCoin(GumballMachine gumballMachine);
        public void TurnCrank(GumballMachine gumballMachine);
        public void Dispense(GumballMachine gumballMachine);
        public void Refill(GumballMachine gumballMachine);
    }
}
