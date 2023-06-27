using UnityEngine;

public class DoorState : MonoBehaviour
{
    bool doorOpen = false;
    public Animator anim;
    bool isOpen, isClosed = false;
    public bool isActiveTrig;
    float sec = 1f;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        
        
    }
    public void stateDoor()
    {

        if (!doorOpen)
        {
            doorOpen = true; isOpen = true; isClosed = false;
            anim.SetBool("isOpen", true);
            if (time > sec & isOpen)
            {
                Debug.Log("Дверь открывается");
                time = 0;
            }
            time += Time.deltaTime;
            anim.SetBool("isClosed", false);
            anim.SetBool("isOpened", true);
        }
        else
        {
            doorOpen = false; isOpen = false; isClosed = true;
            anim.SetBool("isClosed", true);
            
            if (time > sec & isClosed)
            {
                Debug.Log("Дверь закрывается");
                time = 0;
            }
            time += Time.deltaTime;
            anim.SetBool("isOpen", false);
            anim.SetBool("isOpened", false);
            doorOpen = false;
        }
    }
}
