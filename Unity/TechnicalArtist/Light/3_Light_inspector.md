
### 쉐이더

![](2023-04-12-12-35-54.png)

### 조명 개요

![](2023-04-12-12-38-11.png)

메인 광원 & 추가 광원으로 나뉜다.
메인 강원은 Sun Source를 통해 

설정한다.

### 광원 인스펙터
![](2023-04-12-13-02-31.png)

1. Prioritize View
   * 구워지고 있는지 확인
2. Direct Sample
   * 광원에서 방사되는 샘플 수를 지정
   * 샘플수와 품질은 비례
3. Indirect Sample
   * 표면에 부딛혔을때 생성할 광원의 간점광 샘플
   * 샘플수와 품질은 비례
4. Bounces 
   * 방사된 샘플이 다른 매질에 최대 몇번 튕겨나갈 수 있는지
5. Filtering
      * 구운 결과로 노이즈 억제를 위해 사용할 필터
6. Lightmap Resolution 
   * 라이트맵의 단위당 텍셀 수
7. Lightmap Size
   * 라이트맵 구울 시 분리된 도형 사이 간격
8. Compress Lightmap
   * 합축되어 공간을 덜 잡아먹지만
   * 색상에 옇양이 있음
9. Ambient Occlusion
   * 간접 조명에 대한 오클루전을 적용
   * 최대 거리 : 조명이 퍼지는 거리 라이트맵에 더 많은 그림자가 생길지 말지를 결정
   * 간접 Contribution : 간접광의 밝기
   * 직접 Contribution : 직접광의 밝기

### 라이트맵 파라미터
Realtime Gi 설정이다.

https://docs.unity3d.com/kr/current/Manual/class-LightmapParameters.html

### URP글로벌 세팅
특정 게임 오브젝트에만 영향을 주도록 광원 설정이 가능하다.
![](2023-04-14-17-16-09.png)

![](2023-04-12-12-47-40.png)

![](2023-04-12-12-48-06.png)

광원 레이어 활성화

![](2023-04-12-12-49-04.png)

https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=canny708&logNo=221552589446

