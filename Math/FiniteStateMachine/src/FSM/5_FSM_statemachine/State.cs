using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM5_statemachine
{
    public interface State<T> where T : class {
        public void Enter(T entity);
        public void Execute(T entity);
        public void Exit(T entity);
    }
}