using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy",menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float hp;
    //public float dmg;
    public float speed;
    public float threshold;
    public Vector3 delta;
    public GameObject player;
    public float timeToDestoy = 7f;
    public float lambda = 2f;
    
    
}
