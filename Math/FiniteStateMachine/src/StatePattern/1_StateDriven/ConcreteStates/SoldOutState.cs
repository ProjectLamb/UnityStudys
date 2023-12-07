using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver1_StateDriven
{
    public class SoldOutState : GumballState {
        private GumballMachine gMachine;
        /*의존성 주입으로 연결한다*/
        public SoldOutState(GumballMachine gMachine) {
            this.gMachine = gMachine;
        }
        public void InsertCoin(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void EjectCoin(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void TurnCrank(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void Dispense(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
        }
        public void Refill() {

        }
    }
}