using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScriptGargoyle : MonoBehaviour
{
    public GameObject playerChar;
    public GameObject firstGargoyle;
    public GameObject hallwayGargoyles;
    public GameObject exit;

    public GameObject fireScroll;
    GameObject scrollCopy;

    public GameObject lampA;
    public GameObject lampB;
    public GameObject lampC;
    public GameObject lampD;
    public GameObject lampE;

    LampPostScript aScript;
    LampPostScript bScript;
    LampPostScript cScript;
    LampPostScript dScript;
    LampPostScript eScript;

    bool aActive = false;
    bool bActive = false;
    bool cActive = false;
    bool dActive = false;
    bool eActive = false;

    string code = "";

    bool pastFirstHallway = false;
    bool pastSecondHallway = false;

    bool puzzleComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        aScript = lampA.GetComponent<LampPostScript>();
        bScript = lampB.GetComponent<LampPostScript>();
        cScript = lampC.GetComponent<LampPostScript>();
        dScript = lampD.GetComponent<LampPostScript>();
        eScript = lampE.GetComponent<LampPostScript>();

        //scrollCopy = fireScroll;
    }

    void DisableFirstGargoyle()
    {
        firstGargoyle.GetComponent<EnemyTurret>().active = false;
    }

    void DisableHallwayGargoyles()
    {
        foreach(Transform child in hallwayGargoyles.transform)
        {
            child.GetComponent<EnemyTurret>().active = false;
        }
    }

    void ResetLamps()
    {
        aScript.Deactivate();
        bScript.Deactivate();
        cScript.Deactivate();
        dScript.Deactivate();
        eScript.Deactivate();

        aActive = false;
        bActive = false;
        cActive = false;
        dActive = false;
        eActive = false;

    }

    void RespawnScroll()
    {
        if (scrollCopy == null)
        {
            scrollCopy = Instantiate(fireScroll, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RespawnScroll();

        if (!pastFirstHallway && playerChar.transform.position.z > -8)
        {
            DisableFirstGargoyle();
            pastFirstHallway = true;
        }

            if (!pastSecondHallway && playerChar.transform.position.z > 15)
        {
            DisableHallwayGargoyles();
            pastSecondHallway = true;
        }

        if (aScript.active && !aActive)
        {
            aActive = true;
            code = code + "a";
        }
        if (bScript.active && !bActive)
        {
            bActive = true;
            code = code + "b";
        }
        if (cScript.active && !cActive)
        {
            cActive = true;
            code = code + "c";
        }
        if (dScript.active && !dActive)
        {
            dActive = true;
            code = code + "d";
        }
        if (eScript.active && !eActive)
        {
            eActive = true;
            code = code + "e";
        }
        if (code.Length == 5 && !puzzleComplete)
        {
            if( code == "acebd")
            {
                exit.GetComponent<CrystalGoal>().Activate();
                puzzleComplete = true;
            }
            else
            {
                code = "";
                ResetLamps();
            }
        }

    }
}
