using System;
using ElectricNetwork;
using TMPro;
using UnityEngine;

public class CurrentSourceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _display;
    void Update()
    {
        var emf = "EMF: " + Math.Round(GetComponentInParent<CurrentSoruce>().EMF) + " V\n";
        var innerResistance = "Inner_Resistance: " + Math.Round(GetComponentInParent<CurrentSoruce>().InnerResistance) +
                              " Om\n";
        var totalResistance = "Total_Resistance: " +
                              Math.Round(GetComponentInParent<CurrentSoruce>().Signal.Resistance, 2) + " Om\n";
        var amperage = "Amperage: " + Math.Round(GetComponentInParent<CurrentSoruce>().Signal.Amperage, 2) + " A";

        _display.text = emf + innerResistance + totalResistance + amperage;
    }
}
