using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.Windows.Speech;
using TMPro;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class GenerateSpell : MonoBehaviour
{
    static Random rnd = new Random();
    private GameObject pcCanvas;
    private TextMeshProUGUI spell0;
    private TextMeshProUGUI spell1;
    private TextMeshProUGUI spell2;
    private TextMeshProUGUI spell3;
    private TextMeshProUGUI spell4;
    public GameObject projectile;
    public float speed = 100f;
    public List<string> subjectList = new List<string>();
    public List<string> predicateList = new List<string>();
    public List<string> objectList = new List<string>();
    ///public string spellPath;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        pcCanvas = GameObject.Find("pcCanvas");
        spell0 = pcCanvas.transform.Find("spellslot0").GetComponent<TextMeshProUGUI>();
        spell1 = pcCanvas.transform.Find("spellslot1").GetComponent<TextMeshProUGUI>();
        spell2 = pcCanvas.transform.Find("spellslot2").GetComponent<TextMeshProUGUI>();
        spell3 = pcCanvas.transform.Find("spellslot3").GetComponent<TextMeshProUGUI>();
        spell4 = pcCanvas.transform.Find("spellslot4").GetComponent<TextMeshProUGUI>();

        string sPath = Application.dataPath + "/subjects.txt";
        string pPath = Application.dataPath + "/predicates.txt";
        string oPath = Application.dataPath + "/objects.txt";
        
        ///spellPath = Application.dataPath + "/spells.txt";
        ///ClearFile(spellPath);

        ReadFile(sPath, "subjects");
        ReadFile(pPath, "predicates");
        ReadFile(oPath, "objects");        
        AddNewSpell("Fireball");
    }

    /// <summary>
    /// recognize the speech and invoke with the action
    /// </summary>
    /// <param name="speech"></param>
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
        actions.Remove(speech.text);
        ClearList(speech.text);
    }

    /// <summary>
    /// clear the content of the file with given file path
    /// </summary>
    /// <param name="filePath"></param>
    void ClearFile(string filePath)
    {
        FileStream fileStream = File.Open(filePath, FileMode.Open);
        fileStream.SetLength(0);
        fileStream.Close();
    }

    /// <summary>
    /// read file with given file path, based on its name
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="fileName"></param>
    void ReadFile(string filePath, string fileName)
    {
        if (File.Exists(filePath))
        {
            StreamReader sReader = new StreamReader(filePath);
            while (!sReader.EndOfStream)
            {
                string line = sReader.ReadLine();
                if (fileName == "subjects")
                {
                    subjectList.Add(line);
                }
                else if (fileName == "predicates")
                {
                    predicateList.Add(line);
                }
                else if (fileName == "objects")
                {
                    objectList.Add(line);
                }
                else
                {
                    Debug.Log("Error: bad filename");
                }
            }
            sReader.Close();
        }
        else
        {
            Debug.Log("Error:file not found");
        }
    }

    public string GenerateIncantation()
    {
        int r1 = rnd.Next(subjectList.Count);
        int r2 = rnd.Next(predicateList.Count);
        int r3 = rnd.Next(objectList.Count);
        string spell = subjectList[r1] + predicateList[r2] + objectList[r3];
        ///Debug.Log(spell);
        return spell;
    }
    /// <summary>
    /// generate a new spell with a type eg. fire ice etc
    /// </summary>
    /// <param name="spellType"></param>
    public void AddNewSpell(string spellType)
    {
        ///string filePath = spellPath;
        ///string line = null;
        string newSpell = GenerateIncantation();
        while (actions.ContainsKey(newSpell))
        {
            newSpell = GenerateIncantation();
        }
        /*
        StreamReader sReader = new StreamReader(filePath);
        while ((line = sReader.ReadLine()) != null)
        {
            if (string.Compare(line, newSpell) == 0)
            {
                newSpell = GenerateIncantation();               
            }
            continue;
        }
        sReader.Close();
        StreamWriter sWriter = new StreamWriter(filePath, append: true);
        sWriter.WriteLine(newSpell);
        sWriter.Close();
        */

        actions.Add(newSpell, Fireball);
        



        if (spell0.text == "")
        {
            spell0.text = newSpell + " | " + spellType;
        }
        else if (spell1.text == "")
        {
            spell1.text = newSpell + " | " + spellType;
        }
        else if (spell2.text == "")
        {
            spell2.text = newSpell + " | " + spellType;
        }
        else if (spell3.text == "")
        {
            spell3.text = newSpell + " | " + spellType;
        }
        else if (spell4.text == "")
        {
            spell4.text = newSpell + " | " + spellType;
        }
    }

    void ClearList(string incantation)
    {
        if (spell0.text.Contains(incantation) == true)
        {
            spell0.text = "";
        }
        else if (spell1.text.Contains(incantation) == true)
        {
            spell1.text = "";
        }
        else if (spell2.text.Contains(incantation) == true)
        {
            spell2.text = "";
        }
        else if (spell3.text.Contains(incantation) == true)
        {
            spell3.text = "";
        }
        else if (spell4.text.Contains(incantation) == true)
        {
            spell4.text = "";
        }
    }
    /// <summary>
    /// fire spell that fires a fireball into the direction where the vr guy looks at
    /// </summary>
    void Fireball()
    {
        GameObject fireBall = Instantiate(projectile, transform.position + Camera.main.transform.forward * 2, Quaternion.identity) as GameObject;
        Rigidbody fireBallRigidBody = fireBall.GetComponent<Rigidbody>();
        fireBallRigidBody.AddForce(Camera.main.transform.forward * speed);
    }
    private void OnCollisionEnter(Collision other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (other.gameObject.tag == "scroll")
        {
            string spellType = other.gameObject.GetComponent<scrollScript>().GetScrollType();
            Destroy(other.gameObject);        
        }

    }
    
    public void EnableRecognizer()
    {
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    public void DisableRecognizer()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
        }
    }

    void Update()
    {
        //Placeholder trigger, replace with successful incantation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddNewSpell("Fireball");
        }
    }
    
}
