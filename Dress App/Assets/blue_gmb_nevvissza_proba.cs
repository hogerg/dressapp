using UnityEngine;
using System.Collections;

public class blue_gmb_nevvissza_proba : MonoBehaviour {
    public Color button_color;
    Renderer ren;
    GameObject ez;

	// Use this for initialization
	void Start () {
        ren = ez.GetComponent<Renderer>();
        button_color = ren.material.color;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClicked(GameObject button)
    {
        print(button.name);
        Renderer ren = button.GetComponent<Renderer>();
        print(ren.material.color.ToString());
    }
}
