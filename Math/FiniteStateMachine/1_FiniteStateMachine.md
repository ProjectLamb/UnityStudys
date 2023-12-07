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

FSM

**ⓐ 특징**
유한개의 상태에 따라 다른 행동을 취하는 모델

객체의 행동을 상태라는 클래스 로 분리한것
행동을 전환하는 규칙을 별도로 구현하기 때문에

**ⓑ 사용하는 이유**

코드가 유연하고, 직관적
개인 단위의 행동을 관리, 스포츠, RTS 장르 단체행동 관리
유니티의 씬 실행 단귀 관리

**ⓒ 구성요소**

**ⓓ 구현**

**ⓔ 예시**

유니티 메카님 애니메이션 시스템 다만, FSM의 단점을 보완한 HFSM
