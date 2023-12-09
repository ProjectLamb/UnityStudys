using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver3_StaticStateDriven
{
    public class HasCoinState : GumballState {
        private static readonly HasCoinState _instance;
        public static HasCoinState Instance {
            get { return _instance; }
            private set{}
        }

        public void InsertCoin(GumballMachine gMachine){
            Debug.Log("이미 동전이 있음");
        }
        public void EjectCoin(GumballMachine gMachine){
            Debug.Log("삽입된 동전 반환");
            gMachine.ChangeStateTo(NoCoinState.Instance);
        }
        public void TurnCrank(GumballMachine gMachine){
            Debug.Log("손잡이를 돌렸음");
            gMachine.ChangeStateTo(SoldState.Instance);
        }
        public void Dispense(GumballMachine gMachine){
            Debug.Log("손잡이를 돌려야 껌볼이 나옴");
        }
        public void Refill(GumballMachine gMachine){}
    }
}