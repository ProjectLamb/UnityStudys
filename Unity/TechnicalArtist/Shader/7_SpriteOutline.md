스프라이트 아웃라인 하기

1. Sprite Unlit 으로 생성
2. 이름은 Texture2D로 만들고 레퍼런스를 _MainTex
3. ST-out : 알파 -> in : Add
4. ST-RGB -> Color & ST-알파 -> Alpha
5. UV를 

---

6. Clamp
    1. https://www.google.com/search?q=Shader+clamp&rlz=1C5CHFA_enKR1039KR1039&oq=Shader+clamp&gs_lcrp=EgZjaHJvbWUyBggAEEUYOdIBCDI5MTNqMGo3qAIAsAIA&sourceid=chrome&ie=UTF-8
    2. 각 입력 min, max를 지정하고 그 사이값만 in으로 받아들인다 나머지는 무시하고,
7. Subtract 
8. Edge 
9. 