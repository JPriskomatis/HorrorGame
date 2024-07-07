using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IGMenuBtn : MonoBehaviour
{
    public void ChangeTxtColor()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
    }
}
