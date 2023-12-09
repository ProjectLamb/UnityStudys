using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq.Expressions;
using System.Threading;

namespace Ver3_StaticStateDriven
{
    /*********************************************************************************

    *********************************************************************************/

    public class GumballMachine {
        private GumballState currentState;
        
        private int gumballCount = 0;
        private int currentCoin = 0;

        public GumballMachine(int numberGumballs) {
            gumballCount = numberGumballs;
            if(gumballCount > 0) currentState = NoCoinState.Instance;
            else currentState = SoldOutState.Instance;
        }
        public bool IsEmpty(){ return gumballCount==0;}
        public void ChangeStateTo(GumballState state) {
            currentState = state;
        }

        public void InsertCoin() {
            currentState.InsertCoin(this);
        }
        public void EjectCoin() {
            currentState.EjectCoin(this);
        }
        public void TurnCrank() {
            currentState.TurnCrank(this);
            currentState.Dispense(this);
        }
        public void Refill() {
            currentState.Refill(this);
        }
        public void Refill(int gumballs) {
            gumballCount = gumballs;
        }
        public int GetNumberOfGumballs () {return gumballCount; }        
        public void IncreseCoin() {++currentCoin;}
        public void Dispense() {
            Debug.Log(gumballCount);
            if(gumballCount > 0) --gumballCount;
        }
    }
}