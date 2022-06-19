using UnityEngine;
using TMPro;

public class popUp : MonoBehaviour
{
    private TMP_Text text;
    [SerializeField] private float fallOff;
    private float timer;

    private void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
        text.color = new Color(0, 0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (text.color.a != 0)
        {
            if (Time.time > timer)
            {
                text.color = new Color(0, 0, 0, text.color.a - 0.01f);
            }
        }
    }
    public void textPop(string textToPop)
    {
        text.text = textToPop;
        text.color = new Color(0, 0, 0, 1);
        timer = Time.time+fallOff;
    }

}
