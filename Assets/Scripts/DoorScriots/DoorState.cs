using UnityEngine;

public class DoorState : MonoBehaviour
{
    public AudioClip audio;
    public AudioSource player;
    bool doorOpen = false;
    public Animator anim;
    bool isOpen, isClosed = false;
    public bool isLocked = true;
    //public bool isActiveTrig;
    float sec = 1f;
    float time = 0;
    public Canvas canvas, playerCanvas;
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
        if (!isLocked)
        {
            if (!doorOpen)
            {
                doorOpen = true; isOpen = true; isClosed = false;
                anim.SetBool("isOpen", true);
                player.clip = audio;
                player.Play();
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
                isOpen = false; isClosed = true;
                anim.SetBool("isClosed", true);
                player.clip = audio;
                player.Play();
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
        else if (isLocked)
        {
            canvas.gameObject.SetActive(true);
            playerCanvas.gameObject.SetActive(false);
        }
    }
}
