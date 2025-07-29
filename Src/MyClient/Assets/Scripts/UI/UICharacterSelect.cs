using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
using Services;
using SkillBridge.Message;
using TMPro;
using UnityEngine.Purchasing;

public class UICharacterSelect : MonoBehaviour
{
   public GameObject panelCreate;

    public Transform uiCharList;
    public GameObject uiCharInfo;

    public List<GameObject> uiChars = new List<GameObject>();

    private int selectCharacterIdx = -1;

    public UICharacterView characterView;

    [SerializeField] private Button createBtn;
    [SerializeField] private Button playGameBtn;
    void Start()
    {
    }
    private void OnEnable()
    {
        InitCharacterSelect(true);
        createBtn.onClick.AddListener(ShowCreatePanel);
        playGameBtn.onClick.AddListener(OnClickPlay);
    }
    private void OnDisable()
    {
        createBtn.onClick.RemoveListener(ShowCreatePanel);
        playGameBtn.onClick.RemoveListener(OnClickPlay);
    }
    public void InitCharacterSelect(bool init)
    {
        if (init)
        {
            foreach (var old in uiChars)
            {
                Destroy(old);
            }
            uiChars.Clear();
            Debug.Log("User.Instance.Info.Player.Characters.Count:" + User.Instance.Info.Player.Characters.Count);
            for (int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
            {

                GameObject go = Instantiate(uiCharInfo, this.uiCharList);
                UICharInfo chrInfo = go.GetComponent<UICharInfo>();
                chrInfo.info = User.Instance.Info.Player.Characters[i];

                Button button = go.GetComponent<Button>();
                int idx = i;
                button.onClick.AddListener(() => {
                    OnSelectCharacter(idx);
                });

                uiChars.Add(go);
                go.SetActive(true);
            }
            uiCharInfo.SetActive(false);
            OnSelectCharacter(0);
        }
    }


    public void OnSelectCharacter(int idx)
    {
        this.selectCharacterIdx = idx;
        var cha = User.Instance.Info.Player.Characters[idx];
        Debug.LogFormat("Select Char:[{0}]{1}[{2}]", cha.Id, cha.Name, cha.Class);
        User.Instance.CurrentCharacter = cha;
        characterView.CurrentCharacter = ((int)cha.Class - 1);

        for (int i = 0; i < uiChars.Count; i++)
        {
            uiChars[i].GetComponent<UICharInfo>().Selected = i == idx;
        }
        //for (int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
        //{
        //    UICharInfo ci = this.uiChars[i].GetComponent<UICharInfo>();
        //    ci.Selected = idx == i;
        //}
    }

    public void OnClickPlay()
    {
        if (selectCharacterIdx >= 0)
        {
            UserService.Instance.SendGameEnter(selectCharacterIdx);
        }
    }

    void ShowCreatePanel()
    {
        this.gameObject.SetActive(false);
        panelCreate.SetActive(true);
    }
}
