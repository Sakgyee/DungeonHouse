using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfTalk : MonoBehaviour
{
    private RGameManager gameManagerInstance;
    public GameObject oj;
    private void Start()
    {
        gameManagerInstance = RGameManager.sharedInstance;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(TalkDelay(1.5f));
            // Assuming you have a reference to the scan object in your code
            GameObject scanObject = oj;
            
            // Call the Action function from RGameManager
            gameManagerInstance.Action(scanObject);

        }
    }
    private IEnumerator TalkDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerContro.instance.isMoving = true;
        gameObject.SetActive(false);
    }
}
