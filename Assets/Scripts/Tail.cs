using UnityEngine;

public class Tail : SnakePart {

    public void SetPreviousPart (SnakePart part) {
        part.OnPartMove += Move;
    }
    void Move (Vector3 pos) {
        LastPositionChanged ();
        transform.position = pos;
    }
}