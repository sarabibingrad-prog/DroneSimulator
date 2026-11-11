using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{
    public float speed = 5f;
    public float climbSpeed = 3f;
    public float turnSpeed = 90f;

    private MissionManager mission;

    void Start()
    {
        mission = FindAnyObjectByType<MissionManager>();
    }

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (mission != null && !mission.HasStarted) return;

        float horizontal = 0f;
        float vertical = 0f;
        float climb = 0f;
        float turn = 0f;

        
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) horizontal += 1f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) horizontal -= 1f;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) vertical += 1f;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) vertical -= 1f;

       
        if (kb.spaceKey.isPressed) climb += 1f;
        if (kb.leftShiftKey.isPressed) climb -= 1f;

        
        if (kb.eKey.isPressed) turn += 1f;
        if (kb.qKey.isPressed) turn -= 1f;

        
        Vector3 move = new Vector3(horizontal, 0, vertical) * speed;
        transform.Translate(move * Time.deltaTime);
        transform.Translate(Vector3.up * climb * climbSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);

        Vector3 p = transform.position;
        p.y = Mathf.Max(p.y, 0.5f);
        transform.position = p;
    }
}

