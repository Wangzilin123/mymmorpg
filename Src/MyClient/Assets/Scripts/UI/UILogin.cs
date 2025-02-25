using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour {

    public InputField username;
    public InputField password;
    [SerializeField] Button btnLogin;
    [SerializeField] Button btnRegister;

    [SerializeField] GameObject RegisterPanel;
    // Use this for initialization
    void Start () {
        RegisterPanel.SetActive(false);
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

    }

}
