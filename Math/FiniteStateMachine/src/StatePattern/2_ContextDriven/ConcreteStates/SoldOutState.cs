using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver2_ContextDriven
{
    public class SoldOutState : GumballState {
        public bool InsertCoin(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
            return false;
        }
        public bool EjectCoin(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
            return false;
        }
        public bool TurnCrank(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
            return false;
        }
        public bool Dispense(){
            Debug.Log("껌볼이 없어 판매가 중단됨");
            return false;
        }
        public bool Refill() {
            Debug.Log("껌볼 투입");
            return true;
        }
    }
}