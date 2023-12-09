namespace Ver3_StaticStateDriven 
{
    class Singleton {
        private static Singleton _instance = null;
        public static Singleton Instance {
            get {
                if(_instance == null) {
                    _instance = new Singleton();
                    return _instance;
                }
                return _instance;
            }
        }
        
    }
}