using UnityEngine;

namespace FSM1_switchcase {
    /*
    * 상태 전이 실행 순서 행동을 정의하기 어려움(들어갈때, 나갈때의 행동을 정의하기 어려움)
    * 확장에 닫혀있는 구조 (수정이 어려움)
    */
    public enum PLAYER_STATE {
        IDEL = 0, WALK, RUN, ATTACK
    }

    public class PlayerController : MonoBehaviour {
        private PLAYER_STATE playerState;
        private bool isChanged;
        private void  Awake() {
            ChangeState(PLAYER_STATE.IDEL);
        }  

        private void Update() {
            if(Input.GetKeyDown("1")) ChangeState(PLAYER_STATE.IDEL);
            else if(Input.GetKeyDown("2")) ChangeState(PLAYER_STATE.WALK);
            else if(Input.GetKeyDown("3")) ChangeState(PLAYER_STATE.RUN);
            else if(Input.GetKeyDown("4")) ChangeState(PLAYER_STATE.ATTACK);

            UpdateState();
        }
        
        public void ChangeState(PLAYER_STATE newState) {
            this.playerState = newState;
            isChanged = true;
        } 

        public void UpdateState() {
            switch(playerState) {
                case PLAYER_STATE.IDEL : {
                    if(isChanged == true) {
                        /*한번만 실행해야하는 코드*/
                        isChanged = false;
                    }
                    Debug.Log("플레이어가 제자리에서 대기중입니다.");
                    break;
                }
                case PLAYER_STATE.WALK : {
                    if(isChanged == true) {
                        /*한번만 실행해야하는 코드*/
                        isChanged = false;
                    }
                    Debug.Log("플레이어가 걸어갑니다.");
                    break;
                }
                case PLAYER_STATE.RUN : {
                    if(isChanged == true) {
                        /*한번만 실행해야하는 코드*/
                        isChanged = false;
                    }
                    Debug.Log("플레이어가 뛰어갑니다.");
                    break;
                }
                case PLAYER_STATE.ATTACK : {
                    if(isChanged == true) {
                        /*한번만 실행해야하는 코드*/
                        isChanged = false;
                    }
                    Debug.Log("플레이어가 목표물을 공격합니다.");
                    break;
                }
            }
        }
    }
}