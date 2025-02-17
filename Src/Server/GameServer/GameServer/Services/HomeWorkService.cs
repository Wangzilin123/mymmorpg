using Common;
using Network;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Services
{
    class HomeWorkService:Singleton<HomeWorkService>
    {
        public void Init()
        {

        }

        public void Start()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<HomeworkRequest>(this.OnHomeworkRequest);
        }

        void OnHomeworkRequest(NetConnection<NetSession> sender, HomeworkRequest request)
        {
            Log.InfoFormat("UserLoginRequest:Homework:{0}", request.Homework);
        }
        public void Stop()
        {

        }
    }
}
