using UnityEngine;
using TMPro;

public class DroneHUD : MonoBehaviour
{
    public TextMeshProUGUI hudText;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        float altitude = transform.position.y;

        Vector3 delta = transform.position - lastPosition;
        float speed = delta.magnitude / Time.deltaTime;
        lastPosition = transform.position;

        if (hudText != null)
        {
            hudText.text = "Altitude: " + altitude.ToString("F1") + " m\n" +
                           "Speed: " + speed.ToString("F1") + " m/s";
        }
    }
}