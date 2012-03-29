using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ; 

namespace SIPV.Security
{
    public interface ImnuSecurity
    {
        System.Windows.Forms.MenuStrip  mnuPrincipal();
        IWin32Window mOwner();
    }
    
}
