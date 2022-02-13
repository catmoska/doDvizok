using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class senariy : MonoBehaviour
{
    public List<TextAsset> text;
    private List<string> funksia = new List<string>() { "new", "golos" , "golos2" };
    private List<bool> textObrabotano = new List<bool>();
    private List<string> sagi;
    private neremeniNrogres neremen = new neremeniNrogres();
    public bool debag;

    public void Start() 
    {
        for (int i = 0; i < text.Count; i ++ ) textObrabotano.Add(false);

        StartCoroutine(obrabotka(0));
    }

    private IEnumerator obrabotka(int indecs)
    {
        if (debag) Debug.Log(indecs);
        var _textB = text[indecs].text.ToLower().ToCharArray();
        List<string> _text = new List<string>();
        List<int> stroski = new List<int>();
        bool VFuncsi = false;
        string nemFuncsi;


        for (int  i =0; i < _textB.Length; i++) 
            _text.Add(_textB[i].ToString());

        for (int i = 0; i < _text.Count; i++)
        {
            if (_text[_text.Count - i - 1] == "\n")
            {
                _text.RemoveAt(_text.Count - i - 1);
                stroski.Add(i);
            }
        }


        _text.Add("    end     ");

        int kolisestvo = _text.Count;

        for (int  i =0; i < kolisestvo; i++ )
        {
            int tre = i !< kolisestvo ? i : i+1;

            while (_text[i] == " ") i++;

            if (_text[i] == "<" && !VFuncsi && i < kolisestvo)
            {
                VFuncsi = true;
                nemFuncsi = null;

                do i++; while (_text[i] == " ");

                i--;
                do
                {
                    i++;
                    nemFuncsi += _text[i];
                } while (_text[i+1] != " ");


                int funcsia = -5;
                for (int u = 0; u < funksia.Count; u++)
                    if (funksia[u] == nemFuncsi) 
                    { funcsia = u; u = funksia.Count; }

                
                if (funcsia == -5) Debug.LogError($"ошибка такои функсий нет:  {nemFuncsi}"+ ctroka(stroski, i));
                if (debag) Debug.Log("определения функсий:   "+funcsia + "   "+ctroka(stroski, i));

                switch (funcsia)
                {
                    case 0:
                        neww ne = new neww();

                        do
                        {
                            while (_text[i] == " ") i++;

                            string ner = null; int nerI = -1; i++;
                            do
                            {
                                if (debag) Debug.Log(i + " " + (_text.Count - 1) + " " + _text[i + 1] + " " + (_text[i + 1] != ">") + ctroka(stroski, i));
                                i++; ner += _text[i];
                                if (_text[i + 1] == ">") Debug.LogError($"не закончиний синтексис переменои {ner}" + ctroka(stroski, i));
                            } while (_text[i + 1] != " ");

                            for (int p = 0; p < neww.nermeni.Count; p++)
                            {
                                if (neww.nermeni[p] == ner)
                                {
                                    nerI = p;
                                    p = neww.nermeni.Count;
                                }
                                else if (p == neww.nermeni.Count - 1) Debug.LogError($"етои переменои нет {ner}" + ctroka(stroski, i));
                            }

                            do i++; while (_text[i] == " ");

                            if (_text[i] == "=")
                            {
                                do i++; while (_text[i] == " ");

                                if (_text[i] == '"'.ToString())
                                {
                                    string f = null;
                                    do
                                    {
                                        i++;
                                        f += _text[i];
                                    } while (_text[i + 1] != '"'.ToString());
                                    i++;

                                    ne.zanos(nerI, f, 1);
                                    if (debag) Debug.Log($"значения: {nerI} {f}" + ctroka(stroski, i));
                                }
                                else if (_text[i] == "f" || _text[i] == "t")
                                {
                                    string f = null;
                                    do
                                    {
                                        i++;
                                        f += _text[i];
                                    } while (_text[i + 1] != " ");
                                    i++;

                                    ne.zanos(nerI, f, 4);
                                    if (debag) Debug.Log($"значения: {nerI} {f}" + ctroka(stroski, i));
                                }
                                else if (_text[i] == "f" && _text[i] == "t")
                                {
                                    string f = null;
                                    int tos = 0;
                                    do
                                    {
                                        i++;
                                        f += _text[i];
                                        if (_text[i] == "." || _text[i] == ",")
                                        {
                                            tos++;
                                            _text[i] = ".";
                                        }
                                    } while (_text[i + 1] != " ");
                                    i++;

                                    if (tos > 1) Debug.LogError("ошибка переменя имеит две точки или коми");
                                    else if (tos == 1) ne.zanos(nerI, f, 3);
                                    else ne.zanos(nerI, f, 2);

                                    if (debag) Debug.Log($"значения: {nerI} {f}" + ctroka(stroski, i));
                                }
                                else Debug.LogError("нема такого типа" + ctroka(stroski, i));
                            }
                            else Debug.LogError($"в етом мести не пробел '=' {_text[i]}" + ctroka(stroski, i));

                            while (_text[i] == " ") i++;

                            if (_text[i + 1] == "<") Debug.LogError("не правилний синтексис >" + ctroka(stroski, i));

                            if (!(i < _text.Count)) Debug.LogError("текст не закрит" + ctroka(stroski, i));

                            if (debag) Debug.Log(i + " " + (_text.Count - 1) + " " + _text[i + 1] + " " + (_text[i + 1] != ">") + ctroka(stroski, i));
                        } while (_text[i + 1] != ">");

                        VFuncsi = false;
                        i += 2;
                        neremen.Add(ne.zanes());
                        break;
                    case 1:
                        golos golo = new golos();

                        do{
                            while (_text[i] == " ") i++;

                            string ner = null; int nerI = -1; i++;
                            do{
                                if (debag) Debug.Log(i + " " + (_text.Count - 1) + " " + _text[i + 1] + " " + (_text[i + 1] != ">")+ ctroka(stroski, i));
                                i++; ner += _text[i];
                                if (_text[i + 1] == ">") Debug.LogError($"не закончиний синтексис переменои {ner}"+ ctroka(stroski, i));
                            } while (_text[i + 1] != " ");

                            for (int p = 0; p < golos.nermeni.Count; p++)
                            {   
                                if (golos.nermeni[p] == ner)
                                {
                                    nerI = p;
                                    p = golos.nermeni.Count;
                                }else if (p == golos.nermeni.Count - 1) Debug.LogError($"етои переменои нет {ner}"+ ctroka(stroski, i));
                            }

                            do i++; while (_text[i] == " ");

                            if (_text[i] == "=")
                            {
                                do i++; while (_text[i] == " ");

                                if (_text[i] == '"'.ToString())
                                {
                                    string f = null;
                                    do
                                    {
                                        i++;
                                        f += _text[i];
                                    } while (_text[i + 1] != '"'.ToString());
                                    i++;

                                    golo.zanos(nerI, f,1);
                                    if (debag) Debug.Log($"значения: {nerI} {f}"+ ctroka(stroski, i));
                                }
                                else if (_text[i] == "f" || _text[i] == "t")
                                {
                                    string f = null;
                                    do
                                    {
                                        i++;
                                        f += _text[i];
                                    } while (_text[i + 1] != " ");
                                    i++;

                                    golo.zanos(nerI, f,4);
                                    if (debag) Debug.Log($"значения: {nerI} {f}"+ ctroka(stroski, i));
                                }
                                else if (_text[i] == "f" && _text[i] == "t")
                                {
                                    string f = null;
                                    int tos = 0;
                                    do
                                    {
                                        i++;
                                        f += _text[i];
                                        if (_text[i] == "." || _text[i] == ",") 
                                        { 
                                            tos++;
                                            _text[i] = ".";
                                        }
                                    } while (_text[i + 1] != " ");
                                    i++;

                                    if (tos > 1) Debug.LogError("ошибка переменя имеит две точки или коми");
                                    else if(tos ==1) golo.zanos(nerI, f, 3);
                                    else golo.zanos(nerI, f,2);

                                    if (debag) Debug.Log($"значения: {nerI} {f}" + ctroka(stroski, i));
                                }
                                else Debug.LogError("нема такого типа"+ ctroka(stroski, i));
                            }
                            else Debug.LogError($"в етом мести не пробел '=' {_text[i]}" + ctroka(stroski, i));

                            while (_text[i] == " ") i++;

                            if (_text[i + 1] == "<") Debug.LogError("не правилний синтексис >" + ctroka(stroski, i));

                            if (!(i < _text.Count)) Debug.LogError("текст не закрит"+ ctroka(stroski, i));

                            if (debag) Debug.Log(i + " " + (_text.Count - 1) + " " + _text[i + 1] + " " + (_text[i + 1] != ">") + ctroka(stroski, i));
                        } while (_text[i + 1] != ">");

                        VFuncsi = false;
                        i += 2;
                        break;
                }
            }
            else if (_text[i] == "<" && VFuncsi && i < kolisestvo) Debug.LogError("не правилний синтексис <" + ctroka(stroski, i));
            else if(_text[i] == ">" && !VFuncsi && i < kolisestvo) Debug.LogError("не правилний синтексис >" + ctroka(stroski, i));
        }
        
        
        yield return new WaitForSeconds(0);
        textObrabotano[indecs] = true;
    }

    string ctroka(List<int> stroski ,int i) 
    {
        for (int q = 0; q < stroski.Count; q++)
        {
            if (stroski[q] > i)
                return "          строка: "+q;
        }
        return "          строка: " + stroski.Count;
    }
}

