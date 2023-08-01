using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Managers : MonoBehaviour {
    private SoundManager _sound = new SoundManager();
    public static SoundManager Sound { get { return Instance._sound; } }

    private Managers _instance;
    public static Managers Instance {
        get {
            // Instance 프로퍼티 get 시 호출되니까 또 여기서 Instance 쓰면 무한 루프 빠짐 주의!
            if (_instance == null)
            {
		    	GameObject go = GameObject.Find("@Managers");
                if (go == null) {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go);
                _instance = go.GetComponent<Managers>();

                _instance._sound.Init(); // ⭐ 📜SoundManager의 Init() 호출
            }		   
            return _instance;
        }
    }

    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            _instance._sound.Init();
        }
        else {
            Destroy(this.gameObject);
        }
    }
}
