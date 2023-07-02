using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnTriggerList : MonoBehaviour
{
    public Button but;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        but.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            but.gameObject.SetActive(false);
    }
}