public class neww
{
    public static List<string> nermeni = new List<string>() { "neim", "zna" };
    public static List<string> nermeniTin = new List<string>() { "string", "" };
    // string int flost bool list

    string neim;
    string znaS;
    int znaI;
    float znaF;
    bool znaB;
    bool zna=false;

    public vrem zanes() 
    {
        if (zna && neim != null)
        {
            vrem i = new vrem();
            i.neim(neim);
            if (znaS != null) i.zan(znaS);
            if (znaI != new int()) i.zan(znaI);
            if (znaF != new float()) i.zan(znaF);
            if (znaB != new bool()) i.zan(znaB);
            return i;
        }
        else Debug.LogError("долзно бить все знасения   zna   neim");
        return null;
    }

    public void zanos(int nem, string znasenia, int tin = 0)
    {
        switch (tin)
        {
            case 0:
                var ner = znasenia.ToLower().ToCharArray();
                bool tex = false;

                if (ner[0] == '{')
                {
                    zanos(nem, znasenia, 5); break;
                }

                int tos = 0;
                for (int i = 0; i < ner.Length; i++)
                {
                    char o = ner[i];
                    if (!(o == '0' || o == '1' || o == '2' || o == '3' || o == '4' || o == '5' || o == '6' || o == '7' || o == '8' || o == '9' || o == '.' || o == ',') && !tex)
                        tex = true;

                    if (o == '.' || o == ',') tos++;
                }

                if (znasenia == "true" || znasenia == "folse")
                { zanos(nem, znasenia, 4); break; }

                if (tex || tos >= 2)
                {
                    zanos(nem, znasenia, 1); break;
                }
                else if (tos == 1)
                {
                    for (int i = 0; i < ner.Length; i++) if (ner[i] == ',') { ner[i] = '.'; i = ner.Length; }
                    zanos(nem, znasenia, 3); break;
                }
                else if (tos == 0)
                { zanos(nem, znasenia, 2); break; }

                Debug.LogError("сказите catmoske што он пидор");
                break;

            case 1:
                if (nermeniTin[nem] != "string")
                { Debug.LogError("перемена не являетса типа: string"); break; }
                switch (nem)
                {
                    case 0:
                        neim = znasenia;
                        break;
                    case 1:
                        if (!zna)
                            znaS = znasenia;
                        else Debug.Log("толко одна переменая 'zna' ");
                        zna = true;
                        break;
                    default:
                        Debug.LogError("здесь нема етои перемених");
                        break;
                }
                break;
            case 2:
                if (nermeniTin[nem] != "int")
                { Debug.LogError("перемена не являетса типа: int"); break; }
                switch (nem)
                {
                    case 1:
                        if (!zna)
                            znaI = Convert.ToInt32(znasenia);
                        else Debug.Log("толко одна переменая 'zna' ");
                        zna = true;
                        break;
                    default:
                        Debug.LogError("здесь нема етои перемених");
                        break;
                }
                break;
            case 3:
                if (nermeniTin[nem] != "float")
                { Debug.LogError("перемена не являетса типа: float"); break; }
                switch (nem)
                {
                    case 1:
                        if (!zna)
                            znaF = float.Parse(znasenia);
                        else Debug.Log("толко одна переменая 'zna' ");
                        zna = true;
                        break;
                    default:
                        Debug.LogError("здесь нема етои перемених");
                        break;
                }
                break;
            case 4:
                if (nermeniTin[nem] != "bool")
                { Debug.LogError("перемена не являетса типа: bool"); break; }
                switch (nem)
                {
                    case 1:
                        if (!zna)
                            znaB = bool.Parse(znasenia);
                        else Debug.Log("толко одна переменая 'zna' ");
                        zna = true;
                        break;
                    default:
                        Debug.LogError("здесь нема етои перемених");
                        break;
                }
                break;
            case 5:
                if (nermeniTin[nem] != "list")
                { Debug.LogError("перемена не являетса типа: list"); break; }
                Debug.LogError("здесь нема перемених");
                break;
        }
    }
}

