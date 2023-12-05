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
    .quest { font-weight: bold; color: #A5F !important;}
    h2 { border-top: 12px solid #D40; border-left: 5px solid #D40; border-right: 5px solid #D40; background-color: #D40; color: #FFF !important; font-weight: bold;}
    h3 { border-top: 12px solid #F90; border: 5px solid #F90; background-color: #F90; color: #FFF !important;}
        summary { cursor:pointer; font-weight:bold; color : #0F0 !important;}

    .red{color: #d93d3d;} 
    .darkred{color: #470909;} 
    .orange{color: #cf6d1d;} 
    .yellow{color: #DD3;} 
    .green{color: #25ba00;} 
    .blue{color: #169ae0;} 
    .pink{color: #d10fd1;} 
    .dim{color : #666666;} 
    .lime{color : #addb40;}

    .container {
        display : flex; 
        flex-direction:row;
        align-items:space-evenly;
    }
    .item {
        margin-right:2%;
    }

    @media screen and (min-width:1001px){
        .container {
            width: 90%;
            flex-wrap : nowrap;
            justify-content:space-evenly;
        }
    }
    
    @media screen and (max-width:1000px){
        .container {
            width: 98%;
            flex-wrap : nowrap;
            justify-content:space-evenly;
        }
    }
    
    @media screen and (max-width:799px){
        .container {
            justify-content:left;
            flex-wrap : wrap;
        }
    }
</style>

### 📄 5. 구조체

#### 1). 클래스 VS 구조체 

* 타입차이에 따른 메모리 할당
  ||Class|Struct|
  |:--|:--|:--|
  |타입|Reference|Value|
  |메모리할당|Heap|Stack|

**stack**
* 지역 변수를 저장하며, 실행 중인 함수를 찾아 계산을 수행함
* 변수들은 Stack으로 저장(후입선출)

**heap**
* 참조 타입들이 이 곳에 할당된다.
* 메모리 누수의 대상이 된다.


#### 2). 클래스 써버리지 뭘.. 왜?
* 아까말했듯 클래스는 힙영역에 할당된다. 반대로 구조체는 Stack에 들어가므로
가비지컬렉터가 덜 일해도 된다. 
메소드를 쓰지 않고 오직 데이터만 그룹 시키고 싶을때, 딱좋다~!
* 그리고 생성자 오버로딩에 사용되기도 한다.

#### 3). 사용법

**구조체가 가능한것**

* **ⓐ 프로퍼티 : get, set**
  * 예시
      ```cs
      class _className_ 
      {
          _type_ _fildName_;
          _접근한정자_ _type_ _프로퍼티명_{get; set;}
          _접근한정자_ _type_ _프로퍼티명_
          {
              get{return;}
              set{return;}
          }
      }
      ```
* **ⓑ 생성자**
* **ⓒ 이벤트**
* **ⓓ System.Object 메서드 ```readonly override```**
* **ⓔ 인터페이스 구현**
    * 다음은 System.Collection.Generic의 List클래스 내부 스코프에 정의된 구조체다.
    ```cs
    public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
	{
		private readonly List<T> _list;

		private int _index;

		private readonly int _version;

		private T _current;

		public T Current => _current;

		object? IEnumerator.Current
		{
			get
			{
				if (_index == 0 || _index == _list._size + 1)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
				}
				return Current;
			}
		}

		internal Enumerator(List<T> list)
		{
			_list = list;
			_index = 0;
			_version = list._version;
			_current = default(T);
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			List<T> list = _list;
			if (_version == list._version && (uint)_index < (uint)list._size)
			{
				_current = list._items[_index];
				_index++;
				return true;
			}
			return MoveNextRare();
		}

		private bool MoveNextRare()
		{
			if (_version != _list._version)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			_index = _list._size + 1;
			_current = default(T);
			return false;
		}

		void IEnumerator.Reset()
		{
			if (_version != _list._version)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			_index = 0;
			_current = default(T);
		}
	}
    ```

#### 4). 참조 

[① C# 구조체를 써야하는 이유](https://dhy948.tistory.com/13)
[② C# 구조체 (프로퍼티 & 생성자 & 이벤트)](https://www.tutorialsteacher.com/csharp/csharp-struct)

* property & constructor & event
    ```cs
    public struct Coords {
        private int _x, _y;
        public Coordinate(int x, int y) { this.x = x; this.y = y; }
            // 2. 생성자 
                //_접근한정자_ _type_ _프로퍼티명_{get{...}; set{...};}
        public int x //1. property
        {
            get{ return _x; }
            set{ _x = value; CoordinatesChanged(_x);}
        }
        public int y //1. property
        {
            get{ return _y; }
            set{ _y = value; CoordinatesChanged(_y);}
        }
        
        public readonly override string ToString() => $"({x}, {y})"; 
            //4. readonly override
        public event Action<int> CoordinatesChanged;
            //3. 이벤트
    }
    ```
    
* 좌표가 변경 될 때 발생하는 CoordinatesChanged event 가 포함되어 있습니다. 

* 다음 예제는 이벤트 처리를 보여줍니다. xyCoordinatesChanged
    ```cs
    class Program
    {
        static void Main(string[] args) {
            Coordinate point = new Coordinate();   
            point.CoordinatesChanged += StructEventHandler;
            point.x = 10; point.y = 20;
        }

        static void StructEventHandler(int point) {
            Console.WriteLine("Coordinate changed to {0}", point);
        }
    }
    ```
