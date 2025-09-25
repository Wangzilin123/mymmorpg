using Common;
using GameServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Managers
{
     class EntityManager:Singleton<EntityManager>
    {
        private int idx = 0;
        public List<Entity> AllEntities= new List<Entity>();
        public Dictionary<int,List<Entity>> MapEneities = new Dictionary<int,List<Entity>>();


        public void AddEntity(int mapId,Entity entity)
        {
            AllEntities.Add(entity);
            //加入管理器生成唯一ID
            entity.EntityData.Id=++this.idx;

            List<Entity> entities = null;
            if (!MapEneities.TryGetValue(mapId, out entities))
            {
                entities = new List<Entity>();
                MapEneities[mapId] = entities;
            }
            entities.Add(entity);
        }

        public void RemoveEntity(int mapId,Entity entity)
        {
            this.AllEntities.Remove(entity);
            this.MapEneities[mapId].Remove(entity);
        }

    }
}
