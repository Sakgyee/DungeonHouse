using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowPotionTalk : MonoBehaviour
{
    RectTransform r;

    public Transform targetToFollow;
    public float y = 1.3f;
    void Awake()
    {
        r = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if (targetToFollow != null)
        {
            Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(targetToFollow.position + new Vector3(0,y));
            r.position = targetScreenPos;
        }
        else
        {
            // Disable or hide the health bar when the Enemy1 object is missing
            gameObject.SetActive(false);
        }
    }
}
