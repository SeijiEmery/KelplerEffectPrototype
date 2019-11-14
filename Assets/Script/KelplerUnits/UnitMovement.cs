using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{

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

    public Vector3 Destination
    {
        get;private set;
    }
    public Vector3 Aim
    {
        get; private set;
    }

    private LineRenderer destinationLR;
    private LineRenderer aimLR;

    private void Start()
    {
        Destination = transform.position;
        Aim = transform.position + transform.forward;

        //Initialize line drawing
        GameObject go = new GameObject("DestinationLR");
        go.transform.SetParent(transform);
        destinationLR = go.AddComponent<LineRenderer>();
        //TODO: Extract these magic numbers
        destinationLR.startWidth = 0.02f;
        destinationLR.endWidth = 0.0f;
        destinationLR.material = GetComponentInParent<MeshRenderer>().material;
        destinationLR.material.color = new Color(0, 100, 100);
        

    }

    private void Update()
    {
        destinationLR.SetPosition(0, transform.position);
        destinationLR.SetPosition(1, Destination);

        if (aimLR != null)
        {
            aimLR.SetPosition(0, transform.position);
            aimLR.SetPosition(1, Aim);
        }
    }

    private void FixedUpdate()
    {
        float deltaTime = Time.fixedDeltaTime;
        Vector3 deltaPos = Destination - transform.position;
        if (deltaPos.sqrMagnitude > moveSpeed * moveSpeed * deltaTime * deltaTime)
        {
            deltaPos = deltaPos.normalized * moveSpeed * deltaTime;
        }
        transform.position += deltaPos;
        Aim += deltaPos;

    }

    // sets target position that unit should move to
    // should ignore y component if unit cannot move vertically
    // TODO: implement this
    public void SetMovementTarget(Vector3 targetPos)
    {
        Destination = targetPos;
    }

    // sets firing target position for this unit
    // TODO: implement this
    public void SetFiringTarget(Vector3 targetPos)
    {
        Aim = targetPos;
    }

    // sets movement direction for direct (WASD) movement
    // moveDir() should be normalized before using
    // TODO: implement this
    public void MoveInDirection(Vector3 moveDir)
    {
        moveDir = moveDir.normalized * moveSpeed * Time.deltaTime * 10;
        Destination += moveDir;
    }

    // Move the point being aimed at based on
    // the aim speed and vector given
    public void AimInDirection(Vector3 targetDir)
    {
        targetDir = targetDir.normalized * moveSpeed * Time.deltaTime * 10;
        Aim += targetDir;
    }
}
