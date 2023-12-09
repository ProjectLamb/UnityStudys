using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM6_singletonstate
{
    public interface State<T> where T : class {
        public void Enter(T entity);
        public void Execute(T entity);
        public void Exit(T entity);
    }
}