using System;

namespace Ver0_NonState
{
    /*********************************************************************************
    * 상태패턴을 활용하지 않는 버젼
    * 각 메소드 마다 Switch문이 중복됨
    * 상태 추가가 매우 매우 번거로움 ㅅㅂ..
    *********************************************************************************/
    public class GumballMachine {
        private GumballState currentState;
        private int count = 0;

        public GumballMachine(int numberGumballs) {
            count = numberGumballs;
            if(count > 0) currentState = GumballState.NO_COIN;
            else currentState = GumballState.SOLD_OUT;
        }

        public void InsertCoin() {
            switch (currentState) {
                case GumballState.SOLD_OUT: {
                    Console.WriteLine("껌볼이 없어 판매가 중단됨");
                    break;
                }
                case GumballState.NO_COIN: {
                    Console.WriteLine("동전이 삽입되었음");
                    currentState = GumballState.HAS_COIN;
                    break;
                }
                case GumballState.HAS_COIN: {
                    Console.WriteLine("이미 동전이 있음");
                    break;
                }
                case GumballState.SOLD: {
                    Console.WriteLine("동전을 투입할 수 있는 단계가 아님");
                    break;
                }
            }
        }
        public void EjectCoin() {
            switch (currentState) {
                case GumballState.SOLD_OUT: {
                    Console.WriteLine("껌볼이 없어 판매가 중단됨");
                    break;
                }
                case GumballState.NO_COIN: {
                    Console.WriteLine("반환활 동전 없음");
                    break;
                }
                case GumballState.HAS_COIN: {
                    Console.WriteLine("삽입된 동전 반환");
                    currentState = GumballState.NO_COIN;
                    break;
                }
                case GumballState.SOLD: {
                    Console.WriteLine("반환활 동전이 없음");
                    break;
                }
            }
        }
        public void TurnCrank() {
            switch (currentState) {
                case GumballState.SOLD_OUT: {
                    Console.WriteLine("껌볼이 없어 판매가 중단됨");
                    break;
                }
                case GumballState.NO_COIN: {
                    Console.WriteLine("동전이 없어 손잡이를 돌릴 수 없음");
                    break;
                }
                case GumballState.HAS_COIN: {
                    Console.WriteLine("손잡이를 돌렸음");
                    currentState = GumballState.SOLD;
                    break;
                }
                case GumballState.SOLD: {
                    Console.WriteLine("이미 손잡이를 돌렸음");
                    break;
                }
            }
        }
        public void Dispense() {
            switch (currentState) {
                case GumballState.SOLD_OUT: {
                    Console.WriteLine("껌볼이 없어 판매가 중단됨");
                    break;
                }
                case GumballState.NO_COIN: {
                    Console.WriteLine("동전을 투입해야 구입할 수 있음");
                    break;
                }
                case GumballState.HAS_COIN: {
                    Console.WriteLine("손잡이를 돌려야 껌볼이 나옴.");
                    break;
                }
                case GumballState.SOLD: {
                    Console.WriteLine("껌볼이 나옴");
                    --count;
                    if(isEmpty()) {
                        Console.WriteLine("껌볼이 더 이상 없습니다.");
                        currentState = GumballState.SOLD_OUT;
                    }
                    else {
                        currentState = GumballState.NO_COIN;
                    }
                    break;
                }
            }
        }
        public void refill() {
            switch (currentState){
                case GumballState.SOLD_OUT : {
                    Console.WriteLine("껌볼을 추가함");
                    count = 20;
                    currentState = GumballState.NO_COIN;
                    break;
                }
                case GumballState.NO_COIN: case GumballState.SOLD: case GumballState.HAS_COIN : {
                    Console.WriteLine("껌볼의 추가는 껌볼이 없을떄만 가능");
                    break;
                }
            }
        }

        public int getNumberofGumballs () {return count; }

        public bool isEmpty(){ return count==0;}
    }
}