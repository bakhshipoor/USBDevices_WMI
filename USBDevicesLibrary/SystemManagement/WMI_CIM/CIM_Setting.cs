using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDevicesLibrary;

public class CIM_Setting : CIM_BaseClass
{
    public CIM_Setting()
    {
        
    }

    public CIM_Setting(CIM_Setting cim_Setting) : this()
    {
        RetrieveValues(cim_Setting);
    }

    public CIM_Setting(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public string? Caption {  get; set; }
    public string? Description { get; set; }
    public string? SettingID { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_Setting cim_Setting = (CIM_Setting)managementClass;
        Caption = cim_Setting.Caption; 
        Description = cim_Setting.Description;
        SettingID = cim_Setting.SettingID;
    }

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);
        PropertyData[] propertyDatas = new PropertyData[managementObject.Properties.Count];
        managementObject.Properties.CopyTo(propertyDatas, 0);
        Parallel.ForEach(propertyDatas, property =>
        {
            if (property != null && property.Value != null)
            {
                switch (property.Name)
                {
                    case nameof(Caption):
                        Caption = (string)property.Value;
                        break;
                    case nameof(Description):
                        Description = (string)property.Value;
                        break;
                    case nameof(SettingID):
                        SettingID = (string)property.Value;
                        break;
                }
            }
        });
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(Caption), Value = Caption },
            new PnPEntityToList { Name = nameof(Description), Value = Description },
            new PnPEntityToList { Name = nameof(SettingID), Value = SettingID },
        ];
        return filedsToList;
    }
}
