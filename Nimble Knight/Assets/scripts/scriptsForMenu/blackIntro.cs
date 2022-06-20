using UnityEngine;
using UnityEngine.UI;

public class blackIntro : MonoBehaviour
{
    private bool done;
    private Image panel;
    void Start()
    {
        done = false;
        panel = GameObject.Find("FadeIn").GetComponent<Image>();
        panel.color = new Color(0, 0, 0, 1);
    }

    private void FixedUpdate()
    {
        if (!done)
        {
            panel.color = new Color(0, 0, 0, panel.color.a - 0.005f);
            if (panel.color.a <= 0) Destroy(gameObject);
        }
    }
}
