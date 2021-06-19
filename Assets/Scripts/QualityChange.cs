using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityChange : MonoBehaviour
{

    /* These 4 functions are used for changing of quality settings in the game. Ranging from Ultra to low quality. */
    public void UltraQuality()
    {
        QualitySettings.SetQualityLevel(5, true);
    }

    public void VeryHighQuality()
    {
        QualitySettings.SetQualityLevel(4, true);
    }

    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(2, true);
    }

    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
}
