using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstPersonControllerWithSound : MonoBehaviour
{


    [Header("Settings")]

    [SerializeField] Transform Camera;//Guardo en una variable mi camara

    [Header("Player Settings")]
    //Guardo en variables datos que me ayudaran para mover mi personaje
    [SerializeField] float WalkSpeed = 2;
    [SerializeField] float BackwardsSpeed = 1;
    [SerializeField] float RunSpeed = 4;

    [SerializeField] float JumpForce = 20f;

    [SerializeField] float Gravity = 9.8f;
    
    private float MoveSpeed;

    CharacterController PlayerCharacter;//Guardo en una variable el CharacterController de mi personaje

    Vector3 Movement;//Diereccion a la que me moveré

    [Header("Audio Clips")]

    [SerializeField] private AudioClip[] walkSounds;//Lista de sonidos de pasos
    [SerializeField] private AudioClip JumpSound;//Sonido de salto (podria ser una lista pero hay que hacer mas complejo el codigo)
    [SerializeField] private AudioClip LandingSound;//Sonido de aterrizaje

    [Header("Sound Setings")]

    [Range(0, 1)] [SerializeField] private float StepTimeOffset = 0; //Tiempo que tiene que transcurrir para ejecutar el siguiente paso
    [Range(0, 1)] [SerializeField] private float AirTimeNedded=3; //Tiempo que tiene uqe trascurrir en el aire para reproducir el sonido de aterrizaje

    //Variable no visibles en el inspector
    private float StepTime = 0; //Me ayuda a saber cuanto tiempo transcurrio desde el ultimo paso

    private float AirTime=0; //Me ayuda a saber cuanto tiempo llevo en el aire

    private AudioSource Audio; //Variable que hace referencia al AudioSource de mi personaje, me ayuda a reproducir audios



    private bool Jumping;

    private void Awake()
    {
        PlayerCharacter = GetComponent<CharacterController>();

        Audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
        MoveSpeed = WalkSpeed;

        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 CameraDir = Camera.forward; //Guardo en una variable la direccion a la que apunta mi camara

        Vector3 MoveDirection = new Vector3(CameraDir.x,0,CameraDir.z); //Segun esa direcciondetermino hacia donde se tendria que mover mi personaje

        transform.rotation = Quaternion.LookRotation(MoveDirection); //Roto mi personaje en esa direccion

        if (PlayerCharacter.isGrounded)//Si estoy tocando el suelo
        {

            if (Input.GetKey(KeyCode.LeftShift))//Si aprieto el shift
            {
                MoveSpeed = RunSpeed;//Mi velocidad es la de correr
            }
            else
            {
                MoveSpeed = WalkSpeed; //Sino mi velocidad es la de caminar

            }

            //Determino que teclas estoy apretando segun los ejes Horizontales y verticales
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical")!=0)
            {
                StepTime += Time.deltaTime;//Empiezo a contar el tiempo que llevo caminando

                if (Audio.isPlaying == false && StepTime > StepTimeOffset)//Si no estoy reproduciuoendo otro audio y el tiempo que llevo caminando supera el de la configuracion
                {

                    Audio.clip = walkSounds[Random.Range(0, walkSounds.Length)];//Elijo un audio de pasos al azar para ejecutar

                    Audio.PlayOneShot(Audio.clip);//Reproduzco el audio

                    StepTime = 0;//Reseteo el tiempo que llevo si nhacer un paso

                }

            }
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            if (Vertical < 0)
            {
                MoveSpeed = BackwardsSpeed;
            }

            

            Movement = transform.TransformDirection(new Vector3(Horizontal, 0, Vertical)*MoveSpeed); 

            if (Input.GetKeyDown(KeyCode.Space))// Si aprieto el espacio
            {
                
                Movement.y = JumpForce;// Salto

                StepTime = 0;//Seteo en 0 el tiempo que llevo sin hacer un paso
                Audio.pitch = 1;//La velocidad de reproduccion es 1 (normal)
                Audio.Stop();//Paro todos los audios
                Audio.clip = JumpSound;//Elijo el clip de audio de salto
                Audio.Play();//Lo reproduzco
            }
        }
        else //Si estoy en el aire
        {
            StartCoroutine(Landing());//Reproduzco esta tarea (Mirar abajo del todo)
        }
        Movement.y -= Gravity/5;

        PlayerCharacter.Move(Movement*Time.deltaTime);

    }

    IEnumerator Landing() //Tarea de aterrizaje
    {
        AirTime += Time.deltaTime;//Cuento cuanto tiempo llevo en el aire

        yield return new WaitUntil(() => PlayerCharacter.isGrounded);//Espeo hasta que toque el piso

        if (AirTime > AirTimeNedded)//Si pase mucho tiempo en el aire
        {

            Audio.clip = LandingSound;//Elijo el sonido de caida

            Audio.PlayOneShot(Audio.clip);//Reproduzco el sonido
        }

        AirTime = 0;//Air time vuelve a 0 (Porque ya toque el piso)

    }


}
