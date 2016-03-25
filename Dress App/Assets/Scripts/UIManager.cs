using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.IO; 

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

    public void filebol_olvasas()
    {
      //  try
      //  {
            string obj_name;
        string sprite_name;
            Sprite s = new Sprite();

            string fileName = Application.dataPath + "/" + "file.txt";
        Debug.Log(fileName);
            StreamReader f = new StreamReader(fileName, Encoding.Default);

            while (!f.EndOfStream)
            {
                obj_name = f.ReadLine();
                Debug.Log(obj_name);

                GameObject obj=GameObject.Find(obj_name);
                ChangeObjectImage(obj);

                sprite_name = f.ReadLine();
                Debug.Log(sprite_name);

                //   Sprite s = Sprite.FindObjectOfType<Sprite>.name(line);
                string utvon = Application.dataPath + "/" + "Resources" + "/" + "dresses" + sprite_name;//   D:\posza\Posza\suli\bme\szakirany\onlab\gitlab_cucc\dressapp\Dress App\Assets\Resources\dresses
            Debug.Log(utvon);
            // Sprite s = Resources.Load(utvon, typeof(Sprite)) as Sprite;
            // GetComponent(SpriteRenderer).sprite = line;
            //   GameObject.Find(obj_name).GetComponent().sprite = sprites.GetSprite("Sprite1");
          //  obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(utvon);
            //  obj.GetComponent<SpriteRenderer>()
            s = Resources.Load<Sprite>(utvon);
            SetImage(s);
        }

      /*  }
        catch (Exception e)
        {
            Debug.Log(e);
        }*/
    }

}
