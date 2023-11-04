using UnityEngine;

public class shakeShakeShakeyouboote : MonoBehaviour
{
    public float amplitud = 0.3f;
    public float speed = 7f;
    private void Update()
    {
        Vector3 p = transform.position;
        p.x = amplitud * Mathf.Cos(Time.time * speed) + 2.5f;
        transform.position = p;
    }
}