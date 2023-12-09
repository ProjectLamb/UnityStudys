using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM5_statemachine
{
    public enum UnemployedStates { RestAndSleep = 0,PlayAGame, HitTheBottle }
    public class Unemployed : BaseGameEntity
    {
        private int             borad;
        private int             stress;
        private int             fatigue;
        private Locations       currentLocations;

        private State<Unemployed>[] states;
        private StateMachine<Unemployed> stateMachine;

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

            states  = new State<Unemployed>[3];
            states[(int)UnemployedStates.RestAndSleep] = new UnemployedOwnedStates.RestAndSleep();
            states[(int)UnemployedStates.PlayAGame] = new UnemployedOwnedStates.PlayAGame();
            states[(int)UnemployedStates.HitTheBottle] = new UnemployedOwnedStates.HitTheBottle();
        
            stateMachine = new StateMachine<Unemployed>();
            stateMachine.Setup(this, states[(int)UnemployedStates.RestAndSleep]);

            borad               = 0;
            stress              = 0;
            fatigue             = 0;
            currentLocations    = Locations.SweetHome;

            PrintText("Hello Real World");
        }

        public override void Updated() {
            stateMachine.Execute();
        }

        public void ChangeState(UnemployedStates newState) {
            stateMachine.ChangeState(this.states[(int)newState]);
        }
    }
}