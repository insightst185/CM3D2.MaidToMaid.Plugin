using System;
using UnityEngine;
using UnityInjector;
using UnityInjector.Attributes;

namespace CM3D2.MaidToMaid.Plugin
{
    [PluginFilter("CM3D2x64"),
    PluginFilter("CM3D2x86"),
    PluginFilter("CM3D2VRx64"),
    PluginName("MaidToMaid"),
    PluginVersion("0.0.0.1")]
    public class MaidToMaid : PluginBase
    {
        private enum TargetLevel
        {
            Scene_hoge = 27
        }

        private bool maidToMaid = false;

        private void Awake()
        {
        }

        private void OnLevelWasLoaded(int level)
        {
            maidToMaid = false;
        }

        private void Update()
        {
            if (!Enum.IsDefined(typeof(TargetLevel), Application.loadedLevel))
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                maidToMaid = !maidToMaid;
            }

            if (maidToMaid){
                 Maid maid0 = GameMain.Instance.CharacterMgr.GetMaid(0);
                 Maid maid1 = GameMain.Instance.CharacterMgr.GetMaid(1);
                 if(maid0 != null && maid1 != null){
                     maid0.EyeToTarget(maid1, 3.0f, "Bip01 Head");
                     maid1.EyeToTarget(maid0, 3.0f, "Bip01 Head");
                 }
            }
        }
    }
}


