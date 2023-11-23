---
ebook:
  theme: one-dark.css
  title: 객체지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A0F !important;}

    h2 { border-top: 12px solid #45C1A4; border-left: 5px solid #45C1A4; border-right: 5px solid #45C1A4; background-color: #45C1A4; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #45C1A4 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
    .red{color: #d93d3d;}
    .darkred{color: #470909;}
    .orange{color: #cf6d1d;}
    .yellow{color: #DD3;}
    .green{color: #25ba00;}
    .blue{color: #169ae0;}
    .pink{color: #d10fd1;}
    .dim{color : #666666;}
    .lime{color : #addb40;}
</style>

## ⏱️ 3. Coroutine

### 📄 1. 개요
사실 UniTask가 Coroutine의 상위호완이라고 하는데
그렇다면 정말 "코루틴이 할수 있는것" 을 모두 포함할 수 있어야
UniTask를 사용해도 된다는것이다.

기초부터 알아보자.

장점, 단점, 어떻게 사용할지 적어보자.
성능은 제발 신경쓰지 말자. (내게 하는말.. ㅋㅋㅋ)
이건 UniTask로 옮기기 위한 사전 작업이다.

InvokeRepeating();
스케쥴링
CustomYieldInstruction

TimerTick

### 코루틴
1. 다수의 프레임에 작업을 분산할 수 있음
2. 실행 일지 정지
3. 중단된 부분에서 다시 프레임 연결

다만 코루틴은 스레드가 아니다. 여전히 메인 스레드에서 실행되는데.
메인스레드의 점유를 뺏기지 않기 위해서는 절제 해야한다. 
> <p class="red">단점 : cpd의 시간이 저당 잡힌다.</p>
> 짧은 비동기 작업이 아닌, 긴 비동기 작업을 처리하는 경우가 가장 좋다
> 매 프레임마다 실행되고, 오래 실행되는 작업일 경우 Update, LateUpdate로 대체하는게 좋다.
> 
> HTTP, 에셋 로드, 파일 I/O 완료, 

> <p class="lime">장점 : 편리하다(?)</p>

> <p class="yellow"></p>

```cs
void StopCoroutin(Coroutine co); //정지
void StopAllCoroutine(); //모두 정지
gameobject.SetActive(false); // 정지

Destroy() -> OnDisable.OnDestroy
```

#### `Yield`
```cs

Yield return;
// 't'초가 지난 후 첫 번째 프레임에서 코루틴이 다시 시작
YieldInstruction new WaitForSecond(); 
YieldInstruction new WaitForSecondsRealtime(); 

YieldInstruction new WaitForFixedUpdate();
YieldInstruction new WaitForEndOfFrame();

//
YieldInstruction new WaitUntil();
YieldInstruction new WaitWhile();

---

Yield break;
```
##### `YieldInstruction new WaitForEndOfFrame()`
1. 다음 프레임의 Update와 모든 렌더링이 끝날 때까지 기다림
2. 카메라와 GUI의 렌더링 프레임이 끝날떄 까지 기다린다
3. Texture2D.ReadPixels, Texture2D를 인코딩

##### `YieldInstruction new AsyncOperation()`

<details>
   <summary style="cursor:pointer; text:bold"><b>📂접기 / 펴기📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

IEnumerator UploadPNG() 
{
    //렌더링이 끝나고 나서 스크린 버퍼를 읽기위해 사용
    yield return new WaitforEndOfFrame();

    int width = Screen.width;
    int height = Screen.height;
    Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

    // Read screen contents into the texture
    tex.ReadPixels(new Rect(0,0,width, height), 0,0);
    tex.Apply();

    //Encode Texture into PNG
    byte[] bytes = tex.EndoceToPNG();
    Destroy(tex);

    //웹 폼을 작성
    WWWFrom form = new WWWForm();
    form.AddField("frameCount", Time.frameCount.ToString());
    form.AddBinaryData("fileUpload", bytes);

    //cgi 스크립트 게시
    var w = UnityWebRequest.Post("http://localhost/cgi-bin/env.cgi?post", form");
    yield return w.SendWebRequest();
    
    if(w.result != UnityWebRequest.Result.Success)
        print(w.error)
    else 
        print("Finished Uploading Screenshot");
    yield return null;s
}
```
</details>


> 유니티가 씬을 불러올때 다른 작업을 하지 못한다.
> 흔히 렉이라고 말하는 작업 처리 지연 현상을 일으키기 때문에.

1. 동기동작이 완료될떄까지
2. 수동적으로 IsDone이거나 Progress 체크가 가능하다.
3. SceneManager.LoadSceneAsync, AssetBundle.LoadAssetAsync, Resources.LoadAsync


**프로퍼티**
* ***AsyncOperation.allowSceneActivation*** : Bool
  * 씬이 준비되는 즉시 활성화 되도록 
    * false로 Set 하면 Progress 0.9에서 멈추고, isDone은 false로
    * true로 Set 하면 isDone은 true

* 
    <details>
       <summary style="cursor:pointer; text:bold"><b>📂접기 / 펴기📂</b></summary>

       <!-- summary 아래 한칸 공백 두어야함 -->
    ```cs
    IEnumerator LoadSecne() 
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("");
        Debug.Log("Pro :" + asyncOperation.progress);
        while(!asyncOperation.isDone) 
        {
            if(asyncOperation.progress >= 0.9f)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                    asyncOperation.allowSceneActivation = true;
            }
        }
    }
    ```
    </details>

* ***AsyncOperation.isDone*** : bool
  * Readonly며 Async의 진행 상황이 완료될떄 true 반환 

* ***AsyncOperation.progress*** : float
  * Readonly며 Async의 진행 상황이 완료될떄 true 반환 
  * 로딩 바를 구현하는데 사용 가능

* ***AsyncOperation.priorty*** : 
  * 우선순위를 사용해 작업 호출이 수행되는 순서를 조정한다.
  * 다만 스레드에서 작업이 시작되면 우선순위를 바꿔도 효과가 없다.

**액션**
* ***AsyncOperation.completed*** : 
  * 비동기 작업이 끝나면 실행될 함수를 Add할 수 있다.

##### `YieldInstruction new WaitUntil`
람다식의 값이 true가 되야지 넘어간다.

```cs
Ienumerator Example() 
{
    yield return new WaitUntil(() => {frame >= 10});
}

void Update()
{
    if(frame <= 10)
    {
        Debug.Log("Frame :" + frame); frame++;
    }
}
```

##### `WaitWhile`
람다 식이 false일떄 넘어간다.
```cs
Ienumerator Example() 
{
    yield return new WaitUntil(() => {frame < 10});
}

void Update()
{
    if(frame <= 10)
    {
        Debug.Log("Frame :" + frame); frame++;
    }
}
```