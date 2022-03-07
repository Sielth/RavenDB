using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB.Models
{
    public class Address
    {
		public string City { get; set; }
		public string Country { get; set; }
		public string Line1 { get; set; }
		public object Line2 { get; set; }
		public object Location { get; set; }
		public string PostalCode { get; set; }
		public object Region { get; set; }
	}
}
