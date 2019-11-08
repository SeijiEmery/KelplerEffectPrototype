using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour {

    // movement speed, in m/s
    public float moveSpeed = 0.1f;

    // rotation speeds, in deg/s
    public float yawTurnSpeed = 45f;
    public float pitchTurnSpeed = 45f;

    // pitch angle limits, in deg
    public float minPitchAngle = -45f;
    public float maxPitchAngle = 45f;

    // enable / disable turning (yaw: rotation about y axis), pitching (rotation about x axis),
    // and vertical movement (along y axis)
    public bool allowPitch = false;
    public bool allowYaw = false;
    public bool allowVerticalMovement = false;

    // sets target position that unit should move to
    // should ignore y component if unit cannot move vertically
    // TODO: implement this
    public void SetMovementTarget(Vector3 targetPos) { }

    // sets firing target position for this unit
    // TODO: implement this
    public void SetFiringTarget(Vector3 targetPos) { }

    // sets movement direction for direct (WASD) movement
    // moveDir() should be normalized before using
    // TODO: implement this
    public void SetMovementDirection(Vector3 moveDir) { }
}
