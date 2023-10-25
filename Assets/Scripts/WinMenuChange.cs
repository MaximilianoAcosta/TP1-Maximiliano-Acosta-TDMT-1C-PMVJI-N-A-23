using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuChange : MonoBehaviour
{
    [SerializeField] string collideWithTag;
    [SerializeField] GameObject sceneController;
    [SerializeField] string sceneToChange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == collideWithTag)
        {
            sceneController.GetComponent<SceneController>().ChangeGameScene(sceneToChange);
        }
    }
}
