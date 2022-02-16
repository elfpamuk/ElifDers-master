using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : SnakePart {
    Vector3 dir = Vector3.right;

    [SerializeField]
    Tail prefab;

    Transform lastPart;
    private void Start () {
        lastPart = transform;
        StartCoroutine (nameof (Move));
    }
    IEnumerator Move () {
        while (true) {
            LastPositionChanged ();
            if (Physics.Raycast (transform.position, dir, out RaycastHit hit, 1)) {
                if (hit.transform.TryGetComponent<Bait> (out Bait bait)) {
                    var newPart = Instantiate (prefab, lastPart.position, Quaternion.identity);
                    var tail = newPart.GetComponent<Tail> ();
                    tail.SetPreviousPart (lastPart.GetComponent<SnakePart> ());
                    bait.BaitTaken ();
                    lastPart = newPart.transform;
                }
            }
            transform.position += dir;
            for (int i = 0; i < 20; i++) {
                yield return null;
            }
        }
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.A)) {
            if (dir != Vector3.right)
                dir = Vector3.left;
        }
        if (Input.GetKeyDown (KeyCode.D)) {
            if (dir != Vector3.left)
                dir = Vector3.right;
        }
        if (Input.GetKeyDown (KeyCode.W)) {
            if (dir != Vector3.back)
                dir = Vector3.forward;
        }
        if (Input.GetKeyDown (KeyCode.S)) {
            if (dir != Vector3.forward)
                dir = Vector3.back;
        }
    }
}