

using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace SuperMarket.Associate.ClientInfo
{
  public  class ClientInfo
    {
        public static string identity = WindowsIdentity.GetCurrent().Name;
        public  static string computerName = Environment.MachineName;
        public static string remoteIpAddress = "127.0.0.1";
    
    }
}
