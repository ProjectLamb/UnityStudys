using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver1_StateDriven
{
    public class HasCoinState : GumballState {
        private GumballMachine gMachine;
        /*의존성 주입으로 연결한다*/
        public HasCoinState(GumballMachine gMachine) {
            this.gMachine = gMachine;
        }
        public void InsertCoin(){
            Debug.Log("이미 동전이 있음");
        }
        public void EjectCoin(){
            Debug.Log("삽입된 동전 반환");
            gMachine.SetState(gMachine.GetNoCoinState());
        }
        public void TurnCrank(){
            Debug.Log("손잡이를 돌렸음");
        }
        public void Dispense(){
            Debug.Log("손잡이를 돌려야 껌볼이 나옴");
        }
        public void Refill() {}
    }
}