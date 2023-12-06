namespace Ver0_NonState
{
    /*
    * 상태패턴을 활용하지 않는 버젼
    * 각 메소드 마다 Switch문이 중복됨
    */
    public class GumballMachine {
        private GumballState currentState;
        private int count = 0;
    }
}