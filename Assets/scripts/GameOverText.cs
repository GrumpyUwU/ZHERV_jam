using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    public TextMeshProUGUI WavesText;
    public void Waves(int Wave){
        string formattedGameOver = string.Format("survived waves: {0}", Wave);
        WavesText.text = formattedGameOver;
    }
}
