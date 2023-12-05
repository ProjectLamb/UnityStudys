using System;

namespace CommandQueuePattern 
{
    public class FirstCmd : ICommand {
        #region 멤버
        private readonly SomeDependentService;
        public Action OnCommandFinished {get; set;}
        #endregion

        #region 메소드
        public FirstCmd(SomeDependentService owner) {
            this._owner = owner;
        }

        //Implement ICommnad Execute();
        public void Execute() 
        {
            /* Logic With SomeDependentService */
            SomeDependentService.OnEndEvent += OnEndEvent;
        }

        public void OnEndEvent() {
            /*끝이 날때 자기자신의 이벤트를 등록 해제한다*/
            SomeDependentService.OnEndEvent -= OnEndEvent;
            OnCommandFinished?.Invoke();
        }
        #endregion
    }
}