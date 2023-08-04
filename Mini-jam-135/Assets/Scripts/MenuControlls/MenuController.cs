using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject initialMenu;
    public GameObject optionsMenu;
    

    void Start()
    {
        ActiveMenu(initialMenu);
    }

    void Update()
    {
        
    }

    private void HideMenus()
    {
        initialMenu.SetActive (false);
        optionsMenu.SetActive (false);
    }

    public void ActiveMenu (GameObject menu)
    {
        HideMenus();
        menu.SetActive (true);
    }

    public void ExitGame ()
    {
        ApplicationController.ExitGame(); 
    }

    [System.Obsolete]
    public void Play()
    {
        Application.LoadLevel(1);
    }
}