public class golos
{
    public static List<string> nermeni = new List<string>() { "indeks", "text" };
    public static List<string> nermeniTin = new List<string>() { "int", "string" };
    // string int flost bool list

    int indeks = 0;
    string text = "те//кст не при//зна//че//н";

    public void zanos(int nem, string znasenia, int tin = 0)
    {
        if(nem == 1)
            Golos.cintez(znasenia, 0, 1,Vector3.zero);

        switch (tin)
        {
            case 0:
                var ner = znasenia.ToLower().ToCharArray();
                bool tex = false;

                if(ner[0] == '{')
                {
                    zanos(nem, znasenia, 5); break;
                }

                int tos = 0;
                for (int i = 0; i < ner.Length; i++)
                {
                    char o = ner[i];
                    if (!(o == '0' || o == '1' || o == '2' || o == '3' || o == '4' || o == '5' || o == '6' || o == '7' || o == '8' || o == '9' || o == '.' || o == ',') && !tex)
                        tex = true;

                    if (o == '.' || o == ',') tos++;
                }

                if (znasenia == "true" || znasenia == "folse")
                { zanos(nem, znasenia, 4); break; }

                if (tex || tos >= 2)
                { zanos(nem, znasenia, 1); break; 
                } else if (tos == 1)
                {
                    for (int i = 0; i < ner.Length; i++) if (ner[i] == ',') { ner[i] = '.'; i = ner.Length; }
                    zanos(nem, znasenia, 3); break;
                } else if (tos == 0)
                { zanos(nem, znasenia, 2); break; }

                Debug.LogError("сказите catmoske што он пидор");
                break;

            case 1:
                if (nermeniTin[nem] != "string") 
                { Debug.LogError("перемена не являетса типа: string"); break;}
                switch (nem)
                {
                    case 1:
                        text = znasenia;
                        break;
                    default:
                        Debug.LogError("здесь нема етои перемених");
                        break;
                }
                break;
            case 2:
                if (nermeniTin[nem] != "int")
                { Debug.LogError("перемена не являетса типа: int"); break; }
                switch (nem)
                {
                    case 0:
                        indeks = Convert.ToInt32(znasenia);
                        break;
                    default:
                        Debug.LogError("здесь нема етои перемених");
                        break;
                }
                break;
            case 3:
                if (nermeniTin[nem] != "float")
                { Debug.LogError("перемена не являетса типа: float"); break; }
                Debug.LogError("здесь нема перемених");
                break;
            case 4:
                if (nermeniTin[nem] != "bool")
                { Debug.LogError("перемена не являетса типа: bool"); break; }
                Debug.LogError("здесь нема перемених");
                break;
            case 5:
                if (nermeniTin[nem] != "list")
                { Debug.LogError("перемена не являетса типа: list"); break; }
                Debug.LogError("здесь нема перемених");
                break;
        }
    }
}

