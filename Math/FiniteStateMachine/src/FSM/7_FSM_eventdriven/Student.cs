using System.Collections;
using System.Collections.Generic;
using FSM7_eventdriven.StudentOwnedStates;
using UnityEngine;

namespace FSM7_eventdriven{

    public class Student : BaseGameEntity
    {
        private int knowledge;
        private int stress;
        private int fatigue;
        private int totalScore;
        private Locations currentLocation;
        private StateMachine<Student> stateMachine;
        public State<Student> CurrentState { get; private set;}
        
        public int Knowledge 
        {
            set => knowledge = Mathf.Max(0, value);
            get => knowledge;
        }
        public int Stress 
        {
            set => stress = Mathf.Max(0, value);
            get => stress;
        }
        public int Fatigue 
        {
            set => fatigue = Mathf.Max(0, value);
            get => fatigue;
        }
        public int TotalScore 
        {
            set => totalScore = Mathf.Clamp(value, 0, 100);
            get => totalScore;
        }
        public Locations CurrentLocation 
        {
            set => currentLocation = value;
            get => currentLocation;
        }

        public override void Setup(string name)
        {
            base.Setup(name);
            gameObject.name = $"{ID:D2}_Student_{name}";
            
            stateMachine = new StateMachine<Student>();
            stateMachine.Setup(this, StudentOwnedStates.RestAndSleep.Instance);
            stateMachine.SetGlobalState(GlobalMessageReceive.Instance);

            knowledge           = 0;
            stress              = 0;
            fatigue             = 0;
            totalScore          = 0;
            currentLocation     = Locations.SweetHome;

            PrintText("Hello Real World");
        }

        public override void Updated() {
            stateMachine.Execute();
        }

        public override bool HandleMessage(Telegram telegram)
        {
            return stateMachine.HandleMessage(telegram);
        }

        public void ChangeState(State<Student> newState) {
            CurrentState = newState;
            stateMachine.ChangeState(newState);
        } 
        public void RevertToPreviousState(){
            stateMachine.RevertToPreviousState();
        }

    }
}