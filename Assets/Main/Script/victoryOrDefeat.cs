
using UnityEngine;

public class victoryOrDefeat : MonoBehaviour
{
  void Update()
  {
    if(rebornManager.Count == 0
      &&hpManager.hp1 == 0.0f)
    {
      // 復帰回数0でHPも0だったら
    }
    if (rebornManager.Count2 == 0
      && hpManager.hp2 == 0.0f)
    {
      // 復帰回数0でHPも0だったら
    }
  }
}
