using UnityEngine;
using BIS.Managers;
namespace BIS.UI
{
    public class PopupUI : UIBase
    {
        public override bool Init()
        {
            if (base.Init() == false)
                return false;


            Managers.Manager.UI.SetCanvas(gameObject, false);
            return true;
        }
    }
}
