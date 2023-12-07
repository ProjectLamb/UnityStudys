using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver2_ContextDriven
{
    public class SoldState : GumballState {
        public bool InsertCoin(){
            Debug.Log("동전을 투입할 수 있는 단계가 아님");
            return false;
        }
        public bool EjectCoin(){
            Debug.Log("반환활 동전이 없음");
            return false;
        }
        public bool TurnCrank(){
            Debug.Log("이미 손잡이를 돌렸음");
            return false;
        }
        public bool Dispense(){
            Debug.Log("껌볼이 나옴");
            return true;
        }
    }
}