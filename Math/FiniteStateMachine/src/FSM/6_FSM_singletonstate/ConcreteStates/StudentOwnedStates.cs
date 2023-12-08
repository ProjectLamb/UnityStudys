using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEditor;
using UnityEngine;

namespace FSM6_singletonstate.StudentOwnedStates {
#region RestAndSleep
    public class RestAndSleep : State<Student> {
        private static readonly RestAndSleep _instance = new RestAndSleep();
        public static RestAndSleep Instance => _instance;

        public void Enter(Student entity) {
            entity.CurrentLocation = Locations.SweetHome;
            entity.Stress = 0;

            entity.PrintText("집에 들어온다. 행복한 우리집~ 집에오니 스트레스가 사라졌다.");
            entity.PrintText("침대에 누워 잠을 잔다.");
        }
        public void Execute(Student entity) {
            entity.PrintText("ZZZ...");
            if(entity.Fatigue > 0 ){
                //피로 10씩 감소
                entity.Fatigue -= 10;
            }
            else {
                entity.ChangeState(StudentOwnedStates.StudyHard.Instance);
            }
        }
        public void Exit(Student entity) {
            entity.PrintText("침대를 정리하고 집 밖으로 나간다.");
        }
    }
#endregion

#region StudyHard
    public class StudyHard : State<Student> {
        private static readonly StudyHard _instance = new StudyHard();
        public static StudyHard Instance => _instance;

        public void Enter(Student entity){
            entity.CurrentLocation = Locations.Library;
            entity.PrintText("공부를 하기 위해 도서관에 왔다.. 힘차게.. 공부를 하자");
        }
        public void Execute(Student entity){
            entity.PrintText("공부 공부 공부 공부...");

            entity.Knowledge++;
            entity.Stress++;
            entity.Fatigue++;

            if(3 <= entity.Knowledge && entity.Knowledge <= 10) {
                int isExit = Random.Range(0,2);

                if(isExit == 1 || entity.Knowledge >= 10) {
                    entity.ChangeState(StudentOwnedStates.TakeAExam.Instance);
                }
            }

            if(20 <= entity.Stress) {
                entity.ChangeState(StudentOwnedStates.PlayAGame.Instance);
            }
            if(50 <= entity.Fatigue) {
                entity.ChangeState(StudentOwnedStates.RestAndSleep.Instance);
            }

        }
        public void Exit(Student entity){
            entity.PrintText("자리를 정리하고 도서관을 나간다.");
        }
    }
#endregion

#region TakeAEaxm
    public class TakeAExam : State<Student>{
        private static readonly TakeAExam _instance = new TakeAExam();
        public static TakeAExam Instance => _instance;

        public void Enter(Student entity){
            entity.CurrentLocation = Locations.LectureRoom;
            entity.PrintText("강의실에 들어간다. 시험지를 받았다.");
        }
        public void Execute(Student entity){
            int examScore = 0;
            if(entity.Knowledge == 10) {
                examScore = 10;
            }
            else {
                int randIndex = Random.Range(0, 10);
                examScore = randIndex < entity.Knowledge ? Random.Range(6, 11) : Random.Range(1, 6);
            }

            entity.Knowledge = 0;
            entity.Fatigue += Random.Range(5, 11);

            entity.TotalScore += examScore;
            entity.PrintText($"시험 성적 ({examScore}), 총점 ({entity.TotalScore})");
            
            if(entity.TotalScore >= 100) {
                GameController.Stop(entity);
                return;
            }

            if(examScore <= 3) {
                entity.Stress += 20;
                entity.ChangeState(StudentOwnedStates.HitTheBottle.Instance);
            }
            else if (examScore <= 7) {
                entity.ChangeState(StudentOwnedStates.StudyHard.Instance);
            }
            else {
                entity.ChangeState(StudentOwnedStates.PlayAGame.Instance);
            }
        }
        public void Exit(Student entity){
            entity.PrintText("강의실 문을 열고 나간다.");
        }
    }
#endregion

#region PlayAGame
    public class PlayAGame : State<Student>{
        private static readonly PlayAGame _instance = new PlayAGame();
        public static PlayAGame Instance => _instance;

        public void Enter(Student entity){
            entity.CurrentLocation = Locations.PCRoom;
            entity.PrintText("한시간만... 딱 한시간만 놀아야지.. PC방으로 들어간다..");
        }
        public void Execute(Student entity){
            entity.PrintText("건전하게?? 게임을 즐긴다..");

            int randState = Random.Range(0, 10);

            if(randState == 0 || randState == 9) {
                entity.Stress +=20;
                entity.ChangeState(StudentOwnedStates.HitTheBottle.Instance);
            }
            else 
            {
                entity.Stress -= 1;
                entity.Fatigue += 2;

                if(entity.Stress <= 0) {
                    entity.ChangeState(StudentOwnedStates.StudyHard.Instance);
                }
            }
        }
        public void Exit(Student entity){
            entity.PrintText("PC방에서 나온다.");
        }
    }
#endregion

#region HitTheBottle
    public class HitTheBottle : State<Student>{
        private static readonly HitTheBottle _instance = new HitTheBottle();
        public static HitTheBottle Instance => _instance;

        public void Enter(Student entity){
            entity.CurrentLocation = Locations.Pub;
            entity.PrintText("술이나 한잔할까? 술집으로 들어간다.");
        }
        public void Execute(Student entity){
            entity.PrintText("술을 마신다.");

            entity.Stress -= 5;
            entity.Fatigue += 5;
            if(entity.Stress <= 0 || 50 <= entity.Fatigue ) 
            {
                entity.ChangeState(StudentOwnedStates.RestAndSleep.Instance);
            }
        }
        public void Exit(Student entity){
            entity.PrintText("그만 마셔야지.. 술집에서 나온다.");
        }
    }
#endregion
}