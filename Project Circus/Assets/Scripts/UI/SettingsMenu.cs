using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pMenu;
    [SerializeField] private GameObject _sMenu;
    [SerializeField] private GameObject _aMenu;

    private bool _audioOpen;
    private bool _settingsOpen;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }


    public void SettingsBack()
    {
        _pMenu.SetActive(true);
        _sMenu.SetActive(false);
    }

    public void AudioBack()
    {
        _aMenu.SetActive(false);
        _sMenu.SetActive(true);
    }
}