public class vrem
{
    public string nem;
    public string s;
    public int i;
    public float f;
    public bool b;
    public int n;

    public void neim(string ne) 
    { nem = ne; }
    public void zan(string ss)
    { s = ss; n = 1; }
    public void zan(int ii)
    { i = ii; n = 2; }
    public void zan(float ff)
    { f = ff; n = 3; }
    public void zan(bool bb)
    { b = bb; n = 4; }
}

public class neremeniNrogres
{
    public int neremenix = 0;
    public Dictionary<string, int> peremeniInt = new Dictionary<string, int>();
    public Dictionary<string, float> peremeniFloat = new Dictionary<string, float>();
    public Dictionary<string, string> peremeniString = new Dictionary<string, string>();
    public Dictionary<string, bool> peremeniBool = new Dictionary<string, bool>();

    public void Add(string key, string valu)
    { peremeniString.Add(key, valu); neremenix++; }
    public void Add(string key, int valu)
    { peremeniInt.Add(key, valu); neremenix++; }
    public void Add(string key, float valu)
    { peremeniFloat.Add(key, valu); neremenix++; }
    public void Add(string key, bool valu)
    { peremeniBool.Add(key, valu); neremenix++; }
    public void Add(vrem y)
    {
        if (y.n == 1) peremeniString.Add(y.nem, y.s);
        else if (y.n == 2) peremeniInt.Add(y.nem, y.i); 
        else if(y.n == 3) peremeniFloat.Add(y.nem, y.f);
        else peremeniBool.Add(y.nem, y.b);

        neremenix++;
    }


