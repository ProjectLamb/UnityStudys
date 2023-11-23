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

#### 커스텀 IEnumerator
```cs
using System;
using System.Collections;
using System.Collections.Generics;
public class CustomWaitUnitl : IEnumerator 
{
    Func<bool> predicate;
    public object Current {get {return null;}}
    public CustomWaitUnitl(Func<bool> _predicate){predicate=_predicate;}
    public bool MoveNext() 
    {
        return !predicate;
    }
    public void Reset() { throw new NotImplementedException(); }
}
```

https://github.com/Menyus777/Design-Patterns-for-Unity-Using-Coroutines#what-are-coroutines-good-for-in-unity