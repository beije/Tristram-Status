using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tristram_Status
{
	class CharacterInfo
	{
		public int characterid { get; set; }
		public string charclass { get; set; }
		public int charlevel { get; set; }
		public string charname { get; set; }
		public int icondots { get; set; }
		public string profileurl { get; set; }

		public CharacterInfo() {
			
		}

	/*
	 * Example data
	 *	characterid: "712"
	 *	charclass: "Rogue"
	 *	charlevel: "15"
	 *	charname: "Teela"
	 *	icondots: "0"
	 *	profileurl: "http://www.tristr.am/character.php?characterid=712"
	 */
	}
}
