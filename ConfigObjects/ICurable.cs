using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBuff.ConfigObjects
{
     public interface ICurable
     {
          public byte CuresNeeded { get; set; }
     }
}
