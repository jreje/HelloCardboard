using UnityEngine;   

public class Scorer : MonoBehaviour
{
    public static Scorer Instance;
    public int score;
    public TMPro.TextMeshProUGUI score_text;
    public float settleDelay = 0.75f;

    private void Awake() => Instance = this;

    public void AddPoint()
    {
        score++;
        score_text.text = "Score: " + score;
    }
}
