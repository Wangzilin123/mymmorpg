﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterView : MonoBehaviour {

    [SerializeField] private GameObject[] characters;

    private int currentCharacter = 0;
    public int CurrentCharacter {
        get { return currentCharacter; }
        set
        {
            currentCharacter = value;
            this.UpdateCharacter();
        }
    }
	// Use this for initialization
	void Start () {
        UpdateCharacter();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void UpdateCharacter()
    {
        for (int i = 0; i < 3; i++)
        {
            characters[i].SetActive(i== this.currentCharacter);
        }
    }
}
