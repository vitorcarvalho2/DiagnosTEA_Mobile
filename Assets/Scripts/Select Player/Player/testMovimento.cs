
using UnityEngine;

public class testMovimento : MonoBehaviour//, IDataPersistence
{
    private Joystick joystick;
    public Vector3 direcao;
    public Vector3 cameraOffSet;
    public Animator animator;
    public Camera mainCamera;
    public Rigidbody rb;

    private float velocidade = 2;
    float inputX, inputZ, joystickX, joystickZ;

    public bool readyToSpeak;
    public bool startDialogue;

    void Start()
    {
        // Get components
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        GameObject.Find("Main Camera").SendMessage("setPlayer", null, SendMessageOptions.DontRequireReceiver);
    }

    void Update()
    {

        // Usar inputs do teclado ou joystick (se houver)
        Vector3 inputDirecao = new Vector3(inputX + joystickX, 0, inputZ + joystickZ).normalized;

        // Apenas se houver uma direção válida (para evitar look rotation com vetor zero)
        if (inputDirecao.magnitude >= 0.1f)
        {
            // Calcular direção do movimento
            direcao = inputDirecao;

            // Movimentação
            transform.Translate(velocidade * Time.deltaTime * direcao, Space.World);
            animator.SetBool("walk", true);

            // Rotacionar para a direção do movimento
            Quaternion targetRotation = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
        else
        {
            // Parar animação de caminhada se não houver input
            animator.SetBool("walk", false);
        }
    }

    private void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        if (joystick != null)
        {
            joystickX = joystick.Horizontal;
            joystickZ = joystick.Vertical;
        }
        direcao = new Vector3(inputX, 0, inputZ);

    }

    /* public void LoadData(GameData data){
         this.transform.position = data.playerPosition;
     }

     public void SaveData(ref GameData data){
        data.playerPosition = this.transform.position;
     }
 */
}


