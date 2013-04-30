using System;

namespace AddressBook_mvc3_jQuery
{
	public class ZhishiJineng : IMubiao
	{
		public ZhishiJineng ()
		{
		}
		public MubiaoType Type{
			get{
				return MubiaoType.ZhishiJineng;
			}
		}
	}
}

