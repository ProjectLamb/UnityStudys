using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM7_eventdriven {
    public abstract class BaseGameEntity : MonoBehaviour {
        // static 변수라 1개만 존재함
        private static int m_iNextValidID = 0;

        // BaseGameEntity를 상속받는 모든 게임오브젝트는 ID 번호를 부여받아
        // 이 번호는 0부터 시작해 1씩 증가함으로 주민등록번호처럼 사용한다
        private int id;
        public int ID {
            get => id;
            set {
                id = value;
                ++m_iNextValidID;
            }
        }

        private string entityName; //에이전트 이름
        private string personalColor; //에이전트 색상 (텍스트 출력용)

        //에이전트 이름 정보를 열람할 수있도록 Get호출
        public string EntityName => entityName;

        public virtual void Setup(string name) {
            ID = m_iNextValidID;
            this.entityName = name;
            int color = Random.Range(0, 10000000);
            personalColor = $"#{color.ToString("X6")}";
        } 

        //abstarct에서 Update
        public abstract void Updated();

        // 메세지를 수신하는 메소드 (MessageDispatcher 클래스에서 호출)
        public abstract bool HandleMessage(Telegram telegram);

        public void PrintText(string text) {
            Debug.Log($"<color={personalColor}><b>{entityName}</b></color> : {text}");
        }
    }
}