using Models;
using UnityEngine;
using UnityEngine.UI;

public class UIMainCity : MonoBehaviour
{
    [SerializeField] private Text avatarName;
    [SerializeField] private Text avatarLevel;

    [SerializeField] private Button backChaSelect;

    void Start()
    {
        this.UpdateAvatar();
    }

    private void OnEnable()
    {
        backChaSelect.onClick.AddListener(BackToCharSelect);
    }
    private void OnDisable()
    {
        backChaSelect.onClick.RemoveListener(BackToCharSelect);
    }

    void UpdateAvatar()
    {
        this.avatarName.text = string.Format("{0}[{1}]",User.Instance.CurrentCharacter.Name,User.Instance.CurrentCharacter.Id); //User.Instance.CurrentCharacter.Name;
        this.avatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
    }

    void Update()
    {
        
    }

    public void BackToCharSelect()
    {
        SceneManager.Instance.LoadScene("CharSelect");
        Services.UserService.Instance.SendGameLeave();
    }
}
