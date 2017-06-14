using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {
    private Vector3 screenPoint,startPoint;
    private Vector3 offset;
    public GameObject cart;
    public AudioClip joy, sad;
    AudioSource aud;
    
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        startPoint = transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    void OnMouseUp()
    {
        if(Mathf.Ceil( cart.transform.position.x) == Mathf.Ceil( transform.position.x) && Mathf.Ceil(cart.transform.position.y) == Mathf.Ceil(transform.position.y))
        {
            aud.PlayOneShot(joy);
            gameObject.transform.localScale=new Vector3(0, 0, 0);
            //gameObject.SetActive(false);
        }
        else
        {
            transform.position = startPoint;
            aud.PlayOneShot(sad);
        }
    }
}
