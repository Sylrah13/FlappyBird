using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // ΩÃ±€≈Ê
    private int score = 0;

    void Awake()
    {
        // ΩÃ±€≈Ê √ ±‚»≠
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("«ˆ¿Á ¡°ºˆ: " + score);
    }
}
