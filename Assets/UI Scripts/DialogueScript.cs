using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public StatTracker player;
    public Sprite s0, s1, s2, s3, s4, s5;
    Encounter current_enc;

    private string[] names = { "Spleen", "Tiana", "Problem", "Helix", "Beetroot", "Sahara" };

    public void displayEncounter (Encounter e) {
        current_enc = e;
        gameObject.transform.Find ("prompt").gameObject.GetComponent<UnityEngine.UI.Text> ().text = e.prompt;
        for (int i = 0; i < e.actions.Count; i++) {
            var button = gameObject.transform.Find ("op" + i);
            button.Find ("Text").gameObject.GetComponent<UnityEngine.UI.Text> ().text = e.actions[i];
            button.gameObject.SetActive (true);
        }

        Sprite active = null;
        switch (Array.IndexOf (names, e.name)) {
            case 0:
                active = s0;
                //active.RectTransform.Scale.X = 3;
                break;
            case 1:
                active = s1;
                break;
            case 2:
                active = s2;
                break;
            case 3:
                active = s3;
                break;
            case 4:
                active = s4;
                break;
            case 5:
                active = s5;
                break;

        }
        gameObject.transform.Find ("profile").gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = active;

    }

    public void select_option (int i) {
        player.apply_choice (current_enc.effects[i]);
        gameObject.transform.Find ("op0").gameObject.SetActive (false);
        gameObject.transform.Find ("op1").gameObject.SetActive (false);
        gameObject.transform.Find ("op2").gameObject.SetActive (false);

        gameObject.SetActive (false);
    }

    
}