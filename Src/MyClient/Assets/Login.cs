using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Network.NetClient.Instance.Init("127.0.0.1",8000);
        Network.NetClient.Instance.Connect();

        SkillBridge.Message.NetMessage mag = new SkillBridge.Message.NetMessage();
        mag.Request = new SkillBridge.Message.NetMessageRequest();
        mag.Request.firstRequest = new SkillBridge.Message.FirstTestRequest();
        mag.Request.firstRequest.Helloworld = "Hello World";
        Network.NetClient.Instance.SendMessage(mag);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
