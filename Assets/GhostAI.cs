using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MoveTo : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject player;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] ScareManager scareManager;

    float distanceToTarget = Mathf.Infinity;

    NavMeshAgent agent;

    public float stationaryTimeThreshold = 5f; // Adjust this threshold as needed
    private Vector3 lastPosition;
    private float timeStationary;

    private bool screamed = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        agent.destination = player.transform.position;
        distanceToTarget = Vector3.Distance(player.transform.position, transform.position);

        //Debug.Log(distanceToTarget);
        if (!screamed && distanceToTarget <= chaseRange)
        {
            screamed = true;
            scareManager.timeSelected = false;
            m_AudioSource.PlayOneShot(audioClip);
            Debug.Log("Scream Player");
            Invoke("NavDisable", 0.5f);
        }

        if (transform.position != lastPosition)
        {
            timeStationary = 0f;
            lastPosition = transform.position;
        }
        else
        {
            
            timeStationary += Time.deltaTime;
            if (timeStationary >= stationaryTimeThreshold)
            {
                Debug.Log(gameObject.name + " has been stationary for a long time.");
                scareManager.timeSelected = false;
                this.gameObject.SetActive(false);
                timeStationary = 0f;
            }
        }

    }

    void NavDisable()
    {
        screamed = false;
        this.gameObject.SetActive(false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Triggered");
    //        scareManager.timeSelected = false;
    //        m_AudioSource.PlayOneShot(audioClip);
    //        this.gameObject.SetActive(false);
            
    //    }
    //}
}