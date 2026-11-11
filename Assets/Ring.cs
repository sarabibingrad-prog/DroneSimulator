using UnityEngine;

public class Ring : MonoBehaviour
{
    public int index;

    void OnTriggerEnter(Collider other)
    {
        MissionManager manager = FindAnyObjectByType<MissionManager>();
        if (manager != null && other.GetComponent<DroneController>() != null)
        {
            manager.RingPassed(this);
        }
    }
}