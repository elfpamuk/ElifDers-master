using System;
using UnityEngine;

public class SnakePart : MonoBehaviour {
    public Action<Vector3> OnPartMove;

    protected void LastPositionChanged () {
        OnPartMove?.Invoke (transform.position);
    }
}