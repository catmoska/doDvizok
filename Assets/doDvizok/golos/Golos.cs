using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Golos : MonoBehaviour
{
    List<string> clog_1 = new List<string>() { 
        "-", "а","б","в","г","д","е","ё","ж","з","и","й","к","л","м","н","о","п","р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я" };
    List<float> clogTaim_1 = new List<float>() { 
        0.2f, 0.211f, 0.317f, 0.142f, 0.325f, 0.318f, 0.349f, 0.399f, 0.352f, 0.372f, 0.229f,
        0.209f, 0.134f, 0.301f, 0.287f, 0.303f, 0.238f, 0.235f, 0.242f, 0.277f, 0.093f, 0.214f,
        0.245f, 0.179f, 0.302f, 0.314f, 0.338f, 0.352f, 0.160f, 0.204f, 0.173f, 0.185f, 0.341f, 0.300f };
    public List<GameObject> slog_1 = new List<GameObject>() { null };

    List<string> clog_2 = new List<string>() { 
        "вы",
"ци",
"за",
"по",
"ши",
"ды",
"жё",
"ны",
"бю",
"то",
"щи",
"бы",
"сь",
"чё",
"шу",
"чу",
"ть",
"дя",
"па",
"се",
"не",
"чо",
"до",
"вя",
"на",
"ри",
"пе",
"го",
"лы",
"жи",
"со",
"те",
"фи",
"ля",
"ще",
"ро",
"ма",
"ку",
"ло",
"ву",
"но",
"ко",
"ди",
"та",
"си",
"ве",
"гу",
"су",
"шь",
"ва",
"ся",
"ша",
"дь",
"мю",
"мо",
"ху",
"зу",
"бе",
"пк",
"де",
"ки",
"ги",
"ща",
"ца",
"чи",
"че",
"лю",
"би",
"ре",
"ме",
"ст",
"ни",
"са",
"ше",
"па",
"ми",
"ле",
"хо",
"га",
"ве",
"ха",
"пи",
"ра",
"ча",
"бо",
"му",
"ти",
"во",
"ба",
"бе",
"сы",
"мы",
"тя",
"па",
"бя",
"ли",
"пу",
"ня",
"лё",
"зо",
"вё",
"ле",
"ры",
"да",
"мо",
"ра",
"ви",
"ду",
"хе",
"ге",
"же",
"фе",
"ря",
"зи",
"жа",
"лу",
"шь",
"бу",
"ту",
"ну",
"зе",
"зы",
"шё",
"ла",
"мя",
"жу",
"дё",
"фа",
"ру",
"ты",
"це",
"ка",
"рё",
"нь",
"щё",
"ль" };
    List<float> clogTaim_2 = new List<float>() {
        0.332f, 0.257f, 0.345f, 0.265f, 0.338f, 0.283f, 0.388f, 0.291f, 0.329f, 0.226f,
        0.340f, 0.278f, 0.194f, 0.308f, 0.327f, 0.273f, 0.137f, 0.307f, 0.226f, 0.332f,
        0.292f, 0.276f, 0.314f, 0.345f, 0.278f, 0.255f, 0.222f, 0.323f, 0.291f, 0.321f,
        0.250f, 0.255f, 0.294f, 0.318f, 0.381f, 0.290f, 0.288f, 0.212f, 0.298f, 0.284f,
        0.289f, 0.258f, 0.299f, 0.239f, 0.346f, 0.300f, 0.257f, 0.334f, 0.248f, 0.314f,
        0.310f, 0.318f, 0.154f, 0.275f, 0.354f, 0.281f, 0.296f, 0.305f, 0.378f, 0.307f,
        0.223f, 0.292f, 0.368f, 0.311f, 0.307f, 0.304f, 0.287f, 0.255f, 0.280f, 0.306f, 
        0.218f, 0.276f, 0.337f, 0.345f, 0.191f, 0.238f, 0.289f, 0.308f, 0.285f, 0.345f, 
        0.272f, 0.196f, 0.325f, 0.278f, 0.307f, 0.273f, 0.231f, 0.358f, 0.292f, 0.304f, 
        0.341f, 0.254f, 0.254f, 0.203f, 0.300f, 0.279f, 0.203f, 0.306f, 0.315f, 0.369f,
        0.343f, 0.302f, 0.305f, 0.291f, 0.323f, 0.318f, 0.291f, 0.299f, 0.382f, 0.250f, 
        0.388f, 0.345f, 0.313f, 0.304f, 0.348f, 0.274f, 0.221f, 0.278f, 0.210f, 0.245f,
        0.347f, 0.322f, 0.348f, 0.304f, 0.300f, 0.345f, 0.339f, 0.294f, 0.270f, 0.241f,
        0.306f, 0.244f, 0.318f, 0.215f, 0.391f, 0.300f};
    public List<GameObject> slog_2 = new List<GameObject>() {};

    List<string> clog_3 = new List<string>() { 
        "дно",
"тру",
"смо",
"тре",
"рнё",
"ска",
"где",
"спо",
"вля",
"пли",
"зго",
"сла",
"жда",
"вто",
"ско",
"дна",
"йна",
"смы",
"нте",
"рне",
"кре",
"рты",
"зве",
"гля",
"крё",
"мся",
"кла",
"ссе",
"тро",
"нта",
"нфи",
"йти",
"вры",
"вле",
"тря",
"йди",
"бла",
"дны",
"дхо",
"нна",
"нны",
"гно",
"дбе",
"лся",
"лки",
"рта",
"влю",
"бля",
"пры",
"вли",
"хло",
"схо",
"жду",
"хну",
"зню",
"тку",
"рво",
"рши",
"зть",
"кра",
"зна",
"рто",
"кто",
"шно",
"бма",
"нчи",
"йте",
"бли",
"чно",
"чне",
"чны",
"спи",
"ске",
"шку",
"бре",
"шни",
"тща",
"пре",
"дло",
"лну",
"зво",
"лты",
"мне",
"сха",
"две",
"кст",
"йдё",
"сме",
"рть",
"рны",
"лже",
"нца",
"йду",
"йма",
"сше",
"жчи",
"дше",
"хва",
"шки",
"рку",
"бну",
"мна",
"сбе",
"сна",
"лче",
"клю",
"три",
"нча",
"зжа",
"йше",
"рни",
"лго",
"два",
"рми",
"бро",
"при",
"кро",
"жно",
"вны",
"рше",
"мла",
"спу",
"ску",
"зли",
"шли",
"сть",
"лко",
"пло",
"здо",
"рте",
"зби",
"бка",
"лше",
"дни",
"тса",
"ждй",
"мни",
"блю",
"дня",
"лне",
"дну",
"вче",
"спе",
"вко",
"йно",
"сну",
"ймё",
"гре",
"зре",
"ржа",
"дпи",
"сне",
"нфо",
"для",
"бще",
"нно",
"сса",
"лчу",
"вме",
"тво",
"хто",
"зде",
"тве",
"влё",
"ппы",
"спа",
"стю",
"бке",
"бки",
"мню",
"чре",
"сшу",
"тня",
"взя",
"вку",
"гро",
"нри",
"про",
"сто",
"рня",
"тно",
"нты",
"ргу",
"кру",
"нни",
"сму",
"тся",
"зно",
"что",
"сво",
"гда",
"нти",
"зни",
"рсо",
"зда",
"ста",
"рвы",
"ршо",
"шко",
"жны",
"сре",
"дне",
"тра",
"вмы",
"мпа",
"сте",
"сни",
"кте",
"сту",
"шла",
"дру",
"стя",
"чка",
"лка",
"сли",
"йся",
"гра",
"сце",
"вка",
"шлы",
"нто",
"нги",
"сло",
"вно",
"гры",
"клу",
"змо",
"бра",
"слу",
"всё",
"шка",
"сты",
"хво",
"рма",
"нка",
"гру",
"кти",
"вне",
"сле",
"пла",
"чки",
"чле",
"ски",
"тпа",
"пна",
"мба",
"дво",
"чни",
"гла",
"пря",
"сти",
"все",
"всо" };
    List<float> clogTaim_3 = new List<float>() {
        0.373f, 0.262f, 0.416f, 0.286f, 0.386f, 0.291f, 0.427f, 0.286f, 0.346f, 0.278f, 
        0.412f, 0.375f, 0.397f, 0.411f, 0.329f, 0.377f, 0.351f, 0.400f, 0.466f, 0.397f,
        0.289f, 0.319f, 0.432f, 0.395f, 0.315f, 0.429f, 0.298f, 0.411f, 0.316f, 0.373f,
        0.411f, 0.356f, 0.345f, 0.391f, 0.267f, 0.342f, 0.390f, 0.363f, 0.332f, 0.354f,
        0.340f, 0.375f, 0.394f, 0.441f, 0.382f, 0.349f, 0.359f, 0.375f, 0.261f, 0.324f,
        0.407f, 0.402f, 0.361f, 0.335f, 0.423f, 0.253f, 0.399f, 0.384f, 0.221f, 0.319f,
        0.368f, 0.379f, 0.259f, 0.379f, 0.376f, 0.431f, 0.349f, 0.324f, 0.360f, 0.408f,
        0.354f, 0.301f, 0.334f, 0.331f, 0.335f, 0.392f, 0.358f, 0.257f, 0.425f, 0.371f,
        0.312f, 0.373f, 0.365f, 0.368f, 0.401f, 0.220f, 0.370f, 0.423f, 0.267f, 0.367f,
        0.430f, 0.463f, 0.392f, 0.388f, 0.376f, 0.380f, 0.348f, 0.331f, 0.318f, 0.328f,
        0.335f, 0.381f, 0.401f, 0.412f, 0.447f, 0.292f, 0.246f, 0.474f, 0.410f, 0.438f,
        0.373f, 0.444f, 0.356f, 0.345f, 0.366f, 0.244f, 0.309f, 0.398f, 0.359f, 0.446f,
        0.370f, 0.349f, 0.288f, 0.338f, 0.354f, 0.209f, 0.399f, 0.279f, 0.395f, 0.405f,
        0.400f, 0.263f, 0.468f, 0.334f, 0.318f, 0.372f, 0.351f, 0.319f, 0.415f, 0.429f,
        0.368f, 0.366f, 0.298f, 0.296f, 0.370f, 0.362f, 0.434f, 0.393f, 0.410f, 0.406f,
        0.297f, 0.443f, 0.447f, 0.361f, 0.375f, 0.406f, 0.402f, 0.388f, 0.406f, 0.331f,
        0.301f, 0.402f, 0.309f, 0.359f, 0.230f, 0.277f, 0.329f, 0.317f, 0.323f, 0.340f,
        0.358f, 0.315f, 0.354f, 0.398f, 0.242f, 0.374f, 0.327f, 0.301f, 0.341f, 0.434f,
        0.355f, 0.375f, 0.379f, 0.279f, 0.308f, 0.361f, 0.341f, 0.377f, 0.314f, 0.394f,
        0.381f, 0.425f, 0.388f, 0.439f, 0.275f, 0.333f, 0.379f, 0.399f, 0.316f, 0.375f,
        0.393f, 0.400f, 0.281f, 0.392f, 0.358f, 0.367f, 0.393f, 0.303f, 0.293f, 0.402f,
        0.331f, 0.337f, 0.317f, 0.356f, 0.373f, 0.406f, 0.384f, 0.406f, 0.282f, 0.360f,
        0.395f, 0.409f, 0.411f, 0.346f, 0.324f, 0.285f, 0.397f, 0.344f, 0.357f, 0.359f,
        0.314f, 0.307f, 0.360f, 0.370f, 0.407f, 0.392f, 0.260f, 0.407f, 0.408f, 0.295f,
        0.313f, 0.368f, 0.318f, 0.296f, 0.341f, 0.404f, 0.442f, 0.358f, 0.393f, 0.268f,
        0.325f, 0.380f, 0.351f };
    public List<GameObject> slog_3 = new List<GameObject>() {};

    List<string> clog_4 = new List<string>() { 
        "льни",
"стра",
"льно",
"ться",
"нька",
"взды",
"льне",
"лсты",
"вздо",
"ссны",
"взры",
"сска",
"дьми",
"льну",
"мпью",
"зьму",
"стру",
"звле",
"стры",
"спро",
"лзно",
"скро",
"вспо",
"ссла",
"ньги",
"льше",
"ссле",
"кста",
"кспе",
"твле",
"льзу",
"льна",
"льшо",
"всту",
"льчи",
"нько",
"збло",
"вклю",
"йста",
"лько",
"схва",
"лжны",
"лкну",
"льны",
"вста",
"вска",
"стро",
"мства",
"тству",
"йство",
"тстви",
"тства",
"встве" };
    List<float> clogTaim_4 = new List<float>() { 
        0.412f, 0.365f, 0.470f, 0.414f, 0.422f, 0.422f, 0.455f, 0.400f, 0.466f, 0.402f, 
        0.429f, 0.368f, 0.408f, 0.410f, 0.407f, 0.434f, 0.367f, 0.411f, 0.373f, 0.363f,
        0.448f, 0.423f, 0.365f, 0.427f, 0.396f, 0.443f, 0.468f, 0.324f, 0.329f, 0.372f, 
        0.384f, 0.445f, 0.428f, 0.340f, 0.428f, 0.426f, 0.444f, 0.344f, 0.314f, 0.407f, 
        0.420f, 0.449f, 0.398f, 0.426f, 0.341f, 0.330f, 0.393f, 0.472f, 0.411f, 0.502f, 
        0.387f, 0.387f, 0.434f, 0.434f};
    public List<GameObject> slog_4 = new List<GameObject>() {};


    public AudioMixer am; // �������� ������� ��� �������
    public List<AudioMixerSnapshot> golosZagotovki = new List<AudioMixerSnapshot>();


    static List<List<string>> clog;
    static List<List<float>> clogTaim;
    static List<List<GameObject>> slog;

    bool ontimizar = true; // ����������� ��� ���������� folse

    static public Golos instance;

    
    private void Awake()
    {
        #if UNITY_EDITOR_64
        ontimizar = false;  // jgnbvbpfcbz drkexftncf  
        #endif
        instance = this;
        ontimizer();
    }

    void ontimizer()
    {
        clog = new List<List<string>>() { clog_1, clog_2, clog_3, clog_4 };
        clogTaim = new List<List<float>>() { clogTaim_1, clogTaim_2, clogTaim_3, clogTaim_4 };
        slog = new List<List<GameObject>>() { slog_1, slog_2, slog_3, slog_4 };
        if (ontimizar)
        {
            clog_1 = null; clog_2 = null; clog_3 = null; clog_4 = null;
            clogTaim_1 = null; clogTaim_2 = null; clogTaim_3 = null; clogTaim_4 = null;
            slog_1 = null; slog_2 = null; slog_3 = null; slog_4 = null;
        }
    }


    public string sss = "�//�";
    private void Update()
    {
       if (!ontimizar && clog == null) ontimizer();

       if (Input.GetKeyDown(KeyCode.E))
       {
           cintez(sss, 0, 1, new Vector3(0, 0, 0));
       }
    }

    public static float cintez(string textSinteg, int golos, float spid, Vector3 posisia, float[,] emosi = null)
    {
        // emosi = {���,��������,���������}

        if (textSinteg == "")
        {
            Debug.LogError("����������� �����");
            return 0;
        }

        int nroxod = 0;
        List<string> textObriv = new List<string>();
        List<int> clasObgect = new List<int>();
        List<int> timers = new List<int>();
        textObriv.Add("");
        var u = textSinteg.ToLower().ToCharArray();

        for (int i = 0; i< u.Length; i++)
        {
            switch (u[i])
            {
                case '/':
                    textObriv.Add("");
                    if (u[i + 1] == '/'){
                        timers.Add(0);
                        i++;
                    }
                    else {
                        int m = 0;
                        if (u[i + 1] == '-') m = 1;
                        if (u[i + 3 + m] != '/') Debug.LogError("���������� ������������� /  :"+ textSinteg +"  "+i);
                        
                        string p = "";
                        if (u[i + 1 + m] == '0')
                        {
                            p = (u[i + 2 + m].ToString());
                        }
                        else
                        {
                            p = (u[i + 1 + m].ToString() + u[i + 2 + m].ToString());
                        }
                        if (m == 0) 
                            timers.Add(int.Parse(p));
                        else 
                            timers.Add(-int.Parse(p));
                        i += 3 + m;
                    }
                    nroxod++;
                    break;

                case ' ':
                    if (textObriv[textObriv.Count - 1] == "")
                    {Debug.LogError("���������� ������� �������� ������� ������:  " + textSinteg);return 0;}
                    timers.Add(0);
                    textObriv.Add("-");
                    textObriv.Add("");
                    timers.Add(1);
                    nroxod += 2;
                    break;

                default:
                    textObriv[nroxod] += u[i];
                    break;
            }
        }
        timers.Add(0);

        List<int> indecs = new List<int>();
        for (int i = 0; i < textObriv.Count; i++)
        {
            int z = textObriv[i].Length -1;
            if (z > 2) z = 3;

            for (int o = 0; o < clog[z].Count; o++)
            {
                if (textObriv[i] == clog[z][o])
                {
                    indecs.Add(o);
                    o = clog[z].Count;
                    clasObgect.Add(z);
                }
                else if (o == clog[z].Count - 1) Debug.LogError("��������� ����: " + textObriv[i] + "  �����: " + textSinteg);
            }
        }

        if (emosi == null)
        {
            emosi = new float[indecs.Count, 3];
            for (int i = 0; i < indecs.Count; i++)
            {emosi[i, 0] = 0;emosi[i, 1] = 0;emosi[i, 2] = 1;}
        }

        instance.StartCoroutine(sintez(indecs,timers, posisia,golos, clasObgect, emosi, spid));

        float tim=0;
        for (int i = 0; i < indecs.Count; i++)
        {
            float timer = (((clogTaim[clasObgect[i]][indecs[i]] + ((float)timers[i] / 100))
                * (2.5f - emosi[i, 1] / 10)) - 0.35f) * spid;
            tim += timer;
        }
        

        return tim;
    }

    static IEnumerator sintez(List<int> indecs, List<int> timers,Vector3 posisia, int golos, List<int> clasObgect, float[,] emosi,float spid)
    {
        if (indecs.Count > emosi.Length/3) Debug.LogError("�� ���������� ������ �����:" + indecs.Count + " ����:" + emosi.Length/3);

        instance.golosZagotovki[golos].TransitionTo(0);
        List<GameObject> ooo = new List<GameObject>();
        int nrox=0;

        
        for (int i = 0; i < indecs.Count; i++) 
        {
            float timer = (((clogTaim[clasObgect[i]][indecs[i]] + ((float)timers[i] / 100)) 
                * (2.5f - emosi[i, 1]/10))-0.35f)* spid;
            
            if (indecs[i] == 0 && clasObgect[i] ==0)
            {
                yield return new WaitForSeconds(timer);
            }
            else
            {
                instance.StartCoroutine(instance.efecsTon(i, emosi, timer));
                ooo.Add(Instantiate(slog[clasObgect[i]][indecs[i]] , posisia, Quaternion.identity));
                instance.StartCoroutine(instance.efecsVso(i, emosi, timer, ooo[nrox], spid));
                yield return new WaitForSeconds(timer);
                nrox++;
            }
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < ooo.Count; i++)
        {
            Destroy(ooo[ooo.Count-i-1]);
        }
    }

    IEnumerator efecsTon(int i, float[,] emosi, float timer)
    {
        if (i == 0)
            am.SetFloat("efecsTon", emosi[i, 0] / 10 + 1);
        else
        {
            float p1 = emosi[i, 0] / 10 + 1;
            float p1s = emosi[i, 0] / 10 + 21;
            float p2 = emosi[i - 1, 0] / 10 + 21;
            float p = p1s - p2;
            int nov;
            if (Math.Abs(p) > 0.1f) nov = 10;
            else if (Math.Abs(p) > 0.05f) nov = 5;
            else if (Math.Abs(p) > 0.01f) nov = 1;
            else { nov = 0; am.SetFloat("efecsTon", emosi[i, 0] / 10 + 1); }
            float y = p / nov / 2; float u = p2-20;

            for (int o = 0; o < nov; o++)
            {
                u += y;
                am.SetFloat("efecsTon", u);
                yield return new WaitForSeconds(timer / nov);
            }
            am.SetFloat("efecsTon", emosi[i, 0] / 10 + 1);
        }
    }

    IEnumerator efecsVso(int i, float[,] emosi, float timer, GameObject ooo,float spid)
    {
        AudioSource AS = ooo.GetComponent<AudioSource>();
        if (i == 0)
        {
            AS.pitch = emosi[i, 1] / 10 + 1;
            AS.volume = emosi[i, 2];
        }
        else
        {
            float p1Pitch = emosi[i, 1] / 10 + 21;
            float p2Pitch = emosi[i - 1, 1] / 10 + 21;
            float pPitch = p1Pitch - p2Pitch;
            int novPitch;
            if (Math.Abs(pPitch) > 0.1f) novPitch = 10;
            else if (Math.Abs(pPitch) > 0.05f) novPitch = 5;
            else if (Math.Abs(pPitch) > 0.01f) novPitch = 1;
            else { novPitch = 0; AS.pitch = emosi[i, 1] / 10 + 1; }

            float p1Volume = emosi[i, 2]+20;
            float p2Volume = emosi[i - 1, 2]+20;
            float pVolume = p1Volume - p2Volume;
            int novVolume;
            if (Math.Abs(pVolume) > 1f) novVolume = 10;
            else if (Math.Abs(pVolume) > 0.5f) novVolume = 5;
            else if (Math.Abs(pVolume) > 0.1f) novVolume = 1;
            else { novVolume = 0; AS.volume = emosi[i, 2]; }

            int nov = (int)(novPitch+ novVolume)/2;

            float yPitch = pPitch / nov / 2; float uPitch = p2Pitch;
            float yVolume = pVolume / nov / 2; float uVolume = p2Volume;

            for (int o = 0; o < nov; o++)
            {
                uPitch += yPitch; uVolume += yVolume;
                AS.pitch = uPitch * spid;
                AS.volume = uVolume;
                yield return new WaitForSeconds(timer / nov);
            }

            AS.pitch = emosi[i, 1] / 10 + 1;
            AS.volume = emosi[i, 2];
        }
    }
}