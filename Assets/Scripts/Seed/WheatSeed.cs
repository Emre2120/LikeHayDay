using UnityEngine;

public class WheatSeed : Seed
{
   public int seedYield = 1; 
    public override void Collect()
    {
        EventManager.CollectWheatRipe(seedYield); // burada tohum verimi değeri belirlenip hasat edilince daha fazla ürün alma durumu oluşablir
    }
}
