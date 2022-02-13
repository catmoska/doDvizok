using System.Collections.Generic;
using UnityEngine;

public class StartDoDvizok : MonoBehaviour
{
    [Header("start")]
    public GameObject doDvizok;

    [Header("функсий")]
    public bool SenariBool;
    public bool DistansRenderBool;

    [Header("dvizeniaCasen")]
    public List<GameObject> transformPosisionObgect;

    [Header("DistansRender")]
    public static List<GameObject> listObgectMax;
    public static List<GameObject> listObgectSred;
    public static List<GameObject> listObgectMin;

    public GameObject glavniObgekt;
    [Range(0, 200)]
    public float DistansMax = 10;
    [Range(0, 200)]
    public float DistansSred = 10;
    [Range(0, 200)]
    public float DistansMin = 10;


    void Awake()
    {
        GameObject i = Instantiate(doDvizok, Vector3.zero, Quaternion.identity);

        dvizeniaCasen.tranPers = transformPosisionObgect;

        DistansRender.listObgect = new List<List<GameObject>> { listObgectMax, listObgectSred, listObgectMin };
        DistansRender.glavniObgekt = glavniObgekt;
        DistansRender.DistansMax = DistansMax;
        DistansRender.DistansSred = DistansSred;
        DistansRender.DistansMin = DistansMin;


        var senariyy = i.GetComponent<senariy>(); senariyy.enabled = SenariBool;
        var DistansRenderr = i.GetComponent<DistansRender>(); DistansRenderr.enabled = DistansRenderBool;

        Destroy(gameObject);
    }
}
