using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenHintPlot : MonoBehaviour
{
    public Texture2D[] texture;
    int sceneIndex;
    RawImage ri;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        ri = GetComponent<RawImage>();
        switch (sceneIndex)
        {
            case 1:
                {
                    ri.texture = texture[0];
                    break;
                }
            case 2:
                {
                    ri.texture = texture[1];
                    break;
                }
            default: break;
        }
    }
}
