using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;


public class PsycheBar : MonoBehaviour
{
    public static int count = 0;

   

    Image psycheBar;

    public float maxPsyche = 300f;

    public float PP = 300f;

    private float passedTime = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        psycheBar = GetComponent<Image>();
        
        PP = maxPsyche;
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    private void FixedUpdate()
    {
        psycheBar.fillAmount = PP / maxPsyche;
        passedTime += Time.deltaTime;
        if (passedTime > 2f) 
        {
            passedTime = 0;
            PP -= 10;
            ++count;
        }
        if (PP <= 0)
            PP = 300;
        if (PP <= 300 && PP > 200)
            psycheBar.color = new Color32(181, 42, 132, 255);
        else if (PP <= 200 && PP > 100)
            psycheBar.color = new Color32(130, 42, 192, 255);
        else if (PP <= 25)
            psycheBar.color = new Color32(65, 33, 137, 255);
        else
            psycheBar.color = new Color32(219, 42, 192, 255);

    }
}
