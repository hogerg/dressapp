using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public void DisableBool(Animator anim)
    {
        anim.SetBool("isDisplayed", false);
    }

    public void EnableBool(Animator anim)
    {
        anim.SetBool("isDisplayed", true);
    }

    public void NegateBool(Animator anim)
    {
        anim.SetBool("isDisplayed", !anim.GetBool("isDisplayed"));
    }

    public void NavigateTo(int scene)
    {
        Application.LoadLevel(scene);
    }
}
