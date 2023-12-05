using System;
using UnityEngine;

namespace CommandQueuePattern
{
    public abstract class SomeDependentService 
    {
        public Action OnEndEvent;
    }
}