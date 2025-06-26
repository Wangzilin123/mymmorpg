using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelect : MonoBehaviour {

    [SerializeField] private GameObject panelCreate;
    [SerializeField] private GameObject panelSelect;

    [SerializeField] private GameObject btnCreateCancel;

    [SerializeField] private InputField charName;
    //CharacterClass charClass;

    [SerializeField] private Transform uiCharList;
    [SerializeField] private GameObject uiCharInfo;

    [SerializeField] private List<GameObject> uiChars = new List<GameObject>();

    private int selectCharacterIdx = -1;

    public UICharacterView characterView;

	// Use this for initialization
	void Start ()
    {
        InitCharacterSelect(true);

    }
	
    public void InitCharacterSelect(bool init)
    {
        panelCreate.SetActive(false);
        panelSelect.SetActive(true);

        if (init)
        {
            foreach (var old in uiChars)
            {
                Destroy(old);
            }
            uiChars.Clear();

            for (int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
            {
                GameObject go = Instantiate(uiCharInfo,this.uiCharList);
                UICharInfo chrInfo = go.GetComponent<UICharInfo>();
                //chrInfo.
            }
        }
    }
}
