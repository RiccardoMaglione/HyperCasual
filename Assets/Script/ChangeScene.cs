using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject PanelOption;

    public void GoToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToOption()
    {
        PanelMenu.SetActive(false);
        PanelOption.SetActive(true);
    }
    public void BackToMenu()
    {
        PanelOption.SetActive(false);
        PanelMenu.SetActive(true);
    }
}
