# Unity Attribute
인스펙터 작업에 매우 유용한 Attribute 팁

### 1. Header
```cs
[Header(string)]
한정자 type member;
```
변수 바로 위에 머리말을 달아줍니다.
관련있는 변수끼리 묶을 때 좋습니다.

### 2. SerializeField
``` cs
[SerializeField]
private type member;
```
private로 선언한 변수를 인스펙터에 나타내줍니다.

인스펙터에서 바로 수정도 가능합니다.

### 3. Tooltip 
``` cs
[Header(string)]
한정자 type member;
```
변수에 마우스를 올리면 말풍선을 나타내줍니다.
요소에 마우스를 올려두면 말풍선이 나오고 String부분에 적은 내용이 나온다

### 4. Range
``` cs
[Range(int, int)]
한정자 int member;
```

상수형 변수들의 범위를 지정해줍니다.

인스펙터 창에는 슬라이더가 생겨 그걸로 값을 변경할 수도 있습니다.

특정 값을 초과하지 않길 원할 때 사용해도 좋습니다.

### 5. RequireComponent
```cs
[RequireComponent(typeof(Rigidbody))]
public class Class : MonoBehaviour
{
    ...
}
```
클래스 밖에다가 설정해두면 된다
이렇게 하면 Rigidbody 컴포넌트를 자동으로 부착해줘서 오류를 사전에 방지한다

### 6. ExecuteInEditMode
```cs
[ExecuteInEditMode]
public class Class : MonoBehaviour
{
    ...
}
```
지정된 컴포넌트는 EditMode에서도 동작 되도록 할때 사용

에디터에서 플레이 시키지 않아도 지정된 컴포넌트의 주요 함수가 호출됨


### 7. TextArea
```cs
[TextArea(5, 7)]
public string TextAreaText;
```
string 타입의 변수에 사용됨
Multiline과 크게 다르지 않지만 폭에 맞추어 자동으로 줄바꿈이 되고 스크롤바를 표시합니다.


### 8. MenuItem
```cs
[UnityEditor.MenuItem("MyMenu/Test")]
static void Function(){
    ...
}
```
메뉴바를 추가하는 기능으로 static 함수를 메뉴바에 추가 시켜 실행 시키도록 할 수 있음


### 9. ContextMenu
```cs
[ContextMenu("Context Test")]
private void ContextMenuTest()
{
    ...
}
```

컴포넌트 이름 부분을 오른쪽 마우스 클릭하거나 톱니모양(점3개) 버튼을 클릭해 나오는 목록에 함수를 실행 시키는 메뉴를 추가 할 수 있음

### 10. HelpURL
```cs
[HelpURL(string)]
```

### 11. ColorUsage
```cs
[ColorUsage(...)]
public Color color2;
```
알파 값 사용/미사용, HDR용 등으로 설정합니다.

### 참조
https://kaluteblog.tistory.com/5