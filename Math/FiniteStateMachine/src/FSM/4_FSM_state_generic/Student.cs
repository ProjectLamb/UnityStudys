using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM4_state_generic {
    using StudnetOwnedState;
    
    public enum STUDENT_STATES {REST_AND_SLEEP= 0, STUDY_HARD, TAKE_A_EXAM, PLAY_A_GAME, HIT_THE_BOTTLE}
    public class Student : BaseGameEntity {
        private int             knowledge;
        private int             stress;
        private int             fatigue;
        private int             totalScore;
        private LOCATIONS       currentLocation;

        private State<Student>[]         states;
        private State<Student>           currentState;

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
        public LOCATIONS CurrentLocation 
        {
            set => currentLocation = value;
            get => currentLocation;
        }
        
        public override void SetUp(string name) {
            base.SetUp(name);

            gameObject.name = $"{ID:D2}_Student_{name}";
            
            states = new State<Student>[5];
            states[(int)STUDENT_STATES.REST_AND_SLEEP] = new RestAndSleep();
            states[(int)STUDENT_STATES.STUDY_HARD] = new StudyHard();
            states[(int)STUDENT_STATES.TAKE_A_EXAM] = new TakeAExam();
            states[(int)STUDENT_STATES.PLAY_A_GAME] = new PlayAGame();
            states[(int)STUDENT_STATES.HIT_THE_BOTTLE] = new HitTheBottle();
            currentState = states[(int)STUDENT_STATES.REST_AND_SLEEP];

            knowledge           = 0;
            stress              = 0;
            fatigue             = 0;
            totalScore          = 0;
            currentLocation     = LOCATIONS.SWEET_HOME;

            PrintText("Hello Real World");
        }

        public override void Updated() {
            // PrintText("대기중입니다.");
            currentState?.Execute(this);
        }

        public void ChangeState(STUDENT_STATES newState) {
            // 상태가 null값이면 무시
            if(states[(int)newState] == null) return;

            // 현재 상태가 있으면 Exit호출
            currentState?.Exit(this);

            //현재 상태 변환하고 Enter메소드 호출
            currentState = states[(int)newState];
            currentState.Enter(this);
        }
    }
}