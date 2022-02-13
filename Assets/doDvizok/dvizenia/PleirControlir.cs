using UnityEngine;

public class PleirControlir : MonoBehaviour
{
    private Rigidbody rb;
    [Header("двизения")]
    public GameObject cam0;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject pleir;
    public GameObject FpsConsol;
    public float spid;
    public float spidTurbo;
    public float jamp;
    public float XZam = 1.1f;
    public float ZZam = 1.1f;
    private float xMov;
    private float zMov;

    [Header("поварот")]
    public float novorotXMin = 90;
    public float novorotXMax = -90;
    public float novorotYMin = 90;
    public float novorotYMax = -90;
    public float sensitiX = 1;
    public float sensitiY = 1;
    private float novorotCamX;
    private float novorotCamY;

    [Header("обнарузения")]
    //public string tegGraund;
    public Transform pos;
    public float disyon;
    public float disyonMin;
    public LayerMask whatISzeml;

    [Header("камера(0 - от первого лиса)")]
    public float rosto;
    public float rostoUnloc;

    [Header("уcловия блокиратори")]
    public bool blocMausO = true;
    public bool blocRotetinO;
    public bool blocTurboO;
    public bool blocPeredvizenO;
    public bool blocZamedleniaO;
    public bool blocGraundO;

    public static bool blocMaus = true;
    public static bool blocRotetin;
    public static bool blocTurbo;
    public static bool blocPeredvizen;
    public static bool blocGraund;
    public static bool graund;
    public static bool blocZamedlenia;
    public static bool tormaz;



    static public PleirControlir instance;

    

    void Awake()
    {
        instance = this;
        blocMaus = blocMausO;
        blocRotetin = blocRotetinO;
        blocTurbo = blocTurboO;
        blocPeredvizen = blocPeredvizenO;
        blocGraund = blocGraundO;
        blocZamedlenia = blocZamedleniaO;
        if (blocGraund) graund = true;
    }


    private void Start()
    {
        if (blocMaus) Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        cam2.transform.localPosition = new Vector3(0, 0, -rosto);
        cam1.transform.localRotation = Quaternion.Euler(new Vector3(cam1.transform.localRotation.x, 0, 0));
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && graund)
        {
            rb.AddForce(transform.up * jamp * 10);
            graund = false;
        }

        if (Input.GetKeyDown(KeyCode.F))// ето проверка работаспособнасти smesenia()
            smesenia(UnityEngine.Random.Range(0,10));

        if (Input.GetKeyDown(KeyCode.F1) && FpsConsol != null)
            FpsConsol.SetActive(!FpsConsol.activeInHierarchy);

        if (Input.GetKeyDown(KeyCode.F2))
            cam1.transform.localRotation = Quaternion.Euler(new Vector3(cam1.transform.localRotation.x, 0, 0));

        if (Input.GetKeyDown(KeyCode.Z))
            transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
        
        if (Input.GetKeyDown(KeyCode.X))
            transform.position = new Vector3(0, 1, 0);

        if (!blocRotetin)
        {
            float yRot = Input.GetAxisRaw("Mouse X");
            float xRot = Input.GetAxisRaw("Mouse Y");

            if (yRot != 0 || xRot != 0) 
            {

                if (novorotYMin != 0 || novorotYMax != 0)
                {
                    if (novorotCamY == 0) cam1.transform.rotation = Quaternion.Euler(Vector3.zero);
                    if ((novorotCamY + yRot * sensitiX > novorotYMin) || (novorotCamY + yRot * sensitiX < novorotYMax)) yRot = 0;
                }

                novorotCamY += yRot * sensitiX;
                if((-cam2.transform.localPosition.z < rostoUnloc))
                    transform.Rotate(new Vector3(0, yRot * sensitiY, 0));
                else
                    cam0.transform.Rotate(new Vector3(0, yRot * sensitiY, 0));


                if (cam1 != null)
                {
                    if (novorotXMin != 0 || novorotXMax != 0)
                    {
                        if (novorotCamX == 0) { cam1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); novorotCamX = 0; }
                        if ((novorotCamX + xRot * sensitiX > novorotXMin) || (novorotCamX + xRot * sensitiX < novorotXMax)) xRot = 0;
                    }

                    novorotCamX += xRot * sensitiX;
                    cam1.transform.Rotate(-new Vector3(xRot * sensitiX, 0, 0));
                } 
            }
        }
    }

    private void FixedUpdate()
    {
        if (pos != null && disyon != 0)
        {
            if (!blocGraund) graund = Physics.Raycast(pos.position, Vector3.down, disyon, whatISzeml);
            if (!blocTurbo) tormaz = Physics.Raycast(pos.position, Vector3.down, disyonMin, whatISzeml);
        }


        if (!blocPeredvizen)
        {
            if (graund) 
            {
                xMov = Input.GetAxisRaw("Horizontal");
                zMov = Input.GetAxisRaw("Vertical");
            }
            else if(blocZamedlenia)
            {
                xMov *= XZam;
                zMov *= ZZam;
            }

            if (xMov != 0 || zMov != 0)
            {
                Vector3 movHov = transform.right * xMov;
                Vector3 movVer = transform.forward * zMov;

                Vector3 velositi = (movHov + movVer).normalized * (spid + ((!tormaz && !blocTurbo && (Input.GetKey(KeyCode.LeftShift)))? 0: spidTurbo));
                if (velositi != Vector3.zero)
                {
                    transform.rotation *= cam0.transform.localRotation;
                    novorotCamY = 0.1f;
                    pleir.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    cam0.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    rb.MovePosition(rb.position + velositi * Time.fixedDeltaTime);
                }
            }
        }

        if (rostoUnloc != 0 && pleir.activeSelf != !(-cam2.transform.localPosition.z < rostoUnloc))
        {
            pleir.SetActive(!(-cam2.transform.localPosition.z < rostoUnloc));
            transform.rotation *= cam0.transform.localRotation;
            novorotCamY = 0.1f;
            pleir.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    public static void smesenia(float rostoL)
    {dvizeniaCasen.dvizeniaPers(instance.cam2, new Vector3(0, 0, -rostoL), 0.5f, 0, true);}
}
