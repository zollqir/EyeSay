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
using UnityEngine.UI;

public class GenerateSpell : MonoBehaviour
{
    static Random rnd = new Random();
    private GameObject pcCanvas;
    public GameObject barrier;
    public GameObject ui;
    public Camera vrCam;
    private TextMeshProUGUI spell0;
    private TextMeshProUGUI spell1;
    private TextMeshProUGUI spell2;
    private TextMeshProUGUI spell3;
    private TextMeshProUGUI spell4;
    
    private Image blank0;
    private Image fireball0;
    private Image petrify0;
    private Image shield0;
    private Image blank1;
    private Image fireball1;
    private Image petrify1;
    private Image shield1;
    private Image blank2;
    private Image fireball2;
    private Image petrify2;
    private Image shield2;
    private Image blank3;
    private Image fireball3;
    private Image petrify3;
    private Image shield3;
    private Image blank4;
    private Image fireball4;
    private Image petrify4;
    private Image shield4;

    public GameObject projectile;
    public float speed = 100f;

    public List<string> fireList = new List<string>();
    public List<string> shieldList1 = new List<string>();
    public List<string> shieldList2 = new List<string>();
    public List<string> petrifyList1 = new List<string>();
    public List<string> petrifyList2 = new List<string>();
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
        
        blank0 = pcCanvas.transform.Find("Blank0").GetComponent<Image>();   
        fireball0 = pcCanvas.transform.Find("Fireball0").GetComponent<Image>();
        fireball0.enabled = false;
        petrify0 = pcCanvas.transform.Find("Petrify0").GetComponent<Image>();
        petrify0.enabled = false;
        shield0 = pcCanvas.transform.Find("Shield0").GetComponent<Image>();
        shield0.enabled = false;

        blank1 = pcCanvas.transform.Find("Blank1").GetComponent<Image>();
        fireball1 = pcCanvas.transform.Find("Fireball1").GetComponent<Image>();
        fireball1.enabled = false;
        petrify1 = pcCanvas.transform.Find("Petrify1").GetComponent<Image>();
        petrify1.enabled = false;
        shield1 = pcCanvas.transform.Find("Shield1").GetComponent<Image>();
        shield1.enabled = false;
        blank2 = pcCanvas.transform.Find("Blank2").GetComponent<Image>();
        fireball2 = pcCanvas.transform.Find("Fireball2").GetComponent<Image>();
        fireball2.enabled = false;
        petrify2 = pcCanvas.transform.Find("Petrify2").GetComponent<Image>();
        petrify2.enabled = false;
        shield2 = pcCanvas.transform.Find("Shield2").GetComponent<Image>();
        shield2.enabled = false;
        blank3 = pcCanvas.transform.Find("Blank3").GetComponent<Image>();
        fireball3 = pcCanvas.transform.Find("Fireball3").GetComponent<Image>();
        fireball3.enabled = false;
        petrify3 = pcCanvas.transform.Find("Petrify3").GetComponent<Image>();
        petrify3.enabled = false;
        shield3 = pcCanvas.transform.Find("Shield3").GetComponent<Image>();
        shield3.enabled = false;
        blank4 = pcCanvas.transform.Find("Blank4").GetComponent<Image>();
        fireball4 = pcCanvas.transform.Find("Fireball4").GetComponent<Image>();
        fireball4.enabled = false;
        petrify4 = pcCanvas.transform.Find("Petrify4").GetComponent<Image>();
        petrify4.enabled = false;
        shield4 = pcCanvas.transform.Find("Shield4").GetComponent<Image>();
        shield4.enabled = false;

        string fPath = Application.dataPath + "/wordsFire.txt";
        string s1Path = Application.dataPath + "/wordsShield1.txt";
        string s2Path = Application.dataPath + "/wordsShield2.txt";
        string p1Path = Application.dataPath + "/wordsPetrify1.txt";
        string p2Path = Application.dataPath + "/wordsPetrify2.txt";
        ///spellPath = Application.dataPath + "/spells.txt";
        ///ClearFile(spellPath);

