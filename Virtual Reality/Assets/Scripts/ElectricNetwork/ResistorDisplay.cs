using System;
using ElectricNetwork;
using TMPro;
using UnityEngine;

public class ResistorDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _display;
    
    void Update()
    {
        var amperage = "Amperage: " + Math.Round(GetComponentInParent<Resistor>().Amperage, 2) + " A\n";
        var voltage = "Voltage: " + Math.Round(GetComponentInParent<Resistor>().Voltage, 2) + " V\n";
        var resistance = "Resistance: " + Math.Round(GetComponentInParent<Resistor>().Resistance, 2) + " Om\n";
        _display.text = resistance + amperage + voltage;
    }
}
