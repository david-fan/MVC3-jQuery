using System;

namespace AddressBook_mvc3_jQuery
{
	public class QingganTaidu : IMubiao
	{
		public QingganTaidu ()
		{
		}

		public MubiaoType Type{
			get{
				return MubiaoType.QingganTaidu;
			}
		}
	}
}

