using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Tristram_Status
{
	class DataHandler
	{
		private String url = "http://tristr.am/api/events";
		private WebClient wc;
		private List<int> eventIdsCollected = new List<int>();

		public DataHandler() {
			wc = new WebClient();

			// Run once to cache all current updates
			this.getUpdates();

		}
		/// <summary>
		/// Downloads the events from tristr.am
		/// </summary>
		/// <returns>The raw Json data</returns>
		private String fetchData() {
			String data = "[]";
			try{
				data = this.wc.DownloadString( this.url );
			} catch( System.Net.WebException ) {}
			
			return data;
		}

		/// <summary>
		/// Parse through the updates from Tristr.am
		/// Checks which items are new and adds them to a collection
		/// </summary>
		/// <returns>Only the new items</returns>
		public List<Update> getUpdates()
		{
			var newUpdates = new List<Update>();
			List<Update> updates = JsonConvert.DeserializeObject<List<Update>>(this.fetchData());
			
			foreach( Update update in updates ) {
				bool found = false;
				if( this.eventIdsCollected.Count != 0 ) { 
					foreach( int id in this.eventIdsCollected ) {
						if( update.eventid == id ) {
							found = true;
						}
					}
				}
				if( found == false ){
					newUpdates.Insert( newUpdates.Count, update );
					eventIdsCollected.Insert( eventIdsCollected.Count, update.eventid );
				}
			}
			
			return newUpdates;
		}
	}

}
