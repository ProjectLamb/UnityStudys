namespace Ver2_ContextDriven
{
    public interface GumballState {
        public bool InsertCoin() {return false;}
        public bool EjectCoin() {return false;}
        public bool TurnCrank() {return false;}
        public bool Dispense() {return false;}
        public bool Refill() {return false;}
    }
}
