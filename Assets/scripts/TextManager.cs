using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI WaveCounter;
    public TextMeshProUGUI Time;
    public TextMeshProUGUI Energy;
    public TextMeshProUGUI Durability;
    public TextMeshProUGUI HP;

    public void UpdateWave(int WaveNum){
        WaveCounter.text = "Wave: "+WaveNum;
    }

    public void UpdateTime(float time){
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        Time.text = formattedTime;
    }

    public void UpdateEnergy(float energy){
        string formattedEnergy = string.Format("Energy: {0:0.00}", energy);
        Energy.text = formattedEnergy;
    }

    public void UpdateDurability(float durability){
        string formattedDurability = string.Format("Durability: {0:0.00}", durability);
        Durability.text = formattedDurability;
    }

    public void UpdateHP(float HP_num){
        string formattedHP = string.Format("{0:0.00} :HP", HP_num);
        HP.text = formattedHP;
    }
}
