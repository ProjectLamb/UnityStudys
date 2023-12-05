using System;

namespace CommandQueuePattern
{
    public interface ICommand
    {
        Action OnCommandFinished { get; set; }

        void Execute();
    }
}