using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDevicesLibrary;

public class CIM_ManagedSystemElement : CIM_BaseClass
{
    public CIM_ManagedSystemElement()
    {
        
    }

    public CIM_ManagedSystemElement(CIM_ManagedSystemElement cim_ManagedSystemElement)
    {
        RetrieveValues(cim_ManagedSystemElement);
    }

    public CIM_ManagedSystemElement(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public string? Caption { get; set; }
    public string? Description { get; set; }
    public DateTime? InstallDate { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);

        PropertyData[] propertyDatas = new PropertyData[managementObject.Properties.Count];
        managementObject.Properties.CopyTo(propertyDatas, 0);
        Parallel.ForEach(propertyDatas, property =>
        {
            if (property!=null && property.Value != null)
            {
                switch (property.Name)
                {
                    case nameof(Caption):
                        Caption = (string)property.Value;
                        break;
                    case nameof(Description):
                        Description = (string)property.Value;
                        break;
                    case nameof(InstallDate):
                        InstallDate = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                    case nameof(Name):
                        Name = (string)property.Value;
                        break;
                    case nameof(Status):
                        Status = (string)property.Value;
                        break;
                }
            }
        });
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_ManagedSystemElement cim_ManagedSystemElement = (CIM_ManagedSystemElement)managementClass;
        Caption = cim_ManagedSystemElement.Caption;
        Description = cim_ManagedSystemElement.Description;
        InstallDate = cim_ManagedSystemElement.InstallDate;
        Name = cim_ManagedSystemElement.Name;
        Status = cim_ManagedSystemElement.Status;
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(Caption), Value = Caption },
            new PnPEntityToList { Name = nameof(Description), Value = Description },
            new PnPEntityToList { Name = nameof(InstallDate), Value = InstallDate.ToString() },
            new PnPEntityToList { Name = nameof(Name), Value = Name },
            new PnPEntityToList { Name = nameof(Status), Value = Status },
        ];
        return filedsToList;
    }
}
