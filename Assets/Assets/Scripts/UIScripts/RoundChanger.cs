using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundChanger : MonoBehaviour
{
    public Animator panelAnimator;
    // Update is called once per frame

    public void FadeIntoPanel()
    {
        panelAnimator.SetBool("FadeIn", true);
    }

    public void FadeOutOfPanel()
    {
        panelAnimator.SetBool("FadeIn", false);
    }

    public void OnFadeComplete()
    {
    }
}
