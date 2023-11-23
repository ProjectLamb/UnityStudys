```java
import java.util.*;

/*********************************************************************************
*
* 스레드 생성
*
*********************************************************************************/

Thread thread = new Thread(new Runnable() {
    @Override
    public void run() {
        System.out.println("We are now in Thread : " + Thread.currentThread().getName());
        System.out.println("Thread Priority : " + Thread.currentThread().getPriority());
    }
});

Thread thread = new Thread(() => {
    System.out.println("We are now in Thread : " + Thread.currentThread().getName());
});

thread.setUncaughtExceptionHandler(new Thread.UncaughtExceptionHandler() {
    @Override
    public void uncaughtException(Thread t, Throwable e) {
        System.out.println("a critical error happend in thread" + t.getName() + " The error is " + e.getMessage());
    }
});

thread.setName("😋 New Worker Thread 😋");


/*********************************************************************************
*
* 스레드 실행
*
*********************************************************************************/

thread.start();

/*********************************************************************************
*
* 스레드 상속
*
*********************************************************************************/

private static class NewThread extends Thread {
    @Override
    public void run() {
        System.out.println("Hello from " + this.getName());
    }
}

private static abstract class HackerThread extends Thread{
    protected Vault vault;
    public HackerThread(Vault vault) {
        this.vault = vault;
        this.setName(getClass().getSimpleName());
        this.setPriority(Thread.MAX_PRIORITY);
    }

    @Override
    public void start(){
        System.out.println("Starting Thread " + this.getName());
        super.start();
    }
}

private static class DescendingHackerThread extends HackerThread{
    public DescendingHackerThread(Vault vault){
        super(vault);
    }

    @Override
    public void run(){
        for(int i = MAX_PASSWORD; i >= 0; i--){
            if(vault.getPasswordIsCorrect(i)){
                System.out.println(this.getName() + " guessed the password : " + i);
                System.exit(0);
            }
        }
    }
}
```