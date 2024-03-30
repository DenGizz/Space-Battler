using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleInfoUIViewModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;

    public void WriteInfo(string info)
    {
        Text.text = info;
    }
}
