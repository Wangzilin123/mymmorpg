using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillBridge.Message;
using Services;

public class UILogin : MonoBehaviour {

    public InputField username;
    public InputField password;
    [SerializeField] Button btnLogin;
    [SerializeField] Button btnRegister;

    [SerializeField] GameObject RegisterPanel;
    // Use this for initialization
    void Start () {
        RegisterPanel.SetActive(false);
        UserService.Instance.OnLogin = OnLogin;
    }

    private void OnEnable()
    {
        btnLogin.onClick.AddListener(OnClickLogin);
        btnRegister.onClick.AddListener(OnClickRegister);
    }
    private void OnDisable()
    {
        btnRegister.onClick.RemoveListener(OnClickRegister);
        btnLogin.onClick.RemoveListener(OnClickLogin);
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void OnClickRegister()
    {
        RegisterPanel.SetActive(true);
    }
    public void OnClickLogin()
    {
        if (string.IsNullOrEmpty(this.username.text))
        {
            MessageBox.Show("请输出账号");
            return;
        }
        if (string.IsNullOrEmpty(this.password.text))
        {
            MessageBox.Show("请输出密码");
            return;
        }
        UserService.Instance.SendLogin(this.username.text,this.password.text);
    }
    void OnLogin(Result result,string message)
    {
        if (result==Result.Success)
        {
            SceneManager.Instance.LoadScene("CharSelect");
        }
        else
        {
            MessageBox.Show(message,"错误",MessageBoxType.Error);
        }
    }
}
