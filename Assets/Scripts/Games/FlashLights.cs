using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLights : MonoBehaviour {

    public CanvasGroup canvasGroup;

    public void OnFlashImg()
    {
        canvasGroup.alpha = 1;
        StartCoroutine("Display");
    }

    IEnumerator Display()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = canvasGroup.alpha - 0.02f;
            yield return 0;
        }
    }
}
