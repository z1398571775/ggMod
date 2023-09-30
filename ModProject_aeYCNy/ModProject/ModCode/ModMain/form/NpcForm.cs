using MelonLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOD_aeYCNy.form
{
    public partial class NpcForm : Form
    {

        //气运集合
        Il2CppSystem.Collections.Generic.Dictionary<String,DataUnit.UnitInfoData> allUnitList = null;

        //列表数据
        DataTable dataTable = null;

        public NpcForm()
        {
            InitializeComponent();
            try {
                allUnitList = g.data.unit.allUnit;
                dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(int));
                dataTable.Columns.Add("name", typeof(string));
                
                foreach (Il2CppSystem.Collections.Generic.KeyValuePair<String, DataUnit.UnitInfoData> unitDic in allUnitList)
                {
                    DataUnit.UnitInfoData unitDate = unitDic.value;

                }
            } catch(Exception e) {
                MelonLogger.Msg("初始化失败:" + e.Message);
            }
        }
    }
}
