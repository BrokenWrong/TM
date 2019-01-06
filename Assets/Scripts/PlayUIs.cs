using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIs : MonoBehaviour {
    public CanvasGroup canvasGroup;
    public GameManagers gameManagers;

    public void SetCanvasGroup(bool bl)
    {
        if(bl == true)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }

    }

    public void MenuClick()
    {
        Debug.Log("Menu");
    }

    public void CgClick()
    {
        gameManagers.CgClick();
    }

    public void SoundClick()
    {

    }

    public void AgainClick()
    {

    }

    public void Sp1Click()
    {

    }

    public void Sp2Click()
    {

    }

    public void Sp3Click()
    {

    }

    public void LeftClick()
    {

    }

    public void RightClick()
    {

    }
}
