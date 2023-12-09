using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Ver3_StaticStateDriven
{
    public class SoldState : GumballState {
        private static readonly SoldState _instance;
        public static SoldState Instance {
            get { return _instance; }
            private set{}
        }
        public void InsertCoin(GumballMachine gMachine){
            Debug.Log("동전을 투입할 수 있는 단계가 아님");
        }
        public void EjectCoin(GumballMachine gMachine){
            Debug.Log("반환활 동전이 없음");
        }
        public void TurnCrank(GumballMachine gMachine){
            Debug.Log("이미 손잡이를 돌렸음");
        }
        public void Dispense(GumballMachine gMachine){
            Debug.Log("껌볼이 나옴");
            gMachine.Dispense();
            if(gMachine.IsEmpty()) {
                Debug.Log("껌볼이 더 이상 없습니다.");
                gMachine.ChangeStateTo(SoldOutState.Instance);
            }
            else {
                gMachine.ChangeStateTo(NoCoinState.Instance);
            }
        }
        public void Refill(GumballMachine gMachine){}
    }
}