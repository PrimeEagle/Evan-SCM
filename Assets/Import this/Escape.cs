using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour {
    public GameObject player;
    public Text escapeText;

    public void OnMouseDown()
    {
        player.SetActive(false);
        escapeText.text = "Congratulations you have escaped the facility!";
    }
}
