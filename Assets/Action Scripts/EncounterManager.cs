using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EncounterManager : MonoBehaviour {
    // Start is called before the first frame update
    EncounterTable encounters;
    void Start () {
        encounters = new EncounterTable ();
        encounters.load_from_file (Application.dataPath + "/Encounter Texts/encounters.txt"); //EDITOR
        //encounters.load_from_file (Application.dataPath +"/../encounters.txt");   //BUILD
    }

    public Encounter get_encounter (string name) {
        return encounters.get (name);
    }

    public void scramble_meeples (GameObject caller) {
        var random = new System.Random ();
        foreach (Transform child in transform)
            child.gameObject.SetActive (false);

        for (int i = 3; i > 0; i--) {
            int m = random.Next (transform.childCount);
            var c = transform.GetChild (m).gameObject;
            if (c.activeSelf || GameObject.ReferenceEquals (c, caller)) {
                i++;
            } else {
                c.SetActive (true);
            }
        }

    }

    public void scramble_meeples () {
        var random = new System.Random ();
        foreach (Transform child in transform)
            child.gameObject.SetActive (false);

        for (int i = 3; i > 0; i--) {
            int m = random.Next (transform.childCount);
            var c = transform.GetChild (m).gameObject;
            if (c.activeSelf) {
                i++;
            } else {
                c.SetActive (true);
            }
        }
    }
}

public class EncounterTable {
    Dictionary<string, List<Encounter>> table;

    public EncounterTable () {
        table = new Dictionary<string, List<Encounter>> ();
    }

    public Encounter get (string name) {
        List<Encounter> list;

        if (table.TryGetValue (name, out list)) {
            var random = new System.Random ();
            int index = random.Next (list.Count);
            return list[index];
        } else {
            //error
            return null;
        }

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
            add (key, new Encounter (key, prompt, choices, effects));

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

}

public class Encounter {
    public string name;
    public string prompt;
    public List<string> actions;
    public List<int[]> effects;

    public Encounter (string _name, string _prompt, List<string> _actions, List<int[]> _effects) {
        name = _name;
        prompt = _prompt;
        actions = _actions;
        effects = _effects;
    }

}