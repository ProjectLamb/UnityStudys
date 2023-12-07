using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver3_StaticStateDriven
{
    public class SoldOutState : GumballState {
        private static readonly SoldOutState _instance;
        public static SoldOutState Instance {
            get { return _instance; }
            private set{}
        }

        public void InsertCoin(GumballMachine gMachine){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void EjectCoin(GumballMachine gMachine){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void TurnCrank(GumballMachine gMachine){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void Dispense(GumballMachine gMachine){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void Refill(GumballMachine gMachine){}
    }
}