using System.Collections;
using System.Collections.Generic;
using FSM3_state;
using UnityEngine;

namespace FSM6_singletonstate{
    /*
    상태 블립 
    
    에이전트의 상태가 변경될때, 바로 직전 상태로 복귀한다는 조건하에
    다른 상태로 변경하는것.
    */
    public class StateMachine<T> where T : class
    {
        private T ownerEntity;
        private State<T> previousState;
        private State<T> currentState;
        private State<T> globalState;

        public void Setup(T owner, State<T> entryState) {
            ownerEntity = owner;
            previousState = null;
            currentState = null;
            globalState = null;

            ChangeState(entryState);
        }

        public void Execute() {
            globalState?.Execute(this.ownerEntity);
            currentState?.Execute(this.ownerEntity);
        }

        public void ChangeState(State<T> newState) {
            if(newState == null) return;
            if(currentState != null) {
                previousState = currentState;
                currentState.Exit(ownerEntity);
            }
            currentState = newState;
            currentState.Enter(ownerEntity);
        }

        public void SetGlobalState(State<T> newState) {
            globalState = newState;
        }

        public void RevertToPreviousState(){
            ChangeState(this.previousState);
        }
    }

}