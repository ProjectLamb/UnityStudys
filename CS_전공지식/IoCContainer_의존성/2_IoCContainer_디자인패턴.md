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

    h2 { border-top: 12px solid #86B049; border-left: 5px solid #86B049; border-right: 5px solid #86B049; background-color: #86B049; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #476930 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>


## &nbsp;♽ 2. DI & IoC 디자인 패턴

#### DI & IoC Container을 이해하기 위한 디자인 패턴만 명시한다.

### 📄 1. 생성 패턴

<div align="center">
  <h4> 생성과 참조과정을 캡슐화 하여 객체가 생성되거나 변경되도 <br>
  시스템에 영향을 크게 받지 않도록 프로그램의 유연성을 더해주는 패턴</h4>
</div>

---

#### 1). Factory Method

**ⓐ 특징**
**ⓑ 왜 쓰는건가?**
**ⓒ 구성요소**
**ⓓ 구현**
**ⓔ 예시**

---

### 📄 2. 구조 패턴

<div align="center">
  <h4>클래스나 객체를 조합하여 더 큰구조로 만드는 패턴 </h4>
</div>

---

#### 1). Adapter
![](2023-04-19-13-23-27.png)

**ⓐ 특징**
* 호환 되지 않는 인터페이스를 가진 객체들이 엽업하도록 다른 인터페이스를 변환 해줌

**ⓑ 왜 쓰는건가?**
> 누더기 기우는데 사용한다..

**ⓒ 구성요소**

![](2023-04-19-13-29-56.png)

**1. Client**
**2. Client Interface**

**ⓓ 구현**
**ⓔ 예시**

---

### 📄 3. 행동 패턴

<h4 align="center">
클래스와 객체간 서로 상호작용하는 방법이나 책임 분배 방법을 정의
하나의 객체로 수행할 수 없는작업을 여러 객체로 분해하면서 결합도를 낮출수 있음
</h4>

---

#### 1). Template Method


**ⓐ 특징**
```cs
class Animal {
    void Walk();
}
```

**ⓑ 왜 쓰는건가?**
**ⓒ 구성요소**
**ⓓ 구현**
**ⓔ 예시**

https://github.com/JoanStinson/UnityDesignPatternsReference