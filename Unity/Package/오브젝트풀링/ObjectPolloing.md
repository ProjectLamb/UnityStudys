오브젝트 풀링으로 
인스턴시에드, 디스트로이를 해보자.

```cs
List<..>
List<particleSystem>
public int poolSize;
public int poolCursor;

lastElement;

풀을 만들기위한 함수


```

### 공식 풀링
```cs
using UnityEngine.Pool;

class Bullet{

    private IObjectPool<Bullet> ManagedPool;

    public void SetManagedPool(IObjectPool<Bullet> pool){
        ManagedPool = pool;
    }

    public void DestroyBullet(){
        ManagedPool.Release(this);
    }

    Invoke("DestroyBullet");
}

```

https://www.youtube.com/watch?v=JxP-kqstMAY&t=380s