using UnityEngine;

public class TeleportMovable : Movable {
    [SerializeField]
    ParticleSystem particleSystem;
    public override void Move (Vector3 dir) {
        base.Move (dir);
        particleSystem.Play ();
    }
}