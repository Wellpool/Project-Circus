using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseP;
    [SerializeField] public GameObject settingsP;
    [SerializeField] public GameObject audioP;
    [SerializeField] public GameObject blankP;

    
    //To allocate panels in order
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject panel3;

    [SerializeField] private int menuDist;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseP.SetActive(false);
        settingsP.SetActive(false);
        audioP.SetActive(false);
        blankP.SetActive(false);

        panel3 = blankP;
        panel2 = blankP;
        panel1 = pauseP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuDist == 0)
            {
                menuDist++;
            }
            else
            {
                menuDist--;
            }
        }

        

        switch (menuDist)
        {
            case 0:
                panel1.SetActive(false);
                Time.timeScale = 1f;
                break;
            case 1:
                panel1.SetActive(true);
                Time.timeScale = 0f;
                panel2.SetActive(false);
                break;
            case 2:
                panel1.SetActive(false);
                panel2.SetActive(true);
                panel3.SetActive(false);
                break;
            case 3:
                panel2.SetActive(false);
                panel3.SetActive(true);
                break;
        }
    }

    public void AudioPan()
    {
        panel3 = audioP;
        menuDist++;
    }

    public void SettingsPan()
    {
        menuDist++;
        panel2 = settingsP;
    }
    
}
