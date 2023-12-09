using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ver2_ContextDriven
{
    public class NoCoinState : GumballState {
        public bool InsertCoin(){
            Debug.Log("동전이 삽입되었음");
            return true;
        }
        public bool EjectCoin(){
            Debug.Log("반환활 동전 없음");
            return false;
        }
        public bool TurnCrank(){
            Debug.Log("동전이 없어 손잡이를 돌릴 수 없음");
            return false;
        }
        public bool Dispense(){
            Debug.Log("동전을 투입해야 구입할 수 있음");
            return false;
        }
    }
}

