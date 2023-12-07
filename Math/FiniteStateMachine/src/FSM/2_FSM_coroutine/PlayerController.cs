using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM2_coroutine {
    /*
    확장이 쉬움.
    */
    public enum PLAYER_STATE {
        IDEL = 0, WALK, RUN, ATTACK
    }
    
    public class PlayerController : MonoBehaviour {
        private PLAYER_STATE playerState;
        IEnumerator currentRoutine;
        private void Awake() {
            ChangeState(PLAYER_STATE.IDEL);
        }  

        private void Update() {
            if(Input.GetKeyDown("1")) ChangeState(PLAYER_STATE.IDEL);
            else if(Input.GetKeyDown("2")) ChangeState(PLAYER_STATE.WALK);
            else if(Input.GetKeyDown("3")) ChangeState(PLAYER_STATE.RUN);
            else if(Input.GetKeyDown("4")) ChangeState(PLAYER_STATE.ATTACK);
        }
        
        public void ChangeState(PLAYER_STATE newState) {
            StopCoroutine(newState.ToString());
            playerState = newState;
            StartCoroutine(newState.ToString());
        } 

        private IEnumerator IDLE() {
            Debug.Log("비전투 모드로 변경");
            Debug.Log("체력/마력이 초단 10씩 자동 회복");

            while(true) 
            {
                Debug.Log("플레이어가 제자리에서 대기중입니다.");
                yield return null;
            }
        }
        private IEnumerator WALK() {
            Debug.Log("이동속도를 2로 설정한다.");

            while(true) 
            {
                Debug.Log("플레이어가 걸어갑니다.");
                yield return null;
            }
        }
        private IEnumerator RUN() {
            Debug.Log("이동속도를 5로 설정한다.");

            while(true) 
            {
                Debug.Log("플레이어가 뛰어갑니다.");
                yield return null;
            }
        }
        private IEnumerator ATTACK() {
            Debug.Log("자동 전투 모드로 변경");
            Debug.Log("자동 회복이 중지됩니다.");

            while(true) 
            {
                Debug.Log("플레이어가 목표물을 공격합니다.");
                yield return null;
            }
        }
    }
}