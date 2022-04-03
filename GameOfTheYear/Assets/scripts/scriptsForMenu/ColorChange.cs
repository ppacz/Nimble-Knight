using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Image img;
    public int changeSpeed;
    public float red;
    public float blue;
    int timer = 0;
    float green;
    
    bool change = true;
    
    private void FixedUpdate()
    {
        if (timer % changeSpeed==0) colorChange();
        timer++;
        if (timer > 100) timer = 0;
    }

    void colorChange() 
    {
            img.color = new Color(red, green / 100, blue);
            if (green == 100) change = false;
            else if (green == 0) change = true;
            if (change) green++;
            else green--;
    }

}