using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
using Services;
using SkillBridge.Message;
using TMPro;

public class UICharacterCreate : MonoBehaviour
{
    [SerializeField] private GameObject selectPanel;
    public Button btnCreateCancel;

    public TMP_InputField charName;
    CharacterClass charClass;

    public Image[] titles;

    public TMP_Text descs;

    public TMP_Text[] names;

    private int selectCharacterIdx = -1;

    public UICharacterView characterView;

    [SerializeField] private Button soliderBtn;
    [SerializeField] private Button wizaedBtn;
    [SerializeField] private Button archerBtn;

    [SerializeField] private List<GameObject> icons;

    [SerializeField] private Button startGameBtn;
    void Start()
    {
        showIcon();
        UserService.Instance.OnCharacterCreate = OnCharacterCreate;
    }
    private void OnEnable()
    {
        btnCreateCancel.onClick.AddListener(BackSelectPanel);
        soliderBtn.onClick.AddListener(() => OnSelectClass(1));
        wizaedBtn.onClick.AddListener(() => OnSelectClass(2));
        archerBtn.onClick.AddListener(() => OnSelectClass(3));
        startGameBtn.onClick.AddListener(OnClickCreate);
    }
    private void OnDisable()
    {
        btnCreateCancel.onClick.RemoveListener(BackSelectPanel);
        soliderBtn.onClick.RemoveListener(() => OnSelectClass(1));
        wizaedBtn.onClick.RemoveListener(() => OnSelectClass(2));
        archerBtn.onClick.RemoveListener(() => OnSelectClass(3));
        startGameBtn.onClick.RemoveListener(OnClickCreate);
    }

    public void InitCharacterCreate()
    {
        this.gameObject.SetActive(true);
    }

    public void OnClickCreate()
    {
        if (string.IsNullOrEmpty(this.charName.text))
        {
            MessageBox.Show("ÇëÊäÈë½ÇÉ«Ãû³Æ");
            return;
        }
        UserService.Instance.SendCharacterCreate(this.charName.text, this.charClass);
        if (selectCharacterIdx >= 0)
        {
            UserService.Instance.SendGameEnter(selectCharacterIdx);
        }
    }

    public void OnSelectClass(int charClass)
    {
        this.charClass = (CharacterClass)charClass;

        characterView.CurrentCharacter = charClass - 1;
        showIcon();

        for (int i = 0; i < 3; i++)
        {
            titles[i].gameObject.SetActive(i == charClass - 1);
            names[i].text = DataManager.Instance.Characters[i + 1].Name;
        }

        descs.text = DataManager.Instance.Characters[charClass].Description;
    }

    void OnCharacterCreate(Result result, string message)
    {
        if (result == Result.Success)
        {
            //BackSelectPanel();
        }
        else
            MessageBox.Show(message, "´íÎó", MessageBoxType.Error);
    }

    public void OnSelectCharacter(int idx)
    {
        this.selectCharacterIdx = idx;
        var cha = User.Instance.Info.Player.Characters[idx];
        Debug.LogFormat("Select Char:[{0}]{1}[{2}]", cha.Id, cha.Name, cha.Class);
        User.Instance.CurrentCharacter = cha;
        characterView.CurrentCharacter = idx;// ((int)cha.Class - 1);

        //for (int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
        //{
        //    UICharInfo ci = this.uiChars[i].GetComponent<UICharInfo>();
        //    ci.Selected = idx == i;
        //}
    }
    void showIcon()
    {
        descs.text = DataManager.Instance.Characters[1].Description;
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].SetActive(i == characterView.CurrentCharacter);
        }
        for (int i = 0; i < 3; i++)
        {
            titles[i].gameObject.SetActive(i == characterView.CurrentCharacter);
        }
    }

    void BackSelectPanel()
    {
        this.gameObject.SetActive(false);
        selectPanel.SetActive(true);
    }

}
