using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject smallExplosionPrefab;
    [SerializeField] GameObject shootButton;
    [SerializeField] TMPro.TextMeshProUGUI text;
    GameObject startPosition;
    GameObject explosion;
    MeshRenderer meshRenderer;
    [SerializeField] float speed;
    bool isActive = false;
    int planetsLeft = 8;

    void Start()
    {
        startPosition = new GameObject();
        startPosition.transform.position = new Vector3(0, 0, 0);
        text.SetText("Planets left: " + planetsLeft);
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    void Update()
    {
        if(isActive)
        {
            transform.position = transform.position + thingToFollow.transform.forward * speed * Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if(!isActive)
        {
            startPosition.transform.position = thingToFollow.transform.position;
            transform.position = startPosition.transform.position;
            isActive = true;
            shootButton.SetActive(false);
            meshRenderer.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        meshRenderer.enabled = false;
        planetsLeft--;
        shootButton.SetActive(true);
        text.SetText("Planets left: " + planetsLeft);
        isActive = false;
        transform.position = new Vector3(0, 3, 0);
        explosion = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject, 0.05f);
        Destroy(explosion.gameObject, 1.5f);
        if(planetsLeft <= 0)
        {
            Win();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        meshRenderer.enabled = false;
        isActive = false;
        transform.position = new Vector3(0, 3, 0);
        if(other.tag == "Sun")
        {
             explosion = Instantiate(smallExplosionPrefab, other.transform.position, Quaternion.identity);
             Destroy(explosion.gameObject, 1.5f);
        }
        shootButton.SetActive(true);
    }

    public void Win() 
    {
        text.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        text.SetText("Victory!");
    }
}
