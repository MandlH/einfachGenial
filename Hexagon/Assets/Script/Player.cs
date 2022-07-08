using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int blue;
    public int red;
    public int yellow;
    public int green;
    public int purble;

    public bool active = false;

    public TextMeshProUGUI[] text;

    public TextMeshProUGUI turn;

    private void Update()
    {
        text[0].SetText("<color=blue>BLUE</color>: " + blue);
        text[1].SetText("<color=red>RED</color>: " + red);
        text[2].SetText("<color=yellow>YELLOW</color>: " + yellow);
        text[3].SetText("<color=green>GREEN</color>: " + green);
        text[4].SetText("<color=purple>PURPLE</color>: " + purble);

        if (active)
            turn.SetText(this.gameObject.name);

    }
}