    public object vzat(string neim)
    {
        foreach (var p in peremeniInt) if (p.Key == neim) return p.Value;
        foreach (var p in peremeniFloat) if (p.Key == neim) return p.Value;
        foreach (var p in peremeniString) if (p.Key == neim) return p.Value;
        foreach (var p in peremeniBool) if (p.Key == neim) return p.Value;
        return null;
    }

    public String vzat(string neim, String i)
    { return peremeniString[neim]; }
    public int vzat(string neim, int i)
    { return peremeniInt[neim]; }
    public float vzat(string neim, float i)
    { return peremeniFloat[neim]; }
    public bool vzat(string neim, bool i)
    { return peremeniBool[neim]; }
    public string vzatString(string neim)
    { return peremeniString[neim]; }
    public int vzatInt(string neim)
    { return peremeniInt[neim]; }
    public float vzatFloat(string neim)
    { return peremeniFloat[neim]; }
    public bool vzatBool(string neim)
    { return peremeniBool[neim]; }

    public void vstavit(string neim, string i)
    { peremeniString[neim] = i; }
    public void vstavit(string neim, int i)
    { peremeniInt[neim] = i; }
    public void vstavit(string neim, float i)
    { peremeniFloat[neim] = i; }
    public void vstavit(string neim, bool i)
    { peremeniBool[neim] = i; }
}
