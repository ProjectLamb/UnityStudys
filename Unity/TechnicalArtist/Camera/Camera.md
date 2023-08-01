카메라
#### Clear Flag 
* Background
    * ![](src/23-06-30-10-00-17.png)
* Don't Clear
* depth only : 경계선이 없어질 수 있음, 벽뒤에 볼 수 있음

#### Culling Mask
* 보이게할지 말지
![](src/23-06-30-10-03-04.png) 

#### Projection

* 원근감
    ![](src/23-06-30-10-03-22.png)

#### FOV & 피지컬 카메라
![](src/23-06-30-10-09-26.png)

#### viewport ract
* 미니맵
    * ![](src/23-06-30-10-44-30.png)


#### 오클루젼 컬링을 적용하기

![](src/23-06-30-10-30-45.png)

* AllowHDR : 조명 좋아짐
* AllowMSAA 
* Allow 동적 해상도 
* 듀얼 모니터

#### ~~클리핑 플레인~~
#### ~~Depth 카메라의 우선순위~~
카메라 스태킹 오버드로우와 관련

```cs
theCAm.clearFlags;
theCAm.cullingMask;
theCAm.ClippingPlain;
```