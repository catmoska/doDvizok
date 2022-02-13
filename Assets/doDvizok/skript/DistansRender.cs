using System;
using System.Collections.Generic;
using UnityEngine;

public class DistansRender : MonoBehaviour
{
    public static List<List<GameObject>> listObgect;

    public static GameObject glavniObgekt;
    public static float DistansMax;
    public static float DistansSred;
    public static float DistansMin;

    private void Awake()
    {
        if (glavniObgekt == null) glavniObgekt = gameObject;
    }

    void Update()
    {
        if (glavniObgekt != null && listObgect != null)
        {
            Vector3 pleirTrnsform = glavniObgekt.transform.position;
            for (int o = 0; o < listObgect.Count; o++)
            {
                if (listObgect[o].Count != 0)
                {
                    for (int i = 0; i < listObgect[o].Count; i++)
                    {
                        Vector3 p = listObgect[o][i].transform.position;
                        float radius = (float)Math.Sqrt(Math.Pow(p.x - pleirTrnsform.x, 2) + Math.Pow(p.y - pleirTrnsform.y, 2) + Math.Pow(p.z - pleirTrnsform.z, 2));
                        if (radius > DistansMin) listObgect[o][i].SetActive(false);
                        else listObgect[o][i].SetActive(true);
                    }
                }
            }
        }
        else gameObject.SetActive(false);
    }
}

