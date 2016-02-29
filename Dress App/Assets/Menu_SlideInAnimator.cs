using UnityEngine;
using System.Collections;

public class Menu_SlideInAnimator : MonoBehaviour {

    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float posX = transform.position.x;
        float closedX = -7.2f;
        float openX = -5.2f;
        float divider = 10f;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000f))
        {
            Vector3 dP = new Vector3((openX - posX) / divider, 0, 0);
            //transform.position = new Vector3(-5.2f, 0, 0);
            transform.position = transform.position + dP;
        }
        else
        {
            Vector3 dP = new Vector3((posX - closedX) / divider, 0, 0);
            //transform.position = new Vector3(-7.2f, 0, 0);
            transform.position = transform.position - dP;
        }
	}
}
