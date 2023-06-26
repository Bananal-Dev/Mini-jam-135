using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject initialMenu;
    public GameObject optionsMenu;

    void Start()
    {
        PlayerPrefs.SetString("test","Funciona");
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

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
