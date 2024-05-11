using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;

namespace USBDevicesLibrary;

public class Win32_NetworkAdapterConfiguration : CIM_Setting
{
    public Win32_NetworkAdapterConfiguration()
    {
        DefaultIPGateway = [];
        DNSDomainSuffixSearchOrder = [];
        DNSServerSearchOrder = [];
        GatewayCostMetric = [];
        IPAddress = [];
        IPSecPermitIPProtocols = [];
        IPSecPermitTCPPorts = [];
        IPSecPermitUDPPorts = [];
        IPSubnet = [];
        IPXFrameType = [];
        IPXNetworkNumber = [];
    }

    public Win32_NetworkAdapterConfiguration(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration) : this()
    {
        RetrieveValues(win32_NetworkAdapterConfiguration);
    }

    public Win32_NetworkAdapterConfiguration(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public bool? ArpAlwaysSourceRoute {  get; set; }
    public bool? ArpUseEtherSNAP {  get; set; }
    public string? DatabasePath {  get; set; }
    public bool? DeadGWDetectEnabled {  get; set; }
    public List<string> DefaultIPGateway {  get; set; }
    public byte? DefaultTOS {  get; set; }
    public byte? DefaultTTL {  get; set; }
    public bool? DHCPEnabled {  get; set; }
    public DateTime? DHCPLeaseExpires {  get; set; }
    public DateTime? DHCPLeaseObtained {  get; set; }
    public string? DHCPServer {  get; set; }
    public string? DNSDomain {  get; set; }
    public List<string> DNSDomainSuffixSearchOrder {  get; set; }
    public bool? DNSEnabledForWINSResolution {  get; set; }
    public string? DNSHostName {  get; set; }
    public List<string> DNSServerSearchOrder {  get; set; }
    public bool? DomainDNSRegistrationEnabled {  get; set; }
    public UInt32? ForwardBufferMemory {  get; set; }
    public bool? FullDNSRegistrationEnabled {  get; set; }
    public List<UInt16> GatewayCostMetric {  get; set; }
    public byte? IGMPLevel {  get; set; }
    public UInt32? Index {  get; set; }
    public UInt32? InterfaceIndex {  get; set; }
    public List<string> IPAddress {  get; set; }
    public UInt32? IPConnectionMetric {  get; set; }
    public bool? IPEnabled {  get; set; }
    public bool? IPFilterSecurityEnabled {  get; set; }
    public bool? IPPortSecurityEnabled {  get; set; }
    public List<string> IPSecPermitIPProtocols {  get; set; }
    public List<string> IPSecPermitTCPPorts {  get; set; }
    public List<string> IPSecPermitUDPPorts {  get; set; }
    public List<string> IPSubnet {  get; set; }
    public bool? IPUseZeroBroadcast {  get; set; }
    public string? IPXAddress {  get; set; }
    public bool? IPXEnabled {  get; set; }
    public List<UInt32> IPXFrameType {  get; set; }
    public UInt32? IPXMediaType {  get; set; }
    public List<string> IPXNetworkNumber {  get; set; }
    public string? IPXVirtualNetNumber {  get; set; }
    public UInt32? KeepAliveInterval {  get; set; }
    public UInt32? KeepAliveTime {  get; set; }
    public string? MACAddress {  get; set; }
    public UInt32? MTU {  get; set; }
    public UInt32? NumForwardPackets {  get; set; }
    public bool? PMTUBHDetectEnabled {  get; set; }
    public bool? PMTUDiscoveryEnabled {  get; set; }
    public string? ServiceName {  get; set; }
    public UInt32? TcpipNetbiosOptions {  get; set; }
    public UInt32? TcpMaxConnectRetransmissions {  get; set; }
    public UInt32? TcpMaxDataRetransmissions {  get; set; }
    public UInt32? TcpNumConnections {  get; set; }
    public bool? TcpUseRFC1122UrgentPointer {  get; set; }
    public UInt16? TcpWindowSize {  get; set; }
    public bool? WINSEnableLMHostsLookup {  get; set; }
    public string? WINSHostLookupFile {  get; set; }
    public string? WINSPrimaryServer {  get; set; }
    public string? WINSScopeID {  get; set; }
    public string? WINSSecondaryServer {  get; set; }

    // Extra
    public string? Name { get; set; }


    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration = (Win32_NetworkAdapterConfiguration)managementClass;
        ArpAlwaysSourceRoute = win32_NetworkAdapterConfiguration.ArpAlwaysSourceRoute;
        ArpUseEtherSNAP = win32_NetworkAdapterConfiguration.ArpUseEtherSNAP;
        DatabasePath = win32_NetworkAdapterConfiguration.DatabasePath;
        DeadGWDetectEnabled = win32_NetworkAdapterConfiguration.DeadGWDetectEnabled;
        DefaultIPGateway = win32_NetworkAdapterConfiguration.DefaultIPGateway;
        DefaultTOS = win32_NetworkAdapterConfiguration.DefaultTOS;
        DefaultTTL = win32_NetworkAdapterConfiguration.DefaultTTL;
        DHCPEnabled = win32_NetworkAdapterConfiguration.DHCPEnabled;
        DHCPLeaseExpires = win32_NetworkAdapterConfiguration.DHCPLeaseExpires;
        DHCPLeaseObtained = win32_NetworkAdapterConfiguration.DHCPLeaseObtained;
        DHCPServer = win32_NetworkAdapterConfiguration.DHCPServer;
        DNSDomain = win32_NetworkAdapterConfiguration.DNSDomain;
        DNSDomainSuffixSearchOrder = win32_NetworkAdapterConfiguration.DNSDomainSuffixSearchOrder;
        DNSEnabledForWINSResolution = win32_NetworkAdapterConfiguration.DNSEnabledForWINSResolution;
        DNSHostName = win32_NetworkAdapterConfiguration.DNSHostName;
        DNSServerSearchOrder = win32_NetworkAdapterConfiguration.DNSServerSearchOrder;
        DomainDNSRegistrationEnabled = win32_NetworkAdapterConfiguration.DomainDNSRegistrationEnabled;
        ForwardBufferMemory = win32_NetworkAdapterConfiguration.ForwardBufferMemory;
        FullDNSRegistrationEnabled = win32_NetworkAdapterConfiguration.FullDNSRegistrationEnabled;
        GatewayCostMetric = win32_NetworkAdapterConfiguration.GatewayCostMetric;
        IGMPLevel = win32_NetworkAdapterConfiguration.IGMPLevel;
        Index = win32_NetworkAdapterConfiguration.Index;
        InterfaceIndex = win32_NetworkAdapterConfiguration.InterfaceIndex;
        IPAddress = win32_NetworkAdapterConfiguration.IPAddress;
        IPConnectionMetric = win32_NetworkAdapterConfiguration.IPConnectionMetric;
        IPEnabled = win32_NetworkAdapterConfiguration.IPEnabled;
        IPFilterSecurityEnabled = win32_NetworkAdapterConfiguration.IPFilterSecurityEnabled;
        IPPortSecurityEnabled = win32_NetworkAdapterConfiguration.IPPortSecurityEnabled;
        IPSecPermitIPProtocols = win32_NetworkAdapterConfiguration.IPSecPermitIPProtocols;
        IPSecPermitTCPPorts = win32_NetworkAdapterConfiguration.IPSecPermitTCPPorts;
        IPSecPermitUDPPorts = win32_NetworkAdapterConfiguration.IPSecPermitUDPPorts;
        IPSubnet = win32_NetworkAdapterConfiguration.IPSubnet;
        IPUseZeroBroadcast = win32_NetworkAdapterConfiguration.IPUseZeroBroadcast;
        IPXAddress = win32_NetworkAdapterConfiguration.IPXAddress;
        IPXEnabled = win32_NetworkAdapterConfiguration.IPXEnabled;
        IPXFrameType = win32_NetworkAdapterConfiguration.IPXFrameType;
        IPXMediaType = win32_NetworkAdapterConfiguration.IPXMediaType;
        IPXNetworkNumber = win32_NetworkAdapterConfiguration.IPXNetworkNumber;
        IPXVirtualNetNumber = win32_NetworkAdapterConfiguration.IPXVirtualNetNumber;
        KeepAliveInterval = win32_NetworkAdapterConfiguration.KeepAliveInterval;
        KeepAliveTime = win32_NetworkAdapterConfiguration.KeepAliveTime;
        MACAddress = win32_NetworkAdapterConfiguration.MACAddress;
        MTU = win32_NetworkAdapterConfiguration.MTU;
        NumForwardPackets = win32_NetworkAdapterConfiguration.NumForwardPackets;
        PMTUBHDetectEnabled = win32_NetworkAdapterConfiguration.PMTUBHDetectEnabled;
        PMTUDiscoveryEnabled = win32_NetworkAdapterConfiguration.PMTUDiscoveryEnabled;
        ServiceName = win32_NetworkAdapterConfiguration.ServiceName;
        TcpipNetbiosOptions = win32_NetworkAdapterConfiguration.TcpipNetbiosOptions;
        TcpMaxConnectRetransmissions = win32_NetworkAdapterConfiguration.TcpMaxConnectRetransmissions;
        TcpMaxDataRetransmissions = win32_NetworkAdapterConfiguration.TcpMaxDataRetransmissions;
        TcpNumConnections = win32_NetworkAdapterConfiguration.TcpNumConnections;
        TcpUseRFC1122UrgentPointer = win32_NetworkAdapterConfiguration.TcpUseRFC1122UrgentPointer;
        TcpWindowSize = win32_NetworkAdapterConfiguration.TcpWindowSize;
        WINSEnableLMHostsLookup = win32_NetworkAdapterConfiguration.WINSEnableLMHostsLookup;
        WINSHostLookupFile = win32_NetworkAdapterConfiguration.WINSHostLookupFile;
        WINSPrimaryServer = win32_NetworkAdapterConfiguration.WINSPrimaryServer;
        WINSScopeID = win32_NetworkAdapterConfiguration.WINSScopeID;
        WINSSecondaryServer = win32_NetworkAdapterConfiguration.WINSSecondaryServer;
        Name = SettingID;
        if (ParentUSBDevice != null)
        {
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.IPAddress))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.IPAddress, []);
            foreach (var item in IPAddress)
                ParentUSBDevice.Interfaces[InterfaceName.IPAddress].Add(string.Format("{0}, {1}", MACAddress, item));
        }
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
                    case nameof(ArpAlwaysSourceRoute):
                        ArpAlwaysSourceRoute = (bool)property.Value;
                        break;
                    case nameof(ArpUseEtherSNAP):
                        ArpUseEtherSNAP = (bool)property.Value;
                        break;
                    case nameof(DatabasePath):
                        DatabasePath = (string)property.Value;
                        break;
                    case nameof(DeadGWDetectEnabled):
                        DeadGWDetectEnabled = (bool)property.Value;
                        break;
                    case nameof(DefaultIPGateway):
                        if (property.Value != null)
                        {
                            string[] digs = (string[])property.Value;
                            foreach (string dig in digs)
                            {
                                DefaultIPGateway.Add(dig);
                            }
                        }
                        break;
                    case nameof(DefaultTOS):
                        DefaultTOS = (byte)property.Value;
                        break;
                    case nameof(DefaultTTL):
                        DefaultTTL = (byte)property.Value;
                        break;
                    case nameof(DHCPEnabled):
                        DHCPEnabled = (bool)property.Value;
                        break;
                    case nameof(DHCPLeaseExpires):
                        DHCPLeaseExpires = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                    case nameof(DHCPLeaseObtained):
                        DHCPLeaseObtained = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                    case nameof(DHCPServer):
                        DHCPServer = (string)property.Value;
                        break;
                    case nameof(DNSDomain):
                        DNSDomain = (string)property.Value;
                        break;
                    case nameof(DNSDomainSuffixSearchOrder):
                        if (property.Value != null)
                        {
                            string[] dnsdssos = (string[])property.Value;
                            foreach (string dnsdsso in dnsdssos)
                            {
                                DNSDomainSuffixSearchOrder.Add(dnsdsso);
                            }
                        }
                        break;
                    case nameof(DNSEnabledForWINSResolution):
                        DNSEnabledForWINSResolution = (bool)property.Value;
                        break;
                    case nameof(DNSHostName):
                        DNSHostName = (string)property.Value;
                        break;
                    case nameof(DNSServerSearchOrder):
                        if (property.Value != null)
                        {
                            string[] dnshns = (string[])property.Value;
                            foreach (string dnshn in dnshns)
                            {
                                DNSServerSearchOrder.Add(dnshn);
                            }
                        }
                        break;
                    case nameof(DomainDNSRegistrationEnabled):
                        DomainDNSRegistrationEnabled = (bool)property.Value;
                        break;
                    case nameof(ForwardBufferMemory):
                        ForwardBufferMemory = (UInt32)property.Value;
                        break;
                    case nameof(FullDNSRegistrationEnabled):
                        FullDNSRegistrationEnabled = (bool)property.Value;
                        break;
                    case nameof(GatewayCostMetric):
                        if (property.Value != null)
                        {
                            UInt16[] gcms = (UInt16[])property.Value;
                            foreach (UInt16 gcm in gcms)
                            {
                                GatewayCostMetric.Add(gcm);
                            }
                        }
                        break;
                    case nameof(IGMPLevel):
                        IGMPLevel = (byte)property.Value;
                        break;
                    case nameof(Index):
                        Index = (UInt32)property.Value;
                        break;
                    case nameof(InterfaceIndex):
                        InterfaceIndex = (UInt32)property.Value;
                        break;
                    case nameof(IPAddress):
                        if (property.Value != null)
                        {
                            string[] ipas = (string[])property.Value;
                            foreach (string ipa in ipas)
                            {
                                IPAddress.Add(ipa);
                            }
                        }
                        break;
                    case nameof(IPConnectionMetric):
                        IPConnectionMetric = (UInt32)property.Value;
                        break;
                    case nameof(IPEnabled):
                        IPEnabled = (bool)property.Value;
                        break;
                    case nameof(IPFilterSecurityEnabled):
                        IPFilterSecurityEnabled = (bool)property.Value;
                        break;
                    case nameof(IPPortSecurityEnabled):
                        IPPortSecurityEnabled = (bool)property.Value;
                        break;
                    case nameof(IPSecPermitIPProtocols):
                        if (property.Value != null)
                        {
                            string[] ipspips = (string[])property.Value;
                            foreach (string ipspip in ipspips)
                            {
                                IPSecPermitIPProtocols.Add(ipspip);
                            }
                        }
                        break;
                    case nameof(IPSecPermitTCPPorts):
                        if (property.Value != null)
                        {
                            string[] ipsptps = (string[])property.Value;
                            foreach (string ipsptp in ipsptps)
                            {
                                IPSecPermitTCPPorts.Add(ipsptp);
                            }
                        }
                        break;
                    case nameof(IPSecPermitUDPPorts):
                        if (property.Value != null)
                        {
                            string[] ipspups = (string[])property.Value;
                            foreach (string ipspup in ipspups)
                            {
                                IPSecPermitUDPPorts.Add(ipspup);
                            }
                        }
                        break;
                    case nameof(IPSubnet):
                        if (property.Value != null)
                        {
                            string[] ipss = (string[])property.Value;
                            foreach (string ips in ipss)
                            {
                                IPSubnet.Add(ips);
                            }
                        }
                        break;
                    case nameof(IPUseZeroBroadcast):
                        IPUseZeroBroadcast = (bool)property.Value;
                        break;
                    case nameof(IPXAddress):
                        IPXAddress = (string)property.Value;
                        break;
                    case nameof(IPXEnabled):
                        IPXEnabled = (bool)property.Value;
                        break;
                    case nameof(IPXFrameType):
                        if (property.Value != null)
                        {
                            UInt32[] ipxfts = (UInt32[])property.Value;
                            foreach (UInt32 ipxft in ipxfts)
                            {
                                IPXFrameType.Add(ipxft);
                            }
                        }
                        break;
                    case nameof(IPXMediaType):
                        IPXMediaType = (UInt32)property.Value;
                        break;
                    case nameof(IPXNetworkNumber):
                        if (property.Value != null)
                        {
                            string[] ipnns = (string[])property.Value;
                            foreach (string ipnn in ipnns)
                            {
                                IPXNetworkNumber.Add(ipnn);
                            }
                        }
                        break;
                    case nameof(IPXVirtualNetNumber):
                        IPXVirtualNetNumber = (string)property.Value;
                        break;
                    case nameof(KeepAliveInterval):
                        KeepAliveInterval = (UInt32)property.Value;
                        break;
                    case nameof(KeepAliveTime):
                        KeepAliveTime = (UInt32)property.Value;
                        break;
                    case nameof(MACAddress):
                        MACAddress = (string)property.Value;
                        break;
                    case nameof(MTU):
                        MTU = (UInt32)property.Value;
                        break;
                    case nameof(NumForwardPackets):
                        NumForwardPackets = (UInt32)property.Value;
                        break;
                    case nameof(PMTUBHDetectEnabled):
                        PMTUBHDetectEnabled = (bool)property.Value;
                        break;
                    case nameof(PMTUDiscoveryEnabled):
                        PMTUDiscoveryEnabled = (bool)property.Value;
                        break;
                    case nameof(ServiceName):
                        ServiceName = (string)property.Value;
                        break;
                    case nameof(TcpipNetbiosOptions):
                        TcpipNetbiosOptions = (UInt32)property.Value;
                        break;
                    case nameof(TcpMaxConnectRetransmissions):
                        TcpMaxConnectRetransmissions = (UInt32)property.Value;
                        break;
                    case nameof(TcpMaxDataRetransmissions):
                        TcpMaxDataRetransmissions = (UInt32)property.Value;
                        break;
                    case nameof(TcpNumConnections):
                        TcpNumConnections = (UInt32)property.Value;
                        break;
                    case nameof(TcpUseRFC1122UrgentPointer):
                        TcpUseRFC1122UrgentPointer = (bool)property.Value;
                        break;
                    case nameof(TcpWindowSize):
                        TcpWindowSize = (UInt16)property.Value;
                        break;
                    case nameof(WINSEnableLMHostsLookup):
                        WINSEnableLMHostsLookup = (bool)property.Value;
                        break;
                    case nameof(WINSHostLookupFile):
                        WINSHostLookupFile = (string)property.Value;
                        break;
                    case nameof(WINSPrimaryServer):
                        WINSPrimaryServer = (string)property.Value;
                        break;
                    case nameof(WINSScopeID):
                        WINSScopeID = (string)property.Value;
                        break;
                    case nameof(WINSSecondaryServer):
                        WINSSecondaryServer = (string)property.Value;
                        break;
                }
            }
        });
        Name = SettingID;
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(ArpAlwaysSourceRoute), Value = ArpAlwaysSourceRoute },
            new PnPEntityToList { Name = nameof(ArpUseEtherSNAP), Value = ArpUseEtherSNAP },
            new PnPEntityToList { Name = nameof(DatabasePath), Value = DatabasePath },
            new PnPEntityToList { Name = nameof(DeadGWDetectEnabled), Value = DeadGWDetectEnabled },
            new PnPEntityToList { Name = nameof(DefaultIPGateway), Value = string.Join("\r\n", DefaultIPGateway) },
            new PnPEntityToList { Name = nameof(DefaultTOS), Value = DefaultTOS },
            new PnPEntityToList { Name = nameof(DefaultTTL), Value = DefaultTTL },
            new PnPEntityToList { Name = nameof(DHCPEnabled), Value = DHCPEnabled },
            new PnPEntityToList { Name = nameof(DHCPLeaseExpires), Value = DHCPLeaseExpires },
            new PnPEntityToList { Name = nameof(DHCPLeaseObtained), Value = DHCPLeaseObtained },
            new PnPEntityToList { Name = nameof(DHCPServer), Value = DHCPServer },
            new PnPEntityToList { Name = nameof(DNSDomain), Value = DNSDomain },
            new PnPEntityToList { Name = nameof(DNSDomainSuffixSearchOrder), Value = string.Join("\r\n", DNSDomainSuffixSearchOrder) },
            new PnPEntityToList { Name = nameof(DNSEnabledForWINSResolution), Value = DNSEnabledForWINSResolution },
            new PnPEntityToList { Name = nameof(DNSHostName), Value = DNSHostName },
            new PnPEntityToList { Name = nameof(DNSServerSearchOrder), Value = string.Join("\r\n", DNSServerSearchOrder) },
            new PnPEntityToList { Name = nameof(DomainDNSRegistrationEnabled), Value = DomainDNSRegistrationEnabled },
            new PnPEntityToList { Name = nameof(ForwardBufferMemory), Value = ForwardBufferMemory },
            new PnPEntityToList { Name = nameof(FullDNSRegistrationEnabled), Value = FullDNSRegistrationEnabled },
            new PnPEntityToList { Name = nameof(GatewayCostMetric), Value = string.Join("\r\n", GatewayCostMetric) },
            new PnPEntityToList { Name = nameof(IGMPLevel), Value = IGMPLevel },
            new PnPEntityToList { Name = nameof(Index), Value = Index },
            new PnPEntityToList { Name = nameof(InterfaceIndex), Value = InterfaceIndex },
            new PnPEntityToList { Name = nameof(IPAddress), Value = string.Join("\r\n", IPAddress) },
            new PnPEntityToList { Name = nameof(IPConnectionMetric), Value = IPConnectionMetric },
            new PnPEntityToList { Name = nameof(IPEnabled), Value = IPEnabled },
            new PnPEntityToList { Name = nameof(IPFilterSecurityEnabled), Value = IPFilterSecurityEnabled },
            new PnPEntityToList { Name = nameof(IPPortSecurityEnabled), Value = IPPortSecurityEnabled },
            new PnPEntityToList { Name = nameof(IPSecPermitIPProtocols), Value = string.Join("\r\n", IPSecPermitIPProtocols) },
            new PnPEntityToList { Name = nameof(IPSecPermitTCPPorts), Value = string.Join("\r\n", IPSecPermitTCPPorts) },
            new PnPEntityToList { Name = nameof(IPSecPermitUDPPorts), Value = string.Join("\r\n", IPSecPermitUDPPorts) },
            new PnPEntityToList { Name = nameof(IPSubnet), Value = string.Join("\r\n", IPSubnet) },
            new PnPEntityToList { Name = nameof(IPUseZeroBroadcast), Value = IPUseZeroBroadcast },
            new PnPEntityToList { Name = nameof(IPXAddress), Value = IPXAddress },
            new PnPEntityToList { Name = nameof(IPXEnabled), Value = IPXEnabled },
            new PnPEntityToList { Name = nameof(IPXFrameType), Value = string.Join("\r\n", IPXFrameType) },
            new PnPEntityToList { Name = nameof(IPXMediaType), Value = IPXMediaType },
            new PnPEntityToList { Name = nameof(IPXNetworkNumber), Value = string.Join("\r\n", IPXNetworkNumber) },
            new PnPEntityToList { Name = nameof(IPXVirtualNetNumber), Value = IPXVirtualNetNumber },
            new PnPEntityToList { Name = nameof(KeepAliveInterval), Value = KeepAliveInterval },
            new PnPEntityToList { Name = nameof(KeepAliveTime), Value = KeepAliveTime },
            new PnPEntityToList { Name = nameof(MACAddress), Value = MACAddress },
            new PnPEntityToList { Name = nameof(MTU), Value = MTU },
            new PnPEntityToList { Name = nameof(NumForwardPackets), Value = NumForwardPackets },
            new PnPEntityToList { Name = nameof(PMTUBHDetectEnabled), Value = PMTUBHDetectEnabled },
            new PnPEntityToList { Name = nameof(PMTUDiscoveryEnabled), Value = PMTUDiscoveryEnabled },
            new PnPEntityToList { Name = nameof(ServiceName), Value = ServiceName },
            new PnPEntityToList { Name = nameof(TcpipNetbiosOptions), Value = TcpipNetbiosOptions },
            new PnPEntityToList { Name = nameof(TcpMaxConnectRetransmissions), Value = TcpMaxConnectRetransmissions },
            new PnPEntityToList { Name = nameof(TcpMaxDataRetransmissions), Value = TcpMaxDataRetransmissions },
            new PnPEntityToList { Name = nameof(TcpNumConnections), Value = TcpNumConnections },
            new PnPEntityToList { Name = nameof(TcpUseRFC1122UrgentPointer), Value = TcpUseRFC1122UrgentPointer },
            new PnPEntityToList { Name = nameof(TcpWindowSize), Value = TcpWindowSize },
            new PnPEntityToList { Name = nameof(WINSEnableLMHostsLookup), Value = WINSEnableLMHostsLookup },
            new PnPEntityToList { Name = nameof(WINSHostLookupFile), Value = WINSHostLookupFile },
            new PnPEntityToList { Name = nameof(WINSPrimaryServer), Value = WINSPrimaryServer },
            new PnPEntityToList { Name = nameof(WINSScopeID), Value = WINSScopeID },
            new PnPEntityToList { Name = nameof(WINSSecondaryServer), Value = WINSSecondaryServer },
            new PnPEntityToList { Name = nameof(Name), Value = Name },
        ];
        return filedsToList;
    }
}
