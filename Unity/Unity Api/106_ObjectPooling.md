# 106 ObjectPooling

게임오브젝트의 생성과 파괴는 성능의 소모가 작지 않다.

따라서 생성과 파괴가 빈번하게 발생한다면(총알, 폭탄 등)

오브젝트 풀링을 통해 일정 개수의 게임오브젝트를 미리 생성하고

활성화/비활성화하여 재사용하는 방식을 활용하는 것이 좋다.

https://rito15.github.io/posts/unity-object-pooling/