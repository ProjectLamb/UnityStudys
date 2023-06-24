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

## Latex : 수식을 마크다운으로
### 1. 위첨자
```latex
$$
x^{2}
$$
```
> $$x^{2}$$

### 2. 아래 첨자
```latex
$$
x_{0}
$$
```
> $$x_{0}, y_{0}$$

### 3. 정렬
```latex
$$
\begin{aligned}
\end{aligned}
$$
```

### 4. 줄바꿈
```latex
\\
$$x + y = 3\\ -x + 3y = 2$
```
> $$x + y = 3\\ -x + 3y = 2$$

### 5. 띄어쓰기
```latex
\,
\;
$local\,minimum$
$local\;minimum$
```
> $local\,minimum$

https://velog.io/@d2h10s/LaTex-Markdown-%EC%88%98%EC%8B%9D-%EC%9E%91%EC%84%B1%EB%B2%95

