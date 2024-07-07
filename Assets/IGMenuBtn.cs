using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IGMenuBtn : MonoBehaviour
{
    [SerializeField] Color setSelectedColor;
    [SerializeField] Color setDeselectedColor;
    public void SetSelectedTxtColor()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().color = setSelectedColor;
    }
    public void SetDeselectedTxtColor()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().color = setDeselectedColor;
    }
}
