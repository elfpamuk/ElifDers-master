using UnityEngine;

public class Movable : MonoBehaviour {
    protected int moveLength = 1;

    public virtual void Move (Vector3 dir) {
        transform.position += dir.normalized * moveLength;
    }
}