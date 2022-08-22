using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavMesh : MonoBehaviour
{
    [Header("NavMesh")]
    public NavMeshAgent agent;
    public float actualVelocity;
    public Animator agentAnim;

    [Header("NavMesh Movement")]    
    public Transform currentTarget;
    bool _rotate = false;
    bool _moving = true;

    [Header("Face Animation")]
    public SkinnedMeshRenderer face;

    [Header("Blink Control")]
    [Range(0, 10)]
    public float value;
    [Range(0f, 100f)]
    public float eyesValue;

    [Header("Lipsync")]
    bool _talk;
    [Tooltip("Asignar el audiosource que controla las locuciones")]
    public AudioSource audioInput;
    [Range(0f, 100f)]
    public float mountValue;
    [Range(0.0f, 10.0f)]
    public float gain = 1f;
    [Range(0.0f, 1.0f)]
    public float smoothing;

    float[] samples;
    float lastRMS;
    float velocityBuffer;

    // Start is called before the first frame update
    void Start()
    {
        samples = new float[256];
        agent = GetComponent<NavMeshAgent>();    
        StartCoroutine(Blink(5));        
    }

    private void Update()
    {
        actualVelocity = agent.velocity.magnitude / agent.speed;
        agentAnim.SetFloat("velocity", actualVelocity);
        agentAnim.SetBool("rotate", _rotate);
        agentAnim.SetBool("talk", _talk);

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            //manager reproduce audio
            //audioInput.Play();
            //iniciar en la tarea el LipSync
            //UseLipsync();

            //en tarea se piede mover a X posicion
            MoveTo(currentTarget);
        }*/
    }
    /// <summary>
    /// Metodo que llama a la corrutina de MoveToPoints,
    /// </summary>
    /// <param name="target">Transform que sera la posicion final, ademas de dar la rotacion final del agente</param>
    public void MoveTo(Transform target)
    {
        StartCoroutine(MoveToPoints(target));
    }

    public void UseLipsync()
    {
        StartCoroutine(SoundLipsync());
    }
    IEnumerator MoveToPoints(Transform target)
    {
        //movement        
        yield return new WaitForSeconds(0.1f);        
        agent.SetDestination(target.position);
        yield return new WaitForSeconds(0.1f);
        while (agent.velocity.magnitude!=0)
        {            
            _moving = true;            
            yield return new WaitForFixedUpdate();
        }
        _moving = false;
        //rotation
        
        while (transform.eulerAngles.y != target.eulerAngles.y)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, Time.deltaTime * 200f);
            _rotate = true;
            yield return new WaitForFixedUpdate();            
        }
        _rotate = false;       
    }

    
    
    /// <summary>
    /// Animacion por codigo para el parpadeo
    /// </summary>
    /// <param name="delay">Tiempo de espera para siguiente parpadeo debe ser mayor a 1</param>
    /// <returns></returns>
    IEnumerator Blink(int delay)
    {
        float delayR = Random.Range(1, delay);
        
        //parpadeo
        for(int i=0; i <= 10; i++)
        {
            float radangle = 18f * i * Mathf.Deg2Rad;
            eyesValue = 100f * Mathf.Sin(radangle);
            eyesValue = Mathf.Clamp(eyesValue, 0f, 100f);
            face.SetBlendShapeWeight(0, eyesValue);
            yield return new WaitForFixedUpdate();          
        }   
        
        yield return new WaitForSeconds(delayR);
        StartCoroutine(Blink(delay));
    }

    IEnumerator SoundLipsync()
    {
        while (audioInput.isPlaying)
        {
            _talk = true;
            var total = 0f;
            audioInput.GetOutputData(samples, 0);

            for (var i = 0; i < samples.Length; i++)
            {
                var sample = samples[i];

                total += (sample * sample);
            }

            var rms = Mathf.Sqrt(total / samples.Length) * gain;

            rms = Mathf.Clamp(rms, 0, 1f);

            rms = Mathf.SmoothDamp(lastRMS, rms, ref velocityBuffer, smoothing * 0.1f);

            mountValue = 100 * rms;
            face.SetBlendShapeWeight(1, mountValue);


            yield return new WaitForFixedUpdate();
        }
        _talk = false;
    }
}
