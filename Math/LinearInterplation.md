---
ebook:
  theme: github-light.css
  title: 객체지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    @import url('https://fonts.googleapis.com/css2?family=Fredericka+the+Great&display=swap');
    @font-face {
        font-family: 'Humanbumsuk';
        src: url('https://cdn.jsdelivr.net/gh/projectnoonnu/noonfonts_2210-2@1.0/Humanbumsuk.woff2') format('woff2');
        font-weight: normal;
        font-style: normal;
    }
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A5F !important;}
    h2 { letter-spacing : 4px; font-family: 'Fredericka the Great', "Humanbumsuk"; border-top: 12px solid #40493c; border-left: 5px solid #40493c; border-right: 5px solid #40493c; background-color: #40493c; color: #FFD466D5 !important; font-weight: bold;}
    h3 { letter-spacing : 4px; font-family: 'Fredericka the Great', "Humanbumsuk"; border-top: 12px solid #40493c; border: 5px solid #40493c; background-color: #40493c; color: #FFFFFFDF !important;}
</style>

## Linear interpolate : 선형 보간법

보간법이란? 
수치 해석학의 분야로 어떤 데이터 지점의 새로운 데이터 지점을 구하는 방식이다.


#### 양 끝점의 값이 주어졌을때 그 사이에 위치한 값을 추정하기위해 직선 거리에 따라 선형적으로 계산하는 방식이다.

유니티에서는 Mathf.Lerp 로 사용 가능하다.
![](2023-03-24-21-32-38.png)

### 1). 개요

<img src="2023-03-24-21-02-47.png" width=300px>

* $(x, y)$ 를 추정하기위해
* 두 점$(x_{0}, y_{0}),\; (x_{1}, y_{1})$에 직선을 긋는다.
그러면 다음과 같은 비례식을 구성할 수 있다.

> $$\frac{y-y_{0}}{x-x_{0}} = \frac{y_{1} - y_{0}}{x_{1}-x_{0}}$$

### 2). 일반화
* 두 지점 $p_{1}\; p_{2}$과 그 데이터 값 $f(p_{1}), f(p_{2})$
* $p_{1}\; p_{2}$ 임의의 점 $p$ 과 데이터 값 $f(p)$
* $d_{1}\; d_{2}$ 각각은 다음과 같다
  1. $p$부터 $p_{1}$ 까지 거리 
  2. $p$부터 $p_{2}$ 까지 거리

<img src="2023-03-24-21-09-35.png" width=300px>


$$
f(p) = \frac{d_{2}}{d_{1} + d_{2}} * f(p_{1}) + \frac{d_{1}}{d_{1} + d_{2}} * f(p_{2})
$$

```cpp
float lerp(float p1, float p2, float d1) {
  return (1-d1)*p1 + d1*p2;
}


l = lerp(3, 8 , 0,1);
for(;;){
    l = lerp(l, 8 , 0,1);
}

> L0 = 3.5
  L1 = 3.95
  L2 = 4.355
  L3 = 4.72
  L4 = 5.048
```

### 참고 
https://ko.wikipedia.org/wiki/%EC%84%A0%ED%98%95_%EB%B3%B4%EA%B0%84%EB%B2%95

https://en.wikipedia.org/wiki/B%C3%A9zier_curve
https://en.wikipedia.org/wiki/De_Casteljau%27s_algorithm
https://en.wikipedia.org/wiki/Polynomial_interpolation
https://en.wikipedia.org/wiki/Spline_interpolation
https://en.wikipedia.org/wiki/Bilinear_interpolation