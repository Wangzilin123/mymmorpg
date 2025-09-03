using Entities;
using UnityEngine;
using UnityEngine.UI;

public class UINameBar : MonoBehaviour
{
    [SerializeField] private Text avatarName;

    public Character character;

    void Start()
    {
        if (this.character!=null)
        {

        }
    }

    void Update()
    {
        UpdateInfo();
        this.transform.forward=Camera.main.transform.forward;
    }

    void UpdateInfo()
    {
        if (this.character != null)
        {
            string name=this.character.Name+" Lv."+character.Info.Level;
            if (name!=this.avatarName.text)
            {
                this.avatarName.text = name;
            }
        }


    }
}
