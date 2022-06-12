using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private float colorTimer;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerXP>().level()>=(newSceneIndex-1)*5)
            {
                SceneManager.LoadScene(newSceneIndex);
            }
            else
            {
                colorTimer = 3;
            }
        }
    }

    private void Update()
    {
        if (colorTimer >= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            colorTimer -= Time.deltaTime;
        }
        if (colorTimer <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            colorTimer = 0;
        }
    }
}
