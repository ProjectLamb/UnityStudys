using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************************************
객체 내부 상태에 따라 할 수 있는일이 달라지는경우에 사용할 수 있는 패턴
상태를 나타내는 클래스를 정의
클래스의 수는 증가는 불가피하다.
상태 전이를 더 명백하게 나타낼 수 있음.
*********************************************************************************/

namespace Ver1_StateDriven
{
    public interface GumballState {
        public void InsertCoin() {}
        public void EjectCoin();
        public void TurnCrank();
        public void Dispense();
        public void Refill();
    }
}
