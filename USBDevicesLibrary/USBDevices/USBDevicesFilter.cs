using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDevicesLibrary;

internal class USBDevicesFilter
{
    public USBDevicesFilter()
    {
        VID = string.Empty;
        PID = string.Empty;
    }

    public string VID {  get; set; }
    public string PID {  get; set; }
}
