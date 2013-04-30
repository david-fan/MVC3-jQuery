using System;

namespace AddressBook_mvc3_jQuery
{
	public class Nandian : IDian
	{
		public Nandian ()
		{
		}
		public DianType Type{
			get{
				return DianType.Nandian;
			}
		}
	}
}

