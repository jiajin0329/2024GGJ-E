using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private GameObject dieObj;
    [SerializeField] private GameObject rushDownObj;
    [SerializeField] private GameObject boomObj;

    [ContextMenu("PlayeDie")]
    public void PlayDieParticle()
    {
        dieObj.SetActive(true);
    }
    public void PlayBoomParticle(Transform target)
    {
        boomObj.SetActive(true);
        boomObj.transform.position = target.position;
        boomObj.transform.position += new Vector3(-2 * target.localScale.x, 1.5f, -0.5f);
        boomObj.GetComponent<ParticleSystem>().Play();
    }
    public void PlaysRushDownParticle(Transform target)
    {
        rushDownObj.SetActive(true);
        rushDownObj.transform.position = target.position +
         new Vector3(0, 0, -0.2f);

        rushDownObj.GetComponent<ParticleSystem>().Play();
    }
    public void CancelRushDownParticle()
    {
        rushDownObj.GetComponent<ParticleSystem>().Stop();
        //throw to somewhere cant
        rushDownObj.transform.position = Vector3.one * 100000;
    }

}
