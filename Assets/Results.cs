using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour {
    // Start is called before the first frame update
    public void set_results (string title, string text, int score) {
        gameObject.transform.Find ("Title").gameObject.GetComponent<UnityEngine.UI.Text> ().text = title;
        gameObject.transform.Find ("Blurb").gameObject.GetComponent<UnityEngine.UI.Text> ().text = text;
        gameObject.transform.Find ("Text").gameObject.GetComponent<UnityEngine.UI.Text> ().text = "Final Score: " + score + ",000 subs";
    }
}