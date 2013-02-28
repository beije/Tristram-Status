using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tristram_Status
{

	class Update
	{
		public CharacterInfo characterinfo { get; set; }
		public int eventid { get; set; }
		public double unixtime { get; set; }
		public string type { get; set; }
		public string message { get; set; }
		public int characterid { get; set; }
		public User userinfo { get; set; }
		

		public DateTime getHumanDate() {
			System.DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			date = date.AddSeconds(this.unixtime).ToLocalTime();

			return date;
		}

		public String getTextualDate() {

			TimeSpan span = (DateTime.Now - this.getHumanDate());
			int rest = (int) span.TotalSeconds;

			// Seconds
			if (rest < 60)
			{
				if (rest > 1)
				{
					return rest + " seconds ago";
				} else {
					return rest + " second ago";
				}
			}
		
			// Minutes
			if (rest < 3600)
			{
				double tmp = (rest / 60);
				var minutes = Math.Round( tmp );
				if( minutes > 1 ) {
					return minutes  +" minutes ago";
				} else {
					return minutes  +" minute ago";
				}
			}
		
			// Hours
			if( rest < 86400 ) {
				double tmp = ( (rest / 60) / 60 );
				var hours = Math.Round(tmp);
				if( hours > 1 ) {
					return hours  +" hours ago";
				} else {
					return hours  +" hour ago";
				}
			}
		
			// Days
			if( rest < 604800 ) {
				double tmp = (((rest / 60) / 60) / 24);
				var days = Math.Round( tmp );
				if( days > 1 ) {
					return days  +" days ago";
				} else {
					return days  +" day ago";
				}
			}

			return "A long time ago...";
		}

		/*
		 * Example data
		 * date: "23.02.2013"
		 * eventid: "7752"
		 * message: "Barlan is now online"
		 * time: "12:02:23"
		 * type: "charonline"
		 * unixtime: "1361613743"	 
		 */


	}
}
