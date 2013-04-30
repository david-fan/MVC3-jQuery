using System;

namespace AddressBook_mvc3_jQuery
{
	public class Zhongdian : IDian
	{
		public Zhongdian ()
		{
		}
		public DianType Type{
			get{
				return DianType.Zhongdian;
			}
		}
	}
}

