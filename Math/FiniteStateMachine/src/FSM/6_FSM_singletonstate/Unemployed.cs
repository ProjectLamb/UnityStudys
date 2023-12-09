using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM6_singletonstate
{
    public class Unemployed : BaseGameEntity
    {
        private int             borad;
        private int             stress;
        private int             fatigue;
        private Locations       currentLocations;

        private StateMachine<Unemployed> stateMachine;
        public State<Unemployed> CurrentState { get; private set;}

        public int Borad {
            set => borad = Mathf.Max(0, value); 
            get => borad;
        }
        public int Stress {
            set => stress = Mathf.Max(0, value); 
            get => stress;
        }
        public int Fatigue {
            set => fatigue = Mathf.Max(0, value); 
            get => fatigue;
        }
        public Locations CurrentLocations {
            set => currentLocations = value;
            get => currentLocations;
        }
        public override void Setup(string name)
        {
            base.Setup(name);
            gameObject.name = $"{ID:D2}_Student_{name}";

            stateMachine = new StateMachine<Unemployed>();
            stateMachine.Setup(this,  UnemployedOwnedStates.RestAndSleep.Instance);
            stateMachine.SetGlobalState(UnemployedOwnedStates.StateGlobal.Instance);

            borad               = 0;
            stress              = 0;
            fatigue             = 0;
            currentLocations    = Locations.SweetHome;

            PrintText("Hello Real World");
        }

        public override void Updated() {
            stateMachine.Execute();
        }

        public void ChangeState(State<Unemployed> newState) {
            CurrentState = newState;
            stateMachine.ChangeState(newState);
        }

        public void RevertToPreviousState(){
            stateMachine.RevertToPreviousState();
        }
    }
}