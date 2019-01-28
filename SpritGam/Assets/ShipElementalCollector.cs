using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipElementalCollector : MonoBehaviour
{
    public Element Nickel = new Element(ElementType.Nickel, 0);
    public Element Iron = new Element(ElementType.Iron, 0);
    public Element Carbon = new Element(ElementType.Carbon, 0);
    public Element Water = new Element(ElementType.Water, 0);
    public Element Nitrogen = new Element(ElementType.Nitrogen, 0);
    public Element Hydrogen = new Element(ElementType.Hydrogen, 0);
    public Element Oxegen = new Element(ElementType.Oxygen, 0);
    public Element Cobalt = new Element(ElementType.Cobalt, 0);
    public Element Iridium = new Element(ElementType.Iridium, 0);
    public Element Platinum = new Element(ElementType.Platinum, 0);
    public Element Aluminum = new Element(ElementType.Aluminum, 0);
    public Element Magnesium = new Element(ElementType.Magnesium, 0);
    public Element Gold = new Element(ElementType.Gold, 0);
    public Element Tungsten = new Element(ElementType.Tungsten, 0);

    private List<Element> elements;
    [SerializeField] private Text displayText;
    [SerializeField] private Text timer;

    private void Start()
    {
        Debug.Log(ElementType.Nickel.ToString());
        elements = new List<Element>(){
            Nickel,
            Iron,
            Carbon,
            Oxegen,
            Cobalt,
            Water,
            Nitrogen,
            Hydrogen,
            Iridium,
            Platinum,
            Aluminum,
            Magnesium,
            Gold,
            Tungsten,
        };

        updateDisplayString();
    }

    private void updateDisplayString()
    {
        string displayString = "";

        for (int i = 0; i < elements.Count; i++)
        {
            Element e = elements[i];
            displayString += e.name + ": " + e.amount + "\n";
        }

        displayText.text = displayString;
    }

    public void FixedUpdate()
    {
        float time = Time.realtimeSinceStartup;
        int seconds = Mathf.FloorToInt(time);
        int minutes = Mathf.FloorToInt(seconds / 60);
        int hours = Mathf.FloorToInt(minutes / 60);

        timer.text = getTimeString(hours % 60) + ":" + getTimeString(minutes % 60) + ":" + getTimeString(seconds % 60);
    }

    private string getTimeString(int num)
    {
        if (num < 10)
        {
            return "0" + num;
        } else
        {
            return num.ToString();
        }
    }

}

public class Element
{
    public ElementType type;
    public double amount;
    public string name {  get { return type.ToString(); } }

    public Element(ElementType _type, double _amount)
    {
        type = _type;
        amount = _amount;
    }
}

public enum ElementType
{
    Nickel,
    Iron,
    Carbon,
    Oxygen,
    Cobalt,
    Water,
    Nitrogen,
    Hydrogen,
    Iridium,
    Platinum,
    Aluminum,
    Magnesium,
    Gold,
    Tungsten,
}