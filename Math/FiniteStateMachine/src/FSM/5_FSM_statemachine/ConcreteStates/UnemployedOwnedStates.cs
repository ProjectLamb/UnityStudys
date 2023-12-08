using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FSM5_statemachine.UnemployedOwnedStates
{
    public class RestAndSleep : State<Unemployed> {
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
                entity.ChangeState(UnemployedStates.PlayAGame);
            }
        }
        public void Exit(Unemployed entity) {
            entity.PrintText("정리를 하지 않고 그냥 나간다..");
            return;
        }
    }
    public class PlayAGame : State<Unemployed> {
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
                entity.ChangeState(UnemployedStates.HitTheBottle);
            }
            else {
                entity.Borad -= 1;
                entity.Fatigue += 2;
            }

            if(entity.Borad == 0 || 50 <= entity.Fatigue) {
                entity.ChangeState(UnemployedStates.RestAndSleep);
            }
        }
        public void Exit(Unemployed entity) {
            entity.PrintText("PC방에서 나온다..");
            return;
        }
    }
    public class HitTheBottle : State<Unemployed> {
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

            if(entity.Stress == 0 || 50 <= entity.Fatigue ) {entity.ChangeState(UnemployedStates.RestAndSleep);}
        }
        public void Exit(Unemployed entity) {
            entity.PrintText("술집에서 나온다.");
            return;
        }
    }
}