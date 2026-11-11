using UnityEngine;

public class GuidanceArrow : MonoBehaviour
{
    public MissionManager mission;
    public Transform drone;

    private RectTransform arrowRect;

    void Start()
    {
        arrowRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (mission == null || drone == null) return;

        Ring target = mission.GetNextRing();
        if (target == null)
        {
            arrowRect.gameObject.SetActive(false);
            return;
        }

        // כיוון הטבעת ביחס לרחפן, על המישור האופקי בלבד
        Vector3 toTarget = target.transform.position - drone.position;
        toTarget.y = 0;

        // הכיוון בו הרחפן פונה, גם על המישור האופקי
        Vector3 forward = drone.forward;
        forward.y = 0;

        // הזווית בין "קדימה" שלו לבין הטבעת
        float angle = Vector3.SignedAngle(forward, toTarget, Vector3.up);

        // סיבוב החץ (מינוס כי ב-UI הכיוון הפוך)
        arrowRect.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}