using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour {

    [SerializeField]
    float xMin, xMax, zMin, zMax;
    MeshRenderer renderer;
    Collider collider;
    private void Awake () {
        renderer = GetComponent<MeshRenderer> ();
        collider = GetComponent<Collider> ();
    }
    public void BaitTaken () {
        renderer.enabled = false;
        collider.enabled = false;
        Invoke (nameof (Spawn), 2);
    }

    void Spawn () {
        transform.position = new Vector3 (
            Random.Range (xMin, xMax),
            0,
            Random.Range (zMin, zMax)
        );
        renderer.enabled = true;
        collider.enabled = true;
    }

    private void OnDrawGizmos () {
        Gizmos.DrawLine (new Vector3 (xMin, 0, zMin), new Vector3 (xMin, 0, zMax));
        Gizmos.DrawLine (new Vector3 (xMin, 0, zMin), new Vector3 (xMax, 0, zMin));
        Gizmos.DrawLine (new Vector3 (xMin, 0, zMax), new Vector3 (xMax, 0, zMax));
        Gizmos.DrawLine (new Vector3 (xMax, 0, zMin), new Vector3 (xMax, 0, zMax));
    }
}