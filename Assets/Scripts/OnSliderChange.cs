using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnSliderChange : MonoBehaviour
{
    public void ChangeColorsCount(float value) => GetComponent<TextMeshProUGUI>().text = value.ToString();
}
