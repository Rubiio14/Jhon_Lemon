using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
	public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    float m_Timer = 0f;
    public AudioSource m_Tindeck;
    [SerializeField]
    public GameObject m_Exclamation;

    void Start()
    {
        m_Exclamation.SetActive(false);
    }
    void OnTriggerEnter (Collider other)
    {
		if(other.transform == player)
        {
            m_Tindeck.Play();
            m_IsPlayerInRange = true;
        }
    }
    void OnTriggerExit (Collider other)
    {
        if(other.transform == player)
        {
            m_Exclamation.SetActive(false);
            m_Timer = 0f;
            m_IsPlayerInRange = false;
        }
    }

    void Update ()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit))
            {
                
                
                if (raycastHit.collider.transform == player)
                {
                    m_Timer += Time.deltaTime;
                    m_Exclamation.SetActive(true);

                    if (m_Timer >= 2)
                    {
                        gameEnding.CaughtPlayer();
                    }
                    
                }
            }
        }
    }

}
