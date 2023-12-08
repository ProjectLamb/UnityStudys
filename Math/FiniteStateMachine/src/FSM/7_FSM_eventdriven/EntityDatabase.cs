using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM7_eventdriven
{
    public class EntityDatabase 
    {
        private static readonly EntityDatabase _instance = new EntityDatabase();
        private bool _isSetup = false;
        public static EntityDatabase Instance => _instance;


        private Dictionary<string, BaseGameEntity> entityDictionary;

        public void Setup() {
            entityDictionary = new Dictionary<string, BaseGameEntity>();
            _isSetup = true;
        }

        public void RegisterEntity(BaseGameEntity newEntity){
            entityDictionary.Add(newEntity.EntityName, newEntity);
        }

        public BaseGameEntity GetEntityFromName(string entityName) {
            BaseGameEntity res = null;
            entityDictionary.TryGetValue(entityName, out res);
            return res;
        }

        public void RemoveEntity(BaseGameEntity removeEntity) {
            entityDictionary.Remove(removeEntity.EntityName);
        }
    }
}