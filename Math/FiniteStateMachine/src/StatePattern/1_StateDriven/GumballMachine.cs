using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver1_StateDriven
{
    /*********************************************************************************
    * 상태(State) 중심 전이
    
    State를 구현하는 방법
        1. 생성자에서 받은 Contex객체를 유지
        2. 전이 메소드 마다 Context 전달
            상태 공유를 위해서는 문맥을 유지하지 않고 
            전미 메소드마다 전달받는 방식이 효과적이다.
    
    Context를 구현하는 방법
        1. 응용 관련 데이터를 가짐
        2. ConcreteState 수만큼 State객체가 여러개 있다.
        3. 상태 전이 방법
            * getter, setter, changeToState
                * 상태(State) 전이를 위해 상태객체를 전달하는 Getter
                * 상태(State) 저장을 위한 Setter

    의존 관계
        1. Context - State : 상호 의존적
        2. State - State : 간접, 
            Context.changeToState()를 사용하고,
            Context에 존재하는 ConcreteState를 사용

    행위 구현
        ConcreteState에서 행위를 구현

    ConcreteState공유 
        static으로 공유 가능

    Context 클래스가 단순해지고, 각 클래스의 응집성이 높아진다.
    상태의 추가와 수정이 더 용이하다.

    *********************************************************************************/

    public class GumballMachine {
        private readonly GumballState soldOutState;
        private readonly GumballState noCoinState;
        private readonly GumballState hasCoinState;
        private readonly GumballState soldState;
        private GumballState currentState;
        private int gumballCount = 0;
        private int currentCoin = 0;
        /* Getter은 상태 수만큼 필요*/
        public GumballState GetSoldOutState() {return soldOutState;}
        public GumballState GetNoCoinState() {return noCoinState;}
        public GumballState GetHasCoinState() {return hasCoinState;}
        public GumballState GetSoldState() {return soldState;}
        /* Setter은 하나 */
        public void SetState(GumballState nextState) {this.currentState = nextState;}

        public GumballMachine(int numberGumballs) {
            soldOutState = new SoldOutState(this);
            noCoinState = new NoCoinState(this);
            hasCoinState = new HasCoinState(this);
            soldState = new SoldState(this);

            gumballCount = numberGumballs;
            if(gumballCount > 0) currentState = noCoinState;
            else currentState = soldOutState;
        }
        
        /*검볼 머신이 로직을 처리하는게 아니라 상태에게 처리르 위임하는 방식*/ 
        public void InsertCoin() {currentState.InsertCoin();}
        public void EjectCoin() {currentState.EjectCoin();}
        public void TurnCrank() {
            currentState.TurnCrank();
            currentState.Dispense();
        }
        public void Refill(int gumballs) {
            gumballCount = gumballs;
        }

        public void DecreseNumberOfGumball() {--gumballCount; }
        public int GetNumberOfGumballs () {return gumballCount; }
        public bool IsEmpty(){ return gumballCount==0;}
        public void IncreseCoin() {++currentCoin;}
    }
}