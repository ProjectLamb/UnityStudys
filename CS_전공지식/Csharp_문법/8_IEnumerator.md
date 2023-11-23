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

## 🧑🏻‍💻 8. 열거형 (IEnumerator & IEnumerable)

### 📄 1. 개요

#### 클래스 내부 자료를 순회 하는데 사용


IEnumerator를 통해 열거자를 정의하고, IEnumerable를 통해 열거자를 접근한다.
열거형 클래스를 만들떄, 따라서 둘 모두는 같이 구현해야 한다.
// When you implement IEnumerable, you must also implement IEnumerator.

보통 이런 식으로 사용하나 보다.
1. 원래 배열 자료구조를 가지고 있다.
2. 그냥 사용하면 그냥 그 배열 자료구조를 사욜한다.
3. 만약 IEnumerator을 사용하고 싶다면. 가지고 있는 배열 자료를이용해 IEnumerator형식 클래스를 new 하고 리턴한다

지원하는 열거자를 접근, 노출하는데 사용하는 인터페이스.
```cs
public interface IEnumerable
{
	IEnumerator GetEnumerator();
}
```

```cs
public interface IEnumerator
{
	object Current
	{
		get;
	}

	bool MoveNext();
	
    void Reset();
}
```

인덱싱 Get, Set
```cs
public T this[int index]
{
	get
	{
		if ((uint)index >= (uint)_size)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		return _items[index];
	}
	set
	{
		if ((uint)index >= (uint)_size)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		_items[index] = value;
		_version++;
	}
}
```