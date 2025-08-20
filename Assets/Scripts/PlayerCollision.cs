using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("충돌! 게임 오버");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
