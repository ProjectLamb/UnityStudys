using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver2_ContextDriven
{
    public class HasCoinState : GumballState {
        public bool InsertCoin(){
            Debug.Log("이미 동전이 있음");
            return false;
        }
        public bool EjectCoin(){
            Debug.Log("삽입된 동전 반환");
            return true;
        }
        public bool TurnCrank(){
            Debug.Log("손잡이를 돌렸음");
            return true;
        }
        public bool Dispense(){
            Debug.Log("손잡이를 돌려야 껌볼이 나옴");
            return false;
        }
    }
}