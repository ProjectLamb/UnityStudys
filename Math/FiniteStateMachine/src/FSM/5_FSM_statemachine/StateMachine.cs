using System.Collections;
using System.Collections.Generic;
using FSM3_state;
using UnityEngine;

namespace FSM5_statemachine{

    public class StateMachine<T> where T : class
    {
        private T ownerEntity;
        private State<T> currentState;

        public void Setup(T owner, State<T> entryState) {
            ownerEntity = owner;
            currentState = null;

            ChangeState(entryState);
        }

        public void Execute() {
            currentState?.Execute(this.ownerEntity);
        }

        public void ChangeState(State<T> newState) {
            if(newState == null) return;
            currentState?.Exit(ownerEntity);
            currentState = newState;
            currentState.Enter(ownerEntity);
        }
    }

}