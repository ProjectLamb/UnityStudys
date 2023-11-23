라이트 매핑을 조작할 수 있는 API다.

### Static 변수

1. `bounceBoost` : 알베도를 부스트 한다?
    * 빛이 표면에서 반사되면 표면의 알베도가 곱패지는데
    * 이 값이 반사되는 강도에 영향을 준다.
    * 베이크된 라이트맵에 사용된다.

    * 
        ```cs
        //float 값이다.
        Lightmapping.bounceBoost = ??;
        ```

2. `buildProgress` : 라이트매핑의 진행사항을 0~1 부터 리턴
    * range 0 ~ 1 까지 float으로 리턴한다.

    * 
        ```cs
        progressValue = Lightmapping.buildProgress;
        ```

3. `completed` : 대리자 변수다. 베이크가 끝나면 실행할것을 연결
    * called when bake job is completed.
    * 
        ```cs
        Lightmapping.completed.Addlistener(끝날떄 실행되는 함수);
        ```

4. `giWorkflowMode` : 현재 사용된 라이트 매핑 베이크 workflow  모드를 

    * 
        ```cs
        
        ```

5. `isRunning` : 베이크가 실행중이면 true, 베이크가 끝나면 false

    * 
        ```cs
        
        ```

6. `lightingDataAsset` : 현재 씬에서 사용되는 베이트 데이터를 가져온다.

---------

### Static 매서드

1. `Lightmapping.Bake()`
   * 동기적을 베이킹 작업을 실행한다.
   * 비동기적으로도 실행 가능.

2. `Lightmapping.BakeLightProbesOnly()`
   * 라이트 프로브를 동기적으로 베이킹한다.
   * 비동기적으로도 실행 가능.

### 델리게이트
1. `OnCompletedFunction`	
   * Delegate used by Lightmapping.completed callback.