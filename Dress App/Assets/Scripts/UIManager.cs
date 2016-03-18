﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private Color32 objectColor;
    private Sprite objectImage;

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

    public void RecolorObject(GameObject obj)
    {
        Image im = GameObject.Find(obj.name).GetComponent<Image>();
        im.color = objectColor;
    }

    public void SetObjectColor(string hex)
    {
        Color c = new Color();
        ColorUtility.TryParseHtmlString(hex, out c);
        objectColor = c;
        print(c.ToString());
    }

    public void none(Sprite s)
    {
        objectImage= s;
    }

    public void SetImage(Sprite im)//ez meg a kép amire megváltoztatod.
    {
        objectImage = im;
    }


    public void ChangeObjectImage(GameObject obj)//Ez a objet, aminek a képét megváltoztatod
    {
        Image im = GameObject.Find(obj.name).GetComponent<Image>();
        im.sprite = objectImage;

    }

}