        ReadFile(fPath, "fire");
        ReadFile(s1Path, "shield1");
        ReadFile(s2Path, "shield2");
        ReadFile(p1Path, "petrify1");
        ReadFile(p2Path, "petrify2");
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
                if (fileName == "fire")
                {
                    fireList.Add(line);
                }
                else if (fileName == "shield1")
                {
                    shieldList1.Add(line);
                }
                else if (fileName == "shield2")
                {
                    shieldList2.Add(line);
                }
                else if (fileName == "petrify1")
                {
                    petrifyList1.Add(line);
                }
                else if (fileName == "petrify2")
                {
                    petrifyList2.Add(line);
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

    public string GenerateIncantation(String spellType)
    {
        string spell;
        if (spellType == "Fireball")
        {
            int r1 = rnd.Next(fireList.Count);
            spell = fireList[r1];
            return spell;
        }
        else if (spellType == "Shield")
        {
            int r1 = rnd.Next(shieldList1.Count);
            int r2 = rnd.Next(shieldList2.Count);
            spell = shieldList1[r1] + shieldList2[r2];
            return spell;
        }
        else
        {
            int r1 = rnd.Next(petrifyList1.Count);
            int r2 = rnd.Next(petrifyList1.Count);
            int r3 = rnd.Next(petrifyList2.Count);
            spell = petrifyList1[r1] + petrifyList1[r2] + petrifyList2[r3];
            return spell;
        }
    }
    /// <summary>
    /// generate a new spell with a type eg. fire ice etc
    /// </summary>
    /// <param name="spellType"></param>
    public void AddNewSpell(string spellType)
    {
        ///string filePath = spellPath;
        ///string line = null;
        string newSpell = GenerateIncantation(spellType);
        while (actions.ContainsKey(newSpell))
        {
            newSpell = GenerateIncantation(spellType);
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
        if (spellType == "Shield")
        {
            actions.Add(newSpell, Barrier);
        }
        else if ( spellType == "Fireball")
        {
            actions.Add(newSpell, Fireball);
        }
        
        else if (spellType == "Petrify")
        {
            actions.Add(newSpell, Petrify);
        }
        




        if (spell0.text == "")
        {
            blank0.enabled = false;
            spell0.text = newSpell;
            if (spellType == "Shield")
            {
                shield0.enabled = true;
            }
            else if (spellType == "Fireball")
            {
                fireball0.enabled = true;
            }
            
            else if (spellType == "Petrify")
            {
                petrify0.enabled = true;
            }
            
        }
        else if (spell1.text == "")
        {
            spell1.text = newSpell;
            blank1.enabled = false;
            if (spellType == "Shield")
            {
                shield1.enabled = true;
            }
            else if (spellType == "Fireball")
            {
                fireball1.enabled = true;
            }
            
            else if (spellType == "Petrify")
            {
                petrify1.enabled = true;
            }
            
        }
        else if (spell2.text == "")
        {
            spell2.text = newSpell;
            blank2.enabled = false;
            if (spellType == "Shield")
            {
                shield2.enabled = true;
            }
            else if (spellType == "Fireball")
            {
                fireball2.enabled = true;
            }
            
            else if (spellType == "Petrify")
            {
                petrify2.enabled = true;
            }
            
        }
        else if (spell3.text == "")
        {
            spell3.text = newSpell;
            blank3.enabled = false;
            if (spellType == "Shield")
            {
                shield3.enabled = true;
            }
            else if (spellType == "Fireball")
            {
                fireball3.enabled = true;
            }
            
            else if (spellType == "Petrify")
            {
                petrify3.enabled = true;
            }
            
        }
        else if (spell4.text == "")
        {
            spell4.text = newSpell;
            blank4.enabled = false;
            if (spellType == "Shield")
            {
                shield4.enabled = true;
            }
            else if (spellType == "Fireball")
            {
                fireball4.enabled = true;
            }
            
            else if (spellType == "Petrify")
            {
                petrify4.enabled = true;
            }
           
        }
    }

    void ClearList(string incantation)
    {
        if (spell0.text.Contains(incantation) == true)
        {
            spell0.text = "";
            blank0.enabled = true;
            fireball0.enabled = false;
            petrify0.enabled = false;
            shield0.enabled = false;
        }
        else if (spell1.text.Contains(incantation) == true)
        {
            spell1.text = "";
            blank1.enabled = true;
            fireball1.enabled = false;
            petrify1.enabled = false;
            shield1.enabled = false;
        }
        else if (spell2.text.Contains(incantation) == true)
        {
            spell2.text = "";
            blank2.enabled = true;
            fireball2.enabled = false;
            petrify2.enabled = false;
            shield2.enabled = false;
        }
        else if (spell3.text.Contains(incantation) == true)
        {
            spell3.text = "";
            blank3.enabled = true;
            fireball3.enabled = false;
            petrify3.enabled = false;
            shield3.enabled = false;
        }
        else if (spell4.text.Contains(incantation) == true)
        {
            spell4.text = "";
            blank4.enabled = true;
            fireball4.enabled = false;
            petrify4.enabled = false;
            shield4.enabled = false;
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
            AddNewSpell(spellType);
            Destroy(other.gameObject);
        }
    }
    void Barrier()
    {
        if (ui.GetComponent<GameMenu>().isPaused)
        {
            return;
        }
        barrier.SetActive(true);
        barrier.GetComponent<ShieldScript>().ResetShield();
    }

    void Petrify()
    {
        if (ui.GetComponent<GameMenu>().isPaused)
        {
            return;
        }
        AIInfo[] enemies = FindObjectsOfType<AIInfo>();

        //ViewCheck vrCam = FindObjectOfType<ViewCheck>();
        ViewCheck viewChecker = vrCam.GetComponent<ViewCheck>();

        foreach (AIInfo enemy in enemies)
        {
            if (viewChecker.InView(enemy.gameObject))
            {
                enemy.petrified = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (other.gameObject.tag == "scroll")
        {
            string spellType = other.gameObject.GetComponent<scrollScript>().GetScrollType();
            AddNewSpell(spellType);
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
            //AddNewSpell("Fireball");
            Barrier();
            //Fireball();
        }
    }
    
}
