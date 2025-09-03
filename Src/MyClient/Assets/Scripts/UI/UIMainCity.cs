using Models;
using UnityEngine;
using UnityEngine.UI;

public class UIMainCity : MonoBehaviour
{
    [SerializeField] private Text avatarName;
    [SerializeField] private Text avatarLevel;

    void Start()
    {
        this.UpdateAvatar();
    }


    void UpdateAvatar()
    {
        this.avatarName.text = string.Format("{0}[{1}]",User.Instance.CurrentCharacter.Name,User.Instance.CurrentCharacter.Id); //User.Instance.CurrentCharacter.Name;
        this.avatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
    }

    void Update()
    {
        
    }
}
