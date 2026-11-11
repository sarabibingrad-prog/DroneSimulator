using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class MissionManager : MonoBehaviour
{
    public Ring[] rings;
    public TextMeshProUGUI missionText;
    public GameObject endPanel;
    public TextMeshProUGUI endText;
    public float countdownTime = 3f;
    public bool HasStarted => started;

    private int nextRing = 0;
    private float timer = 0f;
    private bool finished = false;
    private float countdown;
    private bool started = false;

    


    void Start()
    {
        countdown = countdownTime;
    }


    void Update()
    {
        CheckRestart();

        if (finished) return;

        if (!started)
        {
            countdown -= Time.deltaTime;
            if (missionText != null)
            {
                missionText.text = "Get ready...\n" + Mathf.CeilToInt(countdown);
            }
            if (countdown <= 0f) started = true;
            return;
        }

        timer += Time.deltaTime;
        UpdateText();
    }

    public void RingPassed(Ring ring)
    {
        if (finished) return;

        if (ring == rings[nextRing])
        {
            nextRing++;
            if (nextRing >= rings.Length)
            {
               if (nextRing >= rings.Length)
                    
                    {
                        finished = true;
                        int score = Mathf.Max(0, 1000 - (int)(timer * 10));

                        missionText.gameObject.SetActive(false);
                        endPanel.SetActive(true);
                        endText.text = "MISSION COMPLETE!\n\nTime: " + timer.ToString("F1") + " s\nScore: " + score;
                    }
            }
        }
    }

    void UpdateText()
    {
        if (missionText == null) return;
       missionText.text = "Rings: " + nextRing + "/" + rings.Length + "\nTime: " + timer.ToString("F1") + " s";
    }

    public Ring GetNextRing()
    {
        if (finished || nextRing >= rings.Length) return null;
        return rings[nextRing];
    }

    void CheckRestart()
{
    Keyboard kb = Keyboard.current;
    if (kb != null && kb.rKey.wasPressedThisFrame)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    }
}
