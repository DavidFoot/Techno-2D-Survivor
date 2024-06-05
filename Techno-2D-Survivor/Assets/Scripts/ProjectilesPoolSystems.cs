using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectilesPoolSystems : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> m_projectiles;
    [SerializeField] int m_initPoolQuantity = 10;
    [SerializeField] GameObject m_projectilePrefab;
    private GameObject m_projectile;

    void Start()
    {
        for(int i = 0; i < m_initPoolQuantity; i++)
            m_projectile = CreateNewItem();
    }

    private GameObject CreateNewItem()
    {
        GameObject newProjectile = Instantiate(m_projectilePrefab, transform);
        newProjectile.name = m_projectilePrefab.name;
        newProjectile.SetActive(false);
        m_projectiles.Add(m_projectile);
        return newProjectile;
    }
    public GameObject GetFirstAvailableProjectile(Transform _origine)
    {
        for(int i = 0;i < m_projectiles.Count;i++)
        {
            if (m_projectiles[i].activeSelf == false) return m_projectiles[i];
        }
        return CreateNewItem();
    }
}
