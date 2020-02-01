using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class encounter_generator : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        var encounters = new EncounterTable ();
        encounters.load_from_file (Application.dataPath + "/encounters.txt");

    }

    // Update is called once per frame
    void Update () {

    }
}

public class EncounterTable {
    Dictionary<string, List<Encounter>> table;

    public EncounterTable () {
        table = new Dictionary<string, List<Encounter>> ();
    }

    public void load_from_file (string file) {
        StreamReader sr;
        try {
            sr = File.OpenText (file);
        } catch (FileNotFoundException) { Debug.Log ("Failed to load encounters"); return; }
        while (!sr.EndOfStream) {
            string key = sr.ReadLine ();
            string prompt = sr.ReadLine ();
            var choices = new List<string> ();
            var effects = new List<int[]> ();
            //Debug.Log (key + "\n" + prompt);
            for (string next = sr.ReadLine (); next != "end"; next = sr.ReadLine ()) {
                //Debug.Log (next);
                choices.Add (next);
                effects.Add (Array.ConvertAll (sr.ReadLine ().Split (' '), s => int.Parse (s)));
            }
            add (key, new Encounter (prompt, choices, effects));

        }
        Debug.Log ("Successfully loaded encounters");
    }

    private void add (string s, Encounter e) {
        List<Encounter> list;

        if (!table.TryGetValue (s, out list)) {
            list = new List<Encounter> ();
            table.Add (s, list);
        }

        list.Add (e);
    }

    public Encounter get_encounter (string s) {
        List<Encounter> list;

        if (table.TryGetValue (s, out list)) {
            var random = new System.Random ();
            int index = random.Next (list.Count);
            return list[index];
        } else {
            //error
            return null;
        }

    }

}

public class Encounter {
    public string prompt;
    public List<string> actions;
    public List<int[]> effects;

    public Encounter (string prompt, List<string> actions, List<int[]> effects) {
        this.prompt = prompt;
        this.actions = actions;
        this.effects = effects;
    }

}