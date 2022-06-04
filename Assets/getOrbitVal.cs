using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getOrbitVal : MonoBehaviour
{
    public Orbit orbit;
    public TextMeshProUGUI valueText; 
    public int oe;

    void Update()
    {
        switch (oe)
        {
            case 1:
                {
                    float val = orbit.a;
                    valueText.text = val.ToString();
                    break;
                }
            case 2:
                {
                    float val = orbit.e;
                    valueText.text = val.ToString();
                    break;
                }
            case 3:
                {
                    float val = Mathf.Rad2Deg * orbit.i;
                    if (val < 0)
                        val += 360;
                    valueText.text = val.ToString();
                    break;
                }
            case 4:
                {
                    float val = Mathf.Rad2Deg * orbit.RAAN;
                    if (val < 0)
                        val += 360; 
                    valueText.text = val.ToString();
                    break;
                }
            case 5:
                {
                    float val = Mathf.Rad2Deg * orbit.omega;
                    if (val < 0)
                        val += 360; 
                    valueText.text = val.ToString();
                    break;
                }
            case 6:
                {
                    float val = Mathf.Rad2Deg * orbit.nu;
                    if (val < 0)
                        val += 360; 
                    valueText.text = val.ToString(); 
                    break;
                }
        }
    }
            

}
