using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Button bot;
    public Transform lerpTo;

    public void Update()
    {
        if (bot.open)
        {
            //Destroy(gameObject);
            StartCoroutine(LerpPosition(lerpTo.position, 5));
        }
    }
    
    public Vector3 positionToMoveTo;
        IEnumerator LerpPosition(Vector3 targetPosition, float duration)
        {
            float time = 0;
            Vector3 startPosition = transform.position;
            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
        }
}