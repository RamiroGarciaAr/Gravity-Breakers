using UnityEngine;

public abstract class Enemy: MonoBehaviour
{
    //move to scriptable
    //public float speed; 
    public abstract void doDmg();
    public abstract void takeDmg();


}
