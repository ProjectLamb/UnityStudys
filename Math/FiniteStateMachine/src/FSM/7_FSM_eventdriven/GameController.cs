using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM7_eventdriven {
    public enum Locations {
        SweetHome = 0, Library, LectureRoom, PCRoom, Pub
    }

    public class GameController : MonoBehaviour {
        [SerializeField] 
        private string[] arrayStudents; //Student들의 이름 배열
        [SerializeField] 
        private GameObject studentPrefeb; //Student 타입의 프리펩


        [SerializeField] 
        private string[] arrayUnemployeds; //Student들의 이름 배열
        [SerializeField] 
        private GameObject unemployedPrefeb; //Student 타입의 프리펩

        private List<BaseGameEntity> entitys;

        public static bool IsGameStop {set;get;} = false;

        private void Awake() {
            entitys = new List<BaseGameEntity>();

            for (int i = 0; i < arrayStudents.Length; ++i) {
                GameObject studentClone = Instantiate(studentPrefeb);
                Student studentEntity = studentClone.GetComponent<Student>();
                studentEntity.Setup(arrayStudents[i]);

                entitys.Add(studentEntity);
            }

            for (int i = 0; i < arrayUnemployeds.Length; ++i) {
                GameObject unemployedClone = Instantiate(unemployedPrefeb);
                Unemployed unemployedEntity = unemployedClone.GetComponent<Unemployed>();
                unemployedEntity.Setup(arrayUnemployeds[i]);

                entitys.Add(unemployedEntity);
            }

            EntityDatabase.Instance.Setup();
            entitys.ForEach(e => EntityDatabase.Instance.RegisterEntity(e));
            MessageDispatcher.Instance.Setup();
        }

        private void Update() {
            if(IsGameStop == true) return;

            MessageDispatcher.Instance.DispatchDelayedMessage();
            
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