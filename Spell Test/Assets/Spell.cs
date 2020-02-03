using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;
using Random = System.Random;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Spell protoype
/// How to use: See specific spell for details
/// Written by: Sammy Chan
/// ---------- 

public class Spell : MonoBehaviour
{
    static Random rnd = new Random();
    public GameObject pcCanvas;
    public TextMeshProUGUI textMeshM;
    public GameObject projectile;
    public float speed = 100f;

    public List<String> subjects = new List<string>();
    public List<String> predicates = new List<string>();
    public List<String> objects = new List<string>();

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        pcCanvas = GameObject.Find("pcCanvas");
        textMeshM = pcCanvas.transform.Find("spells").GetComponent<TextMeshProUGUI>();

        subjects.Add("You ");
        subjects.Add("I ");
        predicates.Add("eat ");
        predicates.Add("drink ");
        objects.Add("food");
        objects.Add("water");

        GenerateSpell();

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    /// ---
    /// Fire ball spell, make sure projectile spell has gravity set to 0
    /// Shoots fireball in forward direction of object it is attached to
    ///
    /// Instantiate(projectile, [Change this code to alter spawning position of projectile], Quaternion.identity)
    /// ---
    void Fireball()
    {

        GameObject fireBall = Instantiate(projectile, transform.position + Camera.main.transform.forward * 2, Quaternion.identity) as GameObject;
        Rigidbody fireBallRigidBody = fireBall.GetComponent<Rigidbody>();
        fireBallRigidBody.AddForce(Camera.main.transform.forward * speed);
        GenerateSpell();
    }

    public void GenerateSpell()
    {
        int r1 = rnd.Next(subjects.Count);
        int r2 = rnd.Next(predicates.Count);
        int r3 = rnd.Next(objects.Count);

        string spell = subjects[r1] + predicates[r2] + objects[r3];
        textMeshM.text = spell;
        Debug.Log(spell);
        actions.Add(spell, Fireball);
    }
    /// Temporary trigger so that I could test the spell without a mic,
    ///     DELETE in final build, or keep as secret debug-mode function
/*
    void Update()
    {
        //Placeholder trigger, replace with successful incantation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fireball();
        }
    }
*/
}