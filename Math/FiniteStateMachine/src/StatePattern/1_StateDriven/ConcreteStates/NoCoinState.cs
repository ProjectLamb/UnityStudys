using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver1_StateDriven
{
    public class NoCoinState : GumballState {
        private GumballMachine gMachine;
        /*의존성 주입으로 연결한다*/
        public NoCoinState(GumballMachine gMachine) {
            this.gMachine = gMachine;
        }
        public void InsertCoin(){
            Debug.Log("동전이 삽입되었음");
            gMachine.IncreseCoin();
            gMachine.SetState(gMachine.GetHasCoinState());
        }
        public void EjectCoin(){
            Debug.Log("반환활 동전 없음");
        }
        public void TurnCrank(){
            Debug.Log("동전이 없어 손잡이를 돌릴 수 없음");
        }
        public void Dispense(){
            Debug.Log("동전을 투입해야 구입할 수 있음");
        }
        public void Refill() {}
    }
}

