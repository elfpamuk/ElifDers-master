using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [SerializeField]
    Movable[] movables;

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            foreach (var m in movables) {
                m.Move (Vector3.forward);
            }
        }
    }
}