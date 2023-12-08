namespace FSM4_state_generic {
    public interface State<T> where T : class {
        public void Enter(T entity);
        public void Execute(T entity);
        public void Exit(T entity);
    }
}