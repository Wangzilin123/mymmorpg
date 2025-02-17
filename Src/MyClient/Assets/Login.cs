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

        SkillBridge.Message.NetMessage mag2 = new SkillBridge.Message.NetMessage();
        mag2.Request = new SkillBridge.Message.NetMessageRequest();
        mag2.Request.homeworkRequest = new SkillBridge.Message.HomeworkRequest();
        mag2.Request.homeworkRequest.Homework = "HomeWork Finish";
        Network.NetClient.Instance.SendMessage(mag2);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
