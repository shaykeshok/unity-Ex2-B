using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpgrade : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] int speed=3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Speed Upgrade triggered by player");
            var keyboardMover = other.GetComponent<KeyboardMover>();
            if (keyboardMover)
            {
                keyboardMover.StartCoroutine(SpeedTemporarily(keyboardMover));
            // NOTE: If you just call "StartCoroutine", then it will not work, 
            //       since the present object is destroyed!
            Destroy(gameObject);
                //SpeedTemporarily()// Destroy the speed itself - prevent double-use
            }
        }
        else
        {
            Debug.Log("Shield triggered by " + other.name);
        }
    }
    private IEnumerator SpeedTemporarily(KeyboardMover keyboardMover)
    {
        //destroyComponent.enabled = false;
        keyboardMover.setSpeed(speed);
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("speed upgrade: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
        }
        Debug.Log("speed upgrade gone!");
        keyboardMover.setSpeed(-speed);
        //destroyComponent.enabled = true;
    }
}
