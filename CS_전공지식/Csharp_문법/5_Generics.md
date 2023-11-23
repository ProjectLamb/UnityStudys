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

    h2 { border-top: 12px solid #bf8bff; border-left: 5px solid #bf8bff; border-right: 5px solid #bf8bff; background-color: #bf8bff; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #5b0d7c !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## 🧑🏻‍💻 5. 제네릭 (Generics)

### 📄 1. 개요
#### 클래스나, 메서드 정의할떄 타입별 재사용에 매우 큰 도움을 준다.

* 클래스나 함수를 특정 자료형으로 제한하지 않고, 다양한 타입으로 정의 가능하다.
델리게이트에도 유용하다.

### 📄 2. 제네릭 정의하기

<details>
    <summary><strong>하드코딩 사례</strong></summary>
    <h5>동일한 로직이지만 자료형이 다양하다는 이유로 메소드, 클래스를 더 만드는 사례..</h5>

```cs

int[] SortInt(int[] _Nums) {
    int[] retArray = (int[])_Nums.Clone();
    Array.Sort(retArray);
    return retArray;
}

string[] SortString(String[] _Strings) {
    string[] retArray = (String[])_Strings.Clone();
    Array.Sort(_Strings);
    return retArray;
}

void PrintIntArray(int[] _arr){
    string ret = "";
    for(int i = 0 ; i < _arr.Length; i++){
        ret += _arr[i].ToString() + " ";
    }
    Debug.Log(ret);
}
void PrintStringArray(string[] _arr){
    string ret = "";
    for(int i = 0 ; i < _arr.Length; i++){
        ret += _arr[i] + " ";
    }
    Debug.Log(ret);
}

/*********************************************************************************/
int[] intInputArr = new int[] {5 , 24,1 ,6,7, 2, 7, 23, 7,9,1};
PrintIntArray(intInputArr);
PrintIntArray(SortInt(intInputArr)); // 24 23 9 7 7 7 6 5 2 1 1 
PrintIntArray(intInputArr); // 24 23 9 7 7 7 6 5 2 1 1 
PrintIntArray(intInputArr);

string[] stringInputArr = new string[] {"qwtq", "bvienor", "advwr", "otuhe", "mncbs", "zsfqejv"};
PrintStringArray(stringInputArr);
PrintStringArray(SortString(stringInputArr)); // 24 23 9 7 7 7 6 5 2 1 1 
PrintStringArray(stringInputArr); // 24 23 9 7 7 7 6 5 2 1 1 
PrintStringArray(stringInputArr);
```
</details>

<details>
    <summary><strong>제네릭을 사용한 사례</strong></summary>
    <h5>제네릭을 사용함으로 획기적으로 메소드를 줄인 모습</h5>

```cs
public T[] SortGeneric<T>(T[] _Values, IComparer<T>? comparer) {
    T[] retArray = (T[])_Values.Clone();
    Array.Sort(retArray, comparer);
    return retArray;
}
public void PrintGenericArray<T>(T[] _Values){
    string ret = "";
    Array.ForEach(_Values, (E) => {ret += E.ToString();});
    Debug.Log(ret);
}

/*********************************************************************************/
int[] intInputArr = new int[] {5 , 24,1 ,6,7, 2, 7, 23, 7,9,1};
PrintGenericArray<int>(intInputArr);
PrintGenericArray<int>(SortGeneric<int>(intInputArr, null));
PrintGenericArray<int>(intInputArr);
PrintGenericArray<int>(intInputArr);

string[] stringinputArr = new string[] {"qwtq", "bvienor", "advwr", "otuhe", "mncbs", "zsfqejv"};
PrintGenericArray<string>(stringinputArr);
PrintGenericArray<string>(SortGeneric<string>(stringinputArr, null));
PrintGenericArray<string>(stringinputArr);
PrintGenericArray<string>(stringinputArr);
```
</details>

### 📄 3. 타입 범위의 한정

#### 1. Value 타입으로 제약 (struct)

```cs
public class GenericClassWithValueType<T> : where T : struct {

}
```

#### 2. Reference 타입으로 제약 (class)

```cs
public class GenericClassWithReferenceType<T> : where T : class {

}
```

#### 3. 제네릭 타입이 특정클래스나, 인터페이스를 상속 받아야 된다는 제약 (Class)
* 제네릭 T를 특정 인터페이스나, 클래스로 취급하고 하고싶다면?
즉. 그냥 T일떄는 자동완성이 특정 클래스를 가지고 나타나지 않더라..
```cs
// T는 _SUPER_CLASS_ 클래스의 파생 클래스여야 한다.
public class GenericClassWithSuper<T> : where T : _SUPER_CLASS_ {

}

// T는 _ABSTRACT_CLASS_ 클래스의 파생 클래스여야 한다.
public class GenericClassWithAbstract<T> : where T : _ABSTRACT_CLASS_ {

}

// T는 _INTERFACE_ 인터페이스를 구현해야 된다.
public class GenericClassWithInterface<T> : where T : _INTERFACE_ {

}

// 응용 버젼으로 
// T는 _ABSTRACT_CLASS_ 클래스에 파생되면서, 
// _INTERFACE_ 인터페이스가 구횬 되야 한다
public class GenericClass<T> : where T : _ABSTRACT_CLASS_, _INTERFACE_ {

}
```


<details>
    <summary><strong>예시 코드</strong></summary>

```cs
public class HeroManager<T> : where T : Hero 
{

}

public abstract class Hero
{
    protected void Attack();
    protected void Die();
} 

public class Mage : Hero{
    public Mage() {}
}
public class Ranger : Hero{
    public Ranger() {}
}
public class Fighter  : Hero{
    public Fighterv() {}
}

```

</details>

### 📄 4. 팩토리 매소드

```cs
T HeroFactory<T>(string heroName) : where T : Hero, new ()
{
    T newHero = new T();
    newHero.Name = heroName;
    return newHero;
}

var archer = HeroFactory<Archer>("Legolas");
var archer = HeroFactory<Mage>("Gandalf");
```

### 📄 참조
1. https://www.csharpstudy.com/CSharp/CSharp-generics.aspx
2. https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/generics/generic-methods
3. https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/generics/generic-classes