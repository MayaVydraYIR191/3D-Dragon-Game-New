using UnityEngine;
using TMPro;
public class CountRotation : MonoBehaviour
{
    TMP_Text countRotation;
    public static double rotationCount;
    void Start()
    {
        countRotation = GetComponent<TMP_Text>();
    }
    void Update()
    {
        countRotation.text = rotationCount.ToString();
    }
}

