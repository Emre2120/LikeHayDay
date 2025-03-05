using System.Collections;
using UnityEngine;

public class CornSeed : Seed
{
    public int seedYield = 1; 
    public override void Collect()
    {
        EventManager.CollectCornRipe(seedYield); // burada tohum verimi değeri belirlenip hasat edilince daha fazla ürün alma durumu oluşablir
    }
}