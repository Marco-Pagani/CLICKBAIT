using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encounter_generator : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}

class EncounterTable {
    var table;
    EncounterTable () {
        table = new Dictionary<string, List<Encounter>> ();
    }

    void add (string s, Encounter e) {
        List<Encounter> list;

        if (!dictionary.TryGetValue (s, out list)) {
            list = new List<Encounter> ();
            dictionary.Add (s, list);
        }

        list.Add (e);
    }

}

class Encounter {
    string prompt;
    string[] actions;
    int[][] effects;

    Encounter (string prompt, string[] actions, int[][] effects) {
        this.prompt = prompt;
        this.actions = actions;
        this.effects = effects;
    }

}