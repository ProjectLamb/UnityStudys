namespace Ver1_StateDriven
{
    public class GumballMachine {
        private final State soldOutState = new SoldOutState(this);
        private final State noCoinState = new NoCoinState(this);
        private final State hasCoinState = new HasCoinState(this);
        private final State soldState = new SoldState(this);
        private final State winnerState = new WinnerState(this);

        private State currentState;

        private int count = 0;

        public GumballMachine(int numberOfGumballs) {
            count = numberOfGumballs;
            if(count > 0) currentState = noCoinState;
            else currentState = soldOutState;
        }

        public void InsertCoin() {currentState.InsertCoin();}
        public void EjectCoin() {currentState.EjectCoin();}
        public void TurnCrank() {currentState.TurnCrank();}
        public void Dispense() {currentState.Dispense();}
    }
}