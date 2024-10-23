using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewFloor : MonoBehaviour
{
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameController controller = gameObject.GetComponent<GameController>();
        GameController.instance.IncreaseFloorNum();
        //controller.IncreaseFloorNum(); 
        audioManager.PlaySFX(audioManager.fall);
        SceneManager.LoadScene("TopFloor");
        Debug.Log("NewFloor");
    }
}
