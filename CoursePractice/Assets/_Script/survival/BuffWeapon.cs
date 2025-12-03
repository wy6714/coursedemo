using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;

public class BuffWeapon : MonoBehaviour
{
    public GameObject buffWeaponPrefab;
    public float spawnInterval = 5f;
    public float weaponDuration = 1f;
    public float spawnDistance = 1f;

    private Vector2 lookDirection = Vector2.down;
    public GameObject BuffButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (input.sqrMagnitude > 0.01f)
        {
            lookDirection = input.normalized;
        }
    }

    void SpawnWeapon()
    {
        Vector3 spawnPos = transform.position + (Vector3)(lookDirection * spawnDistance);
        GameObject weapon = Instantiate(buffWeaponPrefab, spawnPos, Quaternion.identity);

        //weapon.transform.SetParent(transform);

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        SpriteRenderer sr = weapon.GetComponent<SpriteRenderer>();
        sr.flipX = true;

        Destroy(weapon, weaponDuration);
    }

    public void buffButton()
    {
        InvokeRepeating(nameof(SpawnWeapon), spawnInterval, spawnInterval);
        BuffButton.SetActive(false);
    }
}
