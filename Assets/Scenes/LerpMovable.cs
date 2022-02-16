using System.Collections;
using UnityEngine;

public class LerpMovable : Movable {
    public override void Move (Vector3 dir) {
        StartCoroutine (MoveWithTime (transform.position + dir.normalized * moveLength));
    }

    IEnumerator MoveWithTime (Vector3 targetPosition) {
        var startPos = transform.position;
        var t = 0f;
        while (t <= 1) {
            transform.position = Vector3.Lerp (startPos, targetPosition, t);
            t += Time.deltaTime;
            yield return null;
        }
    }
}