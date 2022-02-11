using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickTextHandler : MonoBehaviour
{
    public List<TextMeshPro> text = new List<TextMeshPro>();
    public void UpdateText(string updatestring)
    {
        foreach(TextMeshPro txt in text)
        {
            txt.text = updatestring;
        }
    }
}
