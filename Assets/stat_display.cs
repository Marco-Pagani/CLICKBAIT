using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stat_display : MonoBehaviour {

    public StatTracker data;
    //25 - 760
    // Update is called once per frame
    void Update () {
        gameObject.transform.Find ("Money").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2( ((float)data.money).Remap(0,100,25,760),36);
        gameObject.transform.Find ("Reputation").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2( ((float)data.reputation).Remap(0,100,25,760),36);
        gameObject.transform.Find ("Style").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2( ((float)data.style).Remap(0,100,25,760),36);
        gameObject.transform.Find ("Subcount").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2( ((float)data.subs).Remap(-40,1000,25,760),36);
    }
}