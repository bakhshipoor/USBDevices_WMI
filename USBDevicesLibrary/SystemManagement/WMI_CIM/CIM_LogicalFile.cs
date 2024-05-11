using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_LogicalFile : CIM_LogicalElement
{
    public CIM_LogicalFile()
    {
        
    }

    public CIM_LogicalFile(CIM_LogicalFile cim_LogicalFile)
    {
        RetrieveValues(cim_LogicalFile);
    }

    public CIM_LogicalFile(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public UInt32? AccessMask { get; set; }
    public bool? Archive { get; set; }
    public bool? Compressed { get; set; }
    public string? CompressionMethod { get; set; }
    public string? CreationClassName { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? CSCreationClassName { get; set; }
    public string? CSName { get; set; }
    public string? Drive { get; set; }
    public string? EightDotThreeFileName { get; set; }
    public bool? Encrypted { get; set; }
    public string? EncryptionMethod { get; set; }
    public string? Extension { get; set; }
    public string? FileName { get; set; }
    public UInt64? FileSize { get; set; }
    public string? FileType { get; set; }
    public string? FSCreationClassName { get; set; }
    public string? FSName { get; set; }
    public bool? Hidden { get; set; }
    public UInt64? InUseCount { get; set; }
    public DateTime? LastAccessed { get; set; }
    public DateTime? LastModified { get; set; }
    public string? Path { get; set; }
    public bool? Readable { get; set; }
    public bool? System { get; set; }
    public bool? Writeable { get; set; }

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
                    case nameof(InstallDate):
                        InstallDate = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                    case nameof(Status):
                        Status = (string)property.Value;
                        break;
                    case nameof(AccessMask):
                        AccessMask = (UInt32)property.Value;
                        break;
                    case nameof(Archive):
                        Archive = (bool)property.Value;
                        break;
                    case nameof(Compressed):
                        Compressed = (bool)property.Value;
                        break;
                    case nameof(CompressionMethod):
                        CompressionMethod = (string)property.Value;
                        break;
                    case nameof(CreationClassName):
                        CreationClassName = (string)property.Value;
                        break;
                    case nameof(CreationDate):
                        CreationDate = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                    case nameof(CSCreationClassName):
                        CSCreationClassName = (string)property.Value;
                        break;
                    case nameof(CSName):
                        CSName = (string)property.Value;
                        break;
                    case nameof(Drive):
                        Drive = (string)property.Value;
                        break;
                    case nameof(EightDotThreeFileName):
                        EightDotThreeFileName = (string)property.Value;
                        break;
                    case nameof(Encrypted):
                        Encrypted = (bool)property.Value;
                        break;
                    case nameof(EncryptionMethod):
                        EncryptionMethod = (string)property.Value;
                        break;
                    case nameof(Name):
                        Name = (string)property.Value;
                        break;
                    case nameof(Extension):
                        Extension = (string)property.Value;
                        break;
                    case nameof(FileName):
                        FileName = (string)property.Value;
                        break;
                    case nameof(FileSize):
                        FileSize = (UInt64)property.Value;
                        break;
                    case nameof(FileType):
                        FileType = (string)property.Value;
                        break;
                    case nameof(FSCreationClassName):
                        FSCreationClassName = (string)property.Value;
                        break;
                    case nameof(FSName):
                        FSName = (string)property.Value;
                        break;
                    case nameof(Hidden):
                        Hidden = (bool)property.Value;
                        break;
                    case nameof(InUseCount):
                        InUseCount = (UInt64)property.Value;
                        break;
                    case nameof(LastAccessed):
                        LastAccessed = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                    case nameof(LastModified):
                        LastModified = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                    case nameof(Path):
                        Path = (string)property.Value;
                        break;
                    case nameof(Readable):
                        Readable = (bool)property.Value;
                        break;
                    case nameof(System):
                        System = (bool)property.Value;
                        break;
                    case nameof(Writeable):
                        Writeable = (bool)property.Value;
                        break;
                }
            }
        });
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_LogicalFile cim_LogicalFile = (CIM_LogicalFile)managementClass;
        AccessMask = cim_LogicalFile.AccessMask;
        Archive = cim_LogicalFile.Archive;
        Compressed = cim_LogicalFile.Compressed;
        CompressionMethod = cim_LogicalFile.CompressionMethod;
        CreationClassName = cim_LogicalFile.CreationClassName;
        CreationDate = cim_LogicalFile.CreationDate;
        CSCreationClassName = cim_LogicalFile.CSCreationClassName;
        CSName = cim_LogicalFile.CSName;
        Drive = cim_LogicalFile.Drive;
        EightDotThreeFileName = cim_LogicalFile.EightDotThreeFileName;
        Encrypted = cim_LogicalFile.Encrypted;
        EncryptionMethod = cim_LogicalFile.EncryptionMethod;
        Extension = cim_LogicalFile.Extension;
        FileName = cim_LogicalFile.FileName;
        FileSize = cim_LogicalFile.FileSize;
        FileType = cim_LogicalFile.FileType;
        FSCreationClassName = cim_LogicalFile.FSCreationClassName;
        FSName = cim_LogicalFile.FSName;
        Hidden = cim_LogicalFile.Hidden;
        InUseCount = cim_LogicalFile.InUseCount;
        LastAccessed = cim_LogicalFile.LastAccessed;
        LastModified = cim_LogicalFile.LastModified;
        Path = cim_LogicalFile.Path;
        Readable = cim_LogicalFile.Readable;
        System = cim_LogicalFile.System;
        Writeable = cim_LogicalFile.Writeable;
    }
}
