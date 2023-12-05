using System.Collections.Generic;

namespace CommandQueuePattern
{
    public class CommandQueue
    {
#region 멤버
        private readonly Queue<ICommand> _queue;
        private bool _isPending;  // it's true when a command is running
#endregion

#region 메서드
        public CommandQueue() {
        }

        public void StartCommand() {
             // if no command is running, start to execute commands
            if(!_isPending) {ExicuteNext();}
        }

        public void ExicuteNext() {
            // if queue is empty, do nothing.
            if(_queue.Count == 0) return;  

            //get a command and setting _isPending to true means this command is running
            var cmd = _queue.Dequeue();
            _isPending = true;

            // listen to the OnFinished event
            cmd.OnCommandFinished += OnCmdFinished;
            cmd.Execute();
        }

        private void OnCmdFinished()
        {
            // current command is finished
            _isPending = false;
            // run the next command
            if(_queue.Count != 0) 
                ExicuteNext();
        }
#endregion
    }
}