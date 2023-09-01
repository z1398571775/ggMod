using MelonLoader;
using System;
using System.Windows;
using System.Reflection;
using UnityEngine;
using MOD_aeYCNy.form;
using static DataUnit;

/// <summary>
/// 当你手动修改了此命名空间，需要去模组编辑器修改对应的新命名空间，程序集也需要修改命名空间，否则DLL将加载失败！！！
/// </summary>
namespace MOD_aeYCNy
{
    /// <summary>
    /// 此类是模组的主类
    /// </summary>
    public class ModMain
    {
        private TimerCoroutine corUpdate;
		private static HarmonyLib.Harmony harmony;
        private Form1 userControl1 = null;

        /// <summary>
        /// MOD初始化，进入游戏时会调用此函数
        /// </summary>
        public void Init()
        {
			//使用了Harmony补丁功能的，需要手动启用补丁。
			//启动当前程序集的所有补丁
			if (harmony != null)
			{
				harmony.UnpatchSelf();
				harmony = null;
			}
			if (harmony == null)
			{
				harmony = new HarmonyLib.Harmony("MOD_aeYCNy");
			}
			harmony.PatchAll(Assembly.GetExecutingAssembly());

            corUpdate = g.timer.Frame(new Action(OnUpdate), 1, true);
        }

        /// <summary>
        /// MOD销毁，回到主界面，会调用此函数并重新初始化MOD
        /// </summary>
        public void Destroy()
        {
            g.timer.Stop(corUpdate);
        }

        /// <summary>
        /// 每帧调用的函数
        /// </summary>
        private void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T)) {

                if (userControl1 == null) 
                {
                    userControl1 = new Form1();
                    userControl1.Text = "首页";
                }
                
                userControl1.Show();
                


                //人物信息
                //Il2CppSystem.Collections.Generic.Dictionary<string, DataUnit.UnitInfoData> unitDict = g.data.unit.allUnit;
                
                //foreach (Il2CppSystem.Collections.Generic.KeyValuePair<String, DataUnit.UnitInfoData> item in unitDict)
                //{
                //        // item.Key 值为当前键
                //        // item.Value 值为键对应的值
                //        //MelonLogger.Msg("，字典--key：" + item.Key);
                //        //MelonLogger.Msg("，字典--value：" + item.value);
                //        DataUnit.UnitInfoData unitInfoData = item.Value;
                //    //unitInfoData.propertyData.GetName();
                //    MelonLogger.Msg("结果为:       " + unitInfoData.propertyData.GetName());
                   
                //}



               



                //物品类型字典
                //Il2CppSystem.Collections.Generic.List<ConfItemTypeItem> itemTypeItems = g.conf.itemType._allConfList;
                //foreach (ConfItemTypeItem item in itemTypeItems)
                //{
                //    MelonLogger.Msg("唯一标识 " + " ========== " + item.id);
                //    MelonLogger.Msg("类型名称  " + " ========== " + GameTool.LS(item.name));
                //    MelonLogger.Msg("排序  " + " ========== " + item.sort);
                //    MelonLogger.Msg("所属大类   " + " ========== " + item.type);
                //    MelonLogger.Msg("UI显示分类   " + " ========== " + item.uiLabel);
                //}


                //物品品质字典
                //Il2CppSystem.Collections.Generic.List<ConfItemLevelDescItem> itemLevelDescItems  = g.conf.itemLevelDesc._allConfList;
                //foreach (ConfItemLevelDescItem item in itemLevelDescItems)
                //{
                //    MelonLogger.Msg("唯一标识 " + " ========== " + item.id);
                //    MelonLogger.Msg("品质描述 " + " ========== " + item.desc);
                //}

                //物品
                
                //Il2CppSystem.Collections.Generic.List<ConfItemPropsItem> itemList = g.conf.itemProps._allConfList;
                //foreach (ConfItemPropsItem item in itemList)
                //{
                //    MelonLogger.Msg("是否可拍卖 " + " ========== "+item.auction);
                //    MelonLogger.Msg("物品分类  " + " ========== " + item.className);
                //    MelonLogger.Msg("物品说明  " + " ========== " + item.desc);
                //    MelonLogger.Msg("死亡掉落   " + " ========== " + item.dieDrop);
                //    MelonLogger.Msg("是否允许丢弃    " + " ========== " + item.drop);
                //    MelonLogger.Msg("是否隐藏     " + " ========== " + item.hide);
                //    MelonLogger.Msg("物品图标      " + " ========== " + item.icon);
                //    MelonLogger.Msg("可否翻倍产出       " + " ========== " + item.isMultiDrop);
                //    MelonLogger.Msg("是否叠加        " + " ========== " + item.isOverlay);
                //    MelonLogger.Msg("物品品质         " + " ========== " + item.level);
                //    MelonLogger.Msg("物品名称          " + " ========== " + item.name);
                //    MelonLogger.Msg("NPC背包是否强制显示           " + " ========== " + item.npcShow);
                //    MelonLogger.Msg("玩家背包是否强制显示            " + " ========== " + item.playerShow);
                //    MelonLogger.Msg("出售价格             " + " ========== " + item.sale);
                //    MelonLogger.Msg("物品类型              " + " ========== " + item.type);
                //    MelonLogger.Msg("道具价值               " + " ========== " + item.worth);
                //    MelonLogger.Msg("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                //}


                

            }
        }
    }
}
