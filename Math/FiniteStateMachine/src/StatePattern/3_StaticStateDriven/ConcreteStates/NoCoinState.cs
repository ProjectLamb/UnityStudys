using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver3_StaticStateDriven
{
    public class NoCoinState : GumballState {
        private static readonly NoCoinState _instance;
        public static NoCoinState Instance {
            get { return _instance; }
            private set{}
        }
        public void InsertCoin(GumballMachine gMachine){
            Debug.Log("동전이 삽입되었음");
            gMachine.ChangeStateTo(HasCoinState.Instance);
        }
        public void EjectCoin(GumballMachine gMachine){
            Debug.Log("반환활 동전 없음");
        }
        public void TurnCrank(GumballMachine gMachine){
            Debug.Log("동전이 없어 손잡이를 돌릴 수 없음");
        }
        public void Dispense(GumballMachine gMachine){
            Debug.Log("동전을 투입해야 구입할 수 있음");
        }
        public void Refill(GumballMachine gMachine){}
    }
}

