using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver1_StateDriven
{
    public class SoldState : GumballState {
        private GumballMachine gMachine;
        /*의존성 주입으로 연결한다*/
        public SoldState(GumballMachine gMachine) {
            this.gMachine = gMachine;
        }
        public void InsertCoin(){
            Debug.Log("동전을 투입할 수 있는 단계가 아님");
        }
        public void EjectCoin(){
            Debug.Log("반환활 동전이 없음");
        }
        public void TurnCrank(){
            Debug.Log("이미 손잡이를 돌렸음");
        }
        public void Dispense(){
            Debug.Log("껌볼이 나옴");
            this.gMachine.DecreseNumberOfGumball();
            if(this.gMachine.IsEmpty()) {
                Debug.Log("껌볼이 더 이상 없습니다.");
                gMachine.SetState(gMachine.GetSoldOutState());
            }
            else {
                gMachine.SetState(gMachine.GetNoCoinState());
            }
        }
        public void Refill() {

        }
    }
}