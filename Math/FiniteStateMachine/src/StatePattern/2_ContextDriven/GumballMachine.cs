using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ver0_NonState;

namespace Ver2_ContextDriven
{
    /*********************************************************************************
    * Context 중심 전이

    State를 구현하는 방법 
        1. 전이 메소드는 전이 여부를 반환 true/false
        2. 전이 메소드는 상태 객체 반환

    Context를 구현하는 방법
        1. 응용 관련 데이터를 가짐
        2. Static으로 Context 공유 가능
        3. 상태 공유 방식
            * 전이 메소드의 결과를 바탕으로 전이
            * 따라서 getter, setter, changeToState 구현 안함

    의존 관계
        1. Context - State : Context만 상태에 의존 / 상태는 Context를 몰라도 됨
        2. State - State : 전이해야하는 상태 객체를 반환하는 경우 ConcreteState클래스간 의존 관계 형성
                어떤 ConcreteState로 전이 되는지를 명시하면. 의존관계 형성
                다만, 무조건 전이가 되냐 Or 안되냐 이 두가지 값만 반환 하므로
                > 얘는 return true/false 밖에 할게 없다 ㅋㅋ; 왜냐면 Contex를 모르고 있기 때문이다. 
                복합 전이에 대한 조건,제어문은 Context에서 구현해줘야함.

    행위 구현
        여전히 Context에서 구현
    
    ConcreteState공유 
        늘 공유 가능

    사실.. 상태중심 전이가 답이다.
    Context에 조건문이 더 많이 등장하는 구조가 되서 별로 좋지 않다.
    ConcreteState간 전이가 고정되었다.

    *********************************************************************************/

    public class GumballMachine {
        private static readonly GumballState soldOutState = new SoldOutState();
        private static readonly GumballState soldState = new SoldState();
        private static readonly GumballState noCoinState = new NoCoinState();
        private static readonly GumballState hasCoinState = new HasCoinState();

        private GumballState currentState;
        private int count = 0;

        public GumballMachine(int numberGumballs) {
            
            count = numberGumballs;
            if(count > 0) currentState = noCoinState;
            else currentState = soldOutState;
        }

        //ConcreteState간 전이가 고정되었다.
        public void InsertCoin() {
            if(currentState.InsertCoin()) currentState = hasCoinState;
        }
        public void EjectCoin() {
            if(currentState.EjectCoin()) currentState = noCoinState;
        }
        public void TurnCrank() {
            if(currentState.TurnCrank()) {
                currentState = soldState;
                if(currentState.Dispense()) {
                    Dispense();
                    if(count == 0) {
                        Debug.Log("껌볼이 더 이상 없습니다.");
                        currentState = soldOutState;
                    }
                    else {
                        currentState = noCoinState;
                    }
                }
            }
        }
        public void Dispense() {}
        public void Refill() { /*if(currentState.()) currentState*/ }
        public int GetNumberOfGumballs () {return count; }
        public bool IsEmpty(){ return count==0;}
    }
}