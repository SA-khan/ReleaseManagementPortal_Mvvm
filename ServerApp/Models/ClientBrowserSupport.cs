using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class ClientBrowserSupport
    {
        public long ClientBrowserSupportId { get; set; }
        public ClientBrowser Browser { get; set; }

    }
}
