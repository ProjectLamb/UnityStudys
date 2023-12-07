using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM3_state {

    public enum LOCATIONS {
        SWEET_HOME = 0, LIBRARY, LECTURE_ROOM, PC_ROOM, PUB
    }

    public class GameController : MonoBehaviour {
        [SerializeField] 
        private string[] arrayStudents; //Student들의 이름 배열
        [SerializeField] 
        private GameObject studentPrefeb; //Student 타입의 프리펩

        private List<BaseGameEntity> entitys;

        public static bool IsGameStop {set;get;} = false;

        private void Awake() {
            entitys = new List<BaseGameEntity>();

            for (int i = 0; i < arrayStudents.Length; ++i) {
                GameObject clone = Instantiate(studentPrefeb);
                Student entity = clone.GetComponent<Student>();
                entity.SetUp(arrayStudents[i]);

                entitys.Add(entity);
            }
        }

        private void Update() {
            if(IsGameStop == true) return;

            for(int i = 0; i < entitys.Count; i++) {
                entitys[i].Updated();
            }
        }

        public static void Stop(BaseGameEntity entity) {
            IsGameStop = true;
            entity.PrintText("100점 획득으로 프로그램을 종료합니다.");
        }
    }
}