using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM7_eventdriven
{
    public interface State<T> where T : BaseGameEntity{
        public void Enter(T entity);
        public void Execute(T entity);
        public void Exit(T entity);
        public bool OnMessage(T entity, Telegram telegram);
    }
}