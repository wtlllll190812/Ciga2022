using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UnityMatch : Match
{
    public Text input;

    public void Check()
    {
        if (input.text == "ed")
        {
             OnMatch?.Invoke();
        }
    }
}
