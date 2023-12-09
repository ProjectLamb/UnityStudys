using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FSM7_eventdriven.UnemployedOwnedStates
{
#region RestAndSleep
    public class RestAndSleep : State<Unemployed> {
        private static readonly RestAndSleep _instance = new RestAndSleep();
        public static RestAndSleep Instance => _instance;

        public void Enter(Unemployed entity) {
            entity.CurrentLocations = Locations.SweetHome;

            entity.Stress = 0;
            entity.Fatigue = 0;

            entity.PrintText("소파에 눕는다");
        }
        public void Execute(Unemployed entity) {
            string currentActionString = Random.Range(0, 2) == 0 ? "ZZZ..." : "뒹굴뒹굴.. TV를 본다";
            entity.PrintText(currentActionString);
            entity.Borad += Random.Range(0, 100) >= 70 ? 1 : -1;
            if(entity.Borad >= 4) {
                
                string receiver = "학생1";
                entity.PrintText($"Send Message : {entity.EntityName}님이 {receiver}님에게 GO_PCROOM 전송 ");
                MessageDispatcher.Instance.DispatchMessage(0, entity.EntityName, receiver, "GO_PCROOM");

                entity.ChangeState(UnemployedOwnedStates.PlayAGame.Instance);
            }
        }
        public void Exit(Unemployed entity) {
            entity.PrintText("정리를 하지 않고 그냥 나간다..");
            return;
        }
        public bool OnMessage(Unemployed unemployed, Telegram telegram) {return false;}
    }
#endregion
#region PlayAGame
    public class PlayAGame : State<Unemployed> {
        private static readonly PlayAGame _instance = new PlayAGame();
        public static PlayAGame Instance => _instance;

        public void Enter(Unemployed entity) {
            entity.CurrentLocations = Locations.PCRoom;
            entity.PrintText("PC방으로 들어선다.");
            return;
        }
        public void Execute(Unemployed entity) {
            entity.PrintText("게임을 한다..");

            int randNum = Random.Range(0, 100);
            if(randNum < 20) {
                entity.Stress += 20;
                entity.ChangeState(UnemployedOwnedStates.HitTheBottle.Instance);
            }
            else {
                entity.Borad -= 1;
                entity.Fatigue += 2;
            }

            if(entity.Borad == 0 || 50 <= entity.Fatigue) {
                entity.ChangeState(UnemployedOwnedStates.RestAndSleep.Instance);
            }
        }
        public void Exit(Unemployed entity) {
            entity.PrintText("PC방에서 나온다..");
            return;
        }
        public bool OnMessage(Unemployed unemployed, Telegram telegram) {return false;}
    }
#endregion
#region HitTheBottle
    public class HitTheBottle : State<Unemployed> {
        private static readonly HitTheBottle _instance = new HitTheBottle();
        public static HitTheBottle Instance => _instance;

        public void Enter(Unemployed entity) {
            entity.CurrentLocations = Locations.Pub;
            entity.PrintText("술집으로 들어간다.");
            return;
        }
        public void Execute(Unemployed entity) {
            entity.PrintText("취할때 까지 술을 마신다..");
            entity.Borad += Random.Range(0, 100) > 50 ? 1 : -1;
            entity.Stress -= 4;
            entity.Fatigue += 4;

            if(entity.Stress == 0 || 50 <= entity.Fatigue ) {entity.ChangeState(UnemployedOwnedStates.RestAndSleep.Instance);}
        }
        public void Exit(Unemployed entity) {
            entity.PrintText("술집에서 나온다.");
            return;
        }
        public bool OnMessage(Unemployed unemployed, Telegram telegram) {return false;}
    }
#endregion
#region VisitBathroom
    public class VisitBathroom : State<Unemployed> {
        private static readonly VisitBathroom _instance = new VisitBathroom();
        public static VisitBathroom Instance => _instance;

        public void Enter(Unemployed entity) {
            entity.PrintText("화장실에 들어간다.");
        }
        public void Execute(Unemployed entity) {
            entity.PrintText("볼일을 본다.");

            entity.RevertToPreviousState();
        }
        public void Exit(Unemployed entity) {
            entity.PrintText("손을 씻고 화장실에서 나간다.");
        }
        public bool OnMessage(Unemployed unemployed, Telegram telegram) {return false;}
    }
#endregion
#region StateGlobal
    public class StateGlobal : State<Unemployed> {
        private static readonly StateGlobal _instance = new StateGlobal();
        public static StateGlobal Instance => _instance;
        
        public void Enter(Unemployed entity) {
            return;
        }
        public void Execute(Unemployed entity) {
            if(entity.CurrentState == UnemployedOwnedStates.VisitBathroom.Instance) {
                return;
            }

            int bathroomState = Random.Range(0, 100);

            if(bathroomState < 10) {
                entity.ChangeState(UnemployedOwnedStates.VisitBathroom.Instance);
            }
        }
        public void Exit(Unemployed entity) {
            return;
        }
        public bool OnMessage(Unemployed unemployed, Telegram telegram) {return false;}
    }
#endregion
}