using UnityEngine;
using UnityEngine.UI;

public class MeteorGui : MonoBehaviour
{
    public MeteorController Meteor;
    public Text Label;

    public void OnButtonClick()
    {
        if (!Meteor.Ready)
        {
            Meteor.Ready = true;
            Label.text = "Reset";
        }
        else
        {
            Meteor.Reset();
            Label.text = "Start";
        }
    }
}
