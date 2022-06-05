using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private List<Parallax> _allBg = new List<Parallax>();

    public void AddParallax(Parallax parallax)
    {
        _allBg.Add(parallax);
    }
    void Update()
    {
        for (int i = 0; i < _allBg.Count; i++)
        {
            _allBg[i].ParallaxMove();
        }
    }
}
